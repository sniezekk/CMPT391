--to call this use this format below
--EXEC dbo.timeConflict @Sec_ID_Given = 'SECTION NUMBER PICKED', @Student_ID_Given = 'STUDENT NUMBER GIVEN'

--to create use this format below, without the comment
CREATE OR ALTER PROCEDURE dbo.timeConflict @Sec_ID_Given int, @Student_ID_Given int
AS
	set nocount on;

	declare @exists int
	if exists(

	select *
	from
	(select Semester, Year, Time_Slot_ID
	from Section S2
	where S2.Section_ID = @Sec_ID_Given) userWants,
	(select Semester, Year, Time_Slot_ID
	from
		(select *
		from Takes T1
		where T1.Student_ID = @Student_ID_Given and T1.Enrolled = 1 ) usertakes
	left join Section S1
	on usertakes.Section_ID = S1.Section_ID) enrolledIn
	where enrolledIn.Year = userWants.Year and enrolledIn.Time_Slot_ID = userWants.Time_Slot_ID and enrolledIn.Semester = userWants.Semester

	)
	begin
		set @exists = 1
	end
	else
	begin
		set @exists = 0
	end

	return @exists


GO

--example code, must adjust line 2 of the takes table to true and this will return a match
--declare @returnvalue int
--EXEC @returnvalue = dbo.timeConflict @Sec_ID_Given = 990, @Student_ID_Given = 81
--select @returnvalue

--https://www.aspsnippets.com/Articles/Stored-Procedure-Return-True-if-record-exists-and-False-if-record-does-not-exist-in-SQL-Server.aspx




/*
ayesha's code

still needs to be formated

select T1.Course_ID, T1.Course_Name, T1.Prereq_ID, C1.Course_Name as Prereq_Course_Name
from (select C.Course_ID, C.Course_Name, P.Prereq_ID
from dbo.Courses C, dbo.Prerequisites P
where C.Course_ID = P.Course_ID) T1, dbo.Courses C1
where T1.Prereq_ID = C1.Course_ID;
*/