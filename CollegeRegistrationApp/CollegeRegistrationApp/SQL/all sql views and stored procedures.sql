/* this will get the pre-requisites for a course 
(the return value needs to be set to go into stored proceudure #2)
cause this is returning multiple courses if a course has mroe than 1 pre-req
and one if a course has only 1 pre-req*/

create procedure dbo.getPreReqs
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
/*this is second stored procedure so that you can put the pre-req course number in and it will let u know if it is taken or not*/

Create Procedure dbo.GetCoursesTakenByStudentID
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

/*this is the view for pre-requisites check*/

Create View dbo.preReqCheck
with schemabinding
as
select T1.Course_ID, T1.Course_Name, T1.Prereq_ID, C1.Course_Name as Prereq_Course_Name
from (select C.Course_ID, C.Course_Name, P.Prereq_ID
from dbo.Courses C, dbo.Prerequisites P
where C.Course_ID = P.Course_ID) T1, dbo.Courses C1
where T1.Prereq_ID = C1.Course_ID;



/*these are all the views created for list fo classes available per semester */

Create View dbo.fall2024Classes
with schemabinding
as
select D.Dept_Name, C.Course_Name, S.Section_ID, S.Semester,S.Year, TS.Day, TS.time_start, Ts.time_end
from dbo.Courses C, dbo.Section S, dbo.Department D, dbo.Instructor I, dbo.Time_Slot TS
where S.Course_ID = C.Course_ID and D.Dept_ID = C.Dept_id and 
S.Instructor_ID = I.Instructor_ID and TS.Time_Slot_ID = S.Time_Slot_ID and S.Semester = 'fall' and S.Year = '2024';

/*Create Unique Clustered Index UIX_winter2023Classes
on winter2023Classes;*/

Create View dbo.fall2023Classes
with schemabinding
as
select D.Dept_Name, C.Course_Name, S.Section_ID, S.Semester,S.Year, TS.Day, TS.time_start, Ts.time_end
from dbo.Courses C, dbo.Section S, dbo.Department D, dbo.Instructor I, dbo.Time_Slot TS
where S.Course_ID = C.Course_ID and D.Dept_ID = C.Dept_id and 
S.Instructor_ID = I.Instructor_ID and TS.Time_Slot_ID = S.Time_Slot_ID and S.Semester = 'fall' and S.Year = '2023';

Create View dbo.winter2024Classes
with schemabinding
as
select D.Dept_Name, C.Course_Name, S.Section_ID, S.Semester,S.Year, TS.Day, TS.time_start, Ts.time_end
from dbo.Courses C, dbo.Section S, dbo.Department D, dbo.Instructor I, dbo.Time_Slot TS
where S.Course_ID = C.Course_ID and D.Dept_ID = C.Dept_id and 
S.Instructor_ID = I.Instructor_ID and TS.Time_Slot_ID = S.Time_Slot_ID and S.Semester = 'winter' and S.Year = '2024';

Create View dbo.winter2023Classes
with schemabinding
as
select D.Dept_Name, C.Course_Name, S.Section_ID, S.Semester,S.Year, TS.Day, TS.time_start, Ts.time_end
from dbo.Courses C, dbo.Section S, dbo.Department D, dbo.Instructor I, dbo.Time_Slot TS
where S.Course_ID = C.Course_ID and D.Dept_ID = C.Dept_id and 
S.Instructor_ID = I.Instructor_ID and TS.Time_Slot_ID = S.Time_Slot_ID and S.Semester = 'winter' and S.Year = '2023';

/*procedure for get classes per semester */

create procedure dbo.getCLasses
@Semester varchar(6),
@year int
as
begin
select D.Dept_Name, C.Course_Name, S.Section_ID, S.Semester,S.Year, TS.Day, TS.time_start, Ts.time_end
from dbo.Courses C, dbo.Section S, dbo.Department D, dbo.Instructor I, dbo.Time_Slot TS
where S.Course_ID = C.Course_ID and D.Dept_ID = C.Dept_id and 
S.Instructor_ID = I.Instructor_ID and TS.Time_Slot_ID = S.Time_Slot_ID and S.Semester = @semester and S.Year = @year;
end