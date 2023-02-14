CREATE OR ALTER PROCEDURE dbo.registerInClass
	@StudentId int,
	@CourseId int,
	@SectionId int,
	@Year int,
	@Semester varchar(6),
	@Message varchar(50) OUTPUT
	as
	BEGIN 
	--Internal Variables
	DECLARE @conflict int;
	DECLARE @isEnrolled int;


	--check not enrolled
	SELECT @isEnrolled = dbo.isEnrolled(@Year + 1, @StudentId, 1, @CourseId, @Semester);

	if(@isEnrolled = 1)
		BEGIN
			SELECT @Message = 'Has already enrolled or completed.'
			RETURN
		END

	--check prequisites
	IF EXISTS (select * from (
					select *, dbo.getc(@Year, @StudentId, 1, c.course, @Semester) taken
					from (
						select * from (
							select * from courses c 
							where c.Course_ID = @CourseId
							) course
						cross 
						apply dbo.getPreReq(course.Course_ID)
						) c
					) prereq
				where prereq.taken is null)
		BEGIN
			SELECT @Message = 'Does not have prerequisites.'
			RETURN;
		END

	--check for time conflicts
	EXEC @conflict = dbo.timeConflict @Sec_ID_Given = @sectionID, @Student_ID_Given = @studentId
	IF (@conflict = 1)
		BEGIN
			SELECT @Message = 'There was a time conflict'
			RETURN;
		END

	BEGIN TRANSACTION;
	INSERT INTO Takes (Student_ID, Section_ID, Enrolled) values (@StudentId, @SectionId, 1);
	IF dbo.spacesFree(@SectionId) < 0
	BEGIN
		SELECT @Message = 'error when enrolling, try again'
		ROLLBACK;
	END;
	COMMIT TRANSACTION;
	SELECT @Message = 'Successfully enrolled';
	END;