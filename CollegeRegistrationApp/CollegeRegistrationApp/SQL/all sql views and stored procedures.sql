/* this will get the pre-requisites for a course 
(the return value needs to be set to go into stored proceudure #2)
cause this is returning multiple courses if a course has mroe than 1 pre-req
and one if a course has only 1 pre-req DELETE?*/

create or alter procedure dbo.getPreReqs
@course_id int,
@courses int output
as
begin
select R.Prereq_ID from dbo.preReqCheck R where
R.Course_ID = @course_id
end
go

declare @p int 
execute dbo.getPreReqs 1, @p out
/*this is second stored procedure so that you can put the pre-req course number in and it will let u 
know if it is taken or not DELETE?*/


Create or alter Procedure dbo.GetCoursesTakenByStudentID
@Year int,
@Student_ID int,
@Enrolled int,
@Course_ID int
as
begin
return(select Se.Course_ID
from (select S.Student_ID, T.Section_ID, T.Enrolled 
from dbo.Student S, dbo.Takes T
where S.Student_ID = T.Student_ID) as Taken, dbo.Section Se
where Taken.Section_ID = Se.Section_ID and Taken.Student_ID = @Student_ID and Taken.Enrolled = @Enrolled
and Se.year < @Year and Se.Course_ID = @Course_ID)
end

declare @co int
execute @co = dbo.GetCoursesTakenByStudentID 2024,1,1,14
if (@co = 0)
	print 'not taken'
else
	print 'taken'
print @co


/*this is the view for pre-requisites check */

Create or alter View dbo.preReqCheck
with schemabinding
as
select T1.Course_ID, T1.Course_Name, T1.Prereq_ID, C1.Course_Name as Prereq_Course_Name
from (select C.Course_ID, C.Course_Name, P.Prereq_ID
from dbo.Courses C, dbo.Prerequisites P
where C.Course_ID = P.Course_ID) T1, dbo.Courses C1
where T1.Prereq_ID = C1.Course_ID;

create Unique Clustered Index UIX_pre_req on dbo.preReqCheck(Prereq_ID)

/*procedure for get classes per semester without department A*/

create or alter procedure dbo.getCLasses
@Semester varchar(6),
@year int
as
begin
select D.Dept_Name, C.Course_Name, S.Section_ID, S.Semester,S.Year, TS.Day, TS.time_start, Ts.time_end
from dbo.Courses C, dbo.Section S, dbo.Department D, dbo.Instructor I, dbo.Time_Slot TS
where S.Course_ID = C.Course_ID and D.Dept_ID = C.Dept_id and 
S.Instructor_ID = I.Instructor_ID and TS.Time_Slot_ID = S.Time_Slot_ID and S.Semester = @semester and S.Year = @year;
end

/*procedure for get classes per semester with department A*/
create or alter procedure dbo.getCLasses2
@Semester varchar(6),
@year int,
@Department varchar(50)
as
begin
select D.Dept_Name, C.Course_Name, S.Section_ID, TS.Day, TS.time_start, Ts.time_end
from dbo.Courses C, dbo.Section S, dbo.Department D, dbo.Instructor I, dbo.Time_Slot TS
where S.Course_ID = C.Course_ID and D.Dept_ID = C.Dept_id and 
S.Instructor_ID = I.Instructor_ID and TS.Time_Slot_ID = S.Time_Slot_ID and S.Semester = @semester and S.Year = @year 
and D.Dept_Name = @Department;
end


/*procedure to get enrolled classes A*/

create or alter procedure dbo.getEnrolledClasses
@studentID int,
@enrolled int,
@year int
as
begin
select C.Course_Name, Taken2.Section_ID, Taken2.Semester, Taken2.Year, Taken2.Room_ID, Ts.Day, TS.time_start, TS.time_end
from
(select Se.Section_ID, Se.Semester, Se.Year, Se.Room_ID, Se.Instructor_ID, Se.Time_Slot_ID, Se.Course_ID
from (select S.Student_ID, T.Section_ID, T.Enrolled
from dbo.Student S, dbo.Takes T
where S.Student_ID = T.Student_ID) as Taken, dbo.Section Se
where Taken.Section_ID = Se.Section_ID and Taken.Student_ID = @studentID and Taken.Enrolled = @enrolled
and Se.year = @year) as Taken2, dbo.Time_Slot TS, dbo.Courses C
where Taken2.Time_Slot_ID = TS.Time_Slot_ID and C.Course_ID = Taken2.Course_ID;
end

 

/* sectioncoursetime  materialized view A*/

