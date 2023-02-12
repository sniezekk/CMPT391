CREATE OR ALTER PROCEDURE dbo.registerInClass
	@StudentId int,
	@CourseId int,
	@SectionId int,
	@Year int,
	@Semester varchar(6),
	@Message varchar(50) OUTPUT
	as
	begin
	--Internal Variables
	DECLARE @conflict int;
	DECLARE @isEnrolled int;

	--check not enrolled
	SELECT @isEnrolled = dbo.getc(@Year, @StudentId, 1, @courseId, @Semester);
	if(@isEnrolled is not null)
		ROLLBACK
		SELECT @Message = 'Has already enrolled or completed.'
		RETURN;

	--check prequisites
	IF EXISTS (select * from (
					select *, dbo.getc(@year, @StudentId, 1, c.course, @Semester) taken
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
		SELECT @Message = 'Does not have prerequisites.'
		ROLLBACK
		RETURN;
	
	--check for time conflicts
	EXEC @conflict = dbo.timeConflict @Sec_ID_Given = @sectionID, @Student_ID_Given = @studentId
	IF (@conflict = 1)
		SELECT @Message = 'There was a time conflict'
		ROLLBACK
		RETURN;

	INSERT INTO Takes (Student_ID, Section_ID, Enrolled) values (@StudentId, @SectionId, 1);
	COMMIT;
	SELECT @Message = 'Successfully enrolled'
	end;