Create or alter View dbo.secCourTimeTable
with schemabinding
as
select C.Course_Name,S.Section_ID,S.Semester,s.Year, Ts.Day,S.Room_ID, TS.time_start,TS.time_end
from dbo.Section S, dbo.Time_Slot TS, dbo.Courses C
where S.Time_Slot_ID = TS.Time_Slot_ID and C.Course_ID = S.Course_ID

create Unique Clustered Index UIX_sectionNumber on dbo.secCourTimeTable(Section_ID)




/*
/*k this function and procedure works*/
/* we are not using this procdure*/
create or alter function getList(@Sem varchar(6))
returns @List1 table (season varchar(6))
as
begin 
	if (@Sem = 'spring')
	begin
		insert into @List1 values ('Winter');
	end
	else if (@Sem = 'Summer')
	begin
		insert into @List1 values('Winter');
		insert into @List1 values('Spring');
	end
	else if (@Sem = 'fall')
	begin
		insert into @List1 values('Winter');
		insert into @List1 values('Spring');
		insert into @List1 values('summer');
	end
	else
	begin
		insert into @List1 values('Winter');
		insert into @List1 values('Spring');
		insert into @List1 values('summer');
		insert into @List1 values('fall');
	end

	return

	end
go
*/

/*
 /* we are not using this procdure*/
create or alter procedure dbo.getc
@Year int,
@Student_ID int,
@Enrolled int,
@Course_ID int,
@Semester varchar(6)
as 
begin
select Se.Course_ID
from (select S.Student_ID, T.Section_ID, T.Enrolled 
from dbo.Student S, dbo.Takes T
where S.Student_ID = T.Student_ID) as Taken, dbo.Section Se
where Taken.Section_ID = Se.Section_ID and Taken.Student_ID = @Student_ID and Taken.Enrolled = @Enrolled
and (Se.year < @year or Se.year = @Year and (Se.Semester in (select * from dbo.getList(@Semester)))) and Se.Course_ID = @Course_ID
end

declare @co1 int
execute @co1 = dbo.getc 2024,1,1,15,'fall'
if (@co1 = 0)
	print 'not taken'
else
	print 'taken'
print @co1

*/





/*new function for pre-req multiple values*/
create or alter function getPreReq(@courseID int)
returns @List2 table (course int)
as
begin 
	insert into @List2
	select Prereq_ID from dbo.preReqCheck where Course_ID = @courseID
	return;
end
go

select * from dbo.getPreReq(70)


/**/
create or alter function getList(@Sem varchar(6))
returns @List1 table (season varchar(6))
as
begin 
	if (@Sem = 'spring')
	begin
		insert into @List1 values ('Winter');
	end
	else if (@Sem = 'Summer')
	begin
		insert into @List1 values('Winter');
		insert into @List1 values('Spring');
	end
	else if (@Sem = 'fall')
	begin
		insert into @List1 values('Winter');
		insert into @List1 values('Spring');
		insert into @List1 values('summer');
	end
	else
	begin
		insert into @List1 values('Winter');
		insert into @List1 values('Spring');
		insert into @List1 values('summer');
		insert into @List1 values('fall');
	end

	return

	end
go

--checks if the user has the prereck class and is still enrolled in it
create or alter function PreReckEnrolledCheck(@Year int, @Student_ID int, @Enrolled int, @Course_ID int, @Semester varchar(6))
returns int as 
begin
declare @courseP int;
set @courseP = (select Se.Course_ID 
from (select S.Student_ID, T.Section_ID, T.Enrolled 
from dbo.Student S, dbo.Takes T
where S.Student_ID = T.Student_ID) as Taken, dbo.Section Se
where Taken.Section_ID = Se.Section_ID and Taken.Student_ID = @Student_ID and Taken.Enrolled = @Enrolled
and (Se.year < @Year or Se.year = @Year and (Se.Semester in (select * from dbo.getList(@Semester)))) and Se.Course_ID = @Course_ID)
if (@courseP is null) 
	begin
		return 0
	end
else
	begin
		return 1
	end 
return 0
end
go

--select dbo.PreReckEnrolledCheck(2024, 1, 1, 15, 'Spring');  --test case true 
--select dbo.PreReckEnrolledCheck(2024, 1, 1, 14, 'Spring');  --test case false 



--gets how many people are enrolled in a section currently
--select dbo.spacesFree(18); --return 0 persons in the class
--select dbo.spacesFree(2); --return 1 persons in the class 
create or alter function spacesFree(@Section_ID int)
returns int as
begin
declare @count int;
set @count = (select count(*) from Takes where Takes.Section_ID = @Section_ID and Takes.Enrolled = 1)
return @count
end
go




