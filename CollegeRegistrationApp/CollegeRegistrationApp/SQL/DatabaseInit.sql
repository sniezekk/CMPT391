--Database Table Initialization Script
--Assume sql database is already created with name 'CollegeRegistration'
use CollegeRegistration;

--Create Department Table
create table Department (
	Dept_ID int identity(1, 1) primary key,
	Dept_Name varchar(50) not null
);

--Create Instructor Table
create table Instructor (
	Instructor_ID int identity(1, 1) primary key,
	First_Name varchar(50) not null,
	Last_Name varchar(50) not null,
	Dept_ID int not null,
	Unit_Number INT,
	Street_Number VARCHAR(50),
	Stret_Address VARCHAR(50),
	City varchar(50),
	State varchar(50) not null,
	Zip_Code varchar(6) not null,
	-- zip codes are 5 numbers, postal codes have 6, sometimes with a space
	Phone varchar(50) not null,
	foreign key (Dept_ID) references Department(Dept_ID)
);

ALTER TABLE Department
ADD Instructor_ID int;
Alter TABLE Department
ADD CONSTRAINT fk_instructor_id foreign key (Instructor_ID) REFERENCES Instructor(Instructor_ID);

--Create Course Table
create table Courses (
	Course_ID int identity(1, 1) primary key,
	Course_Name varchar(50) not null,
	Course_Description varchar(100) not null,
	Dept_id int not null,
	foreign key(Dept_ID) references Department(Dept_ID),
);

--Create Prereq Table
create table Prerequisites (
	Course_ID int not null,
	Prereq_ID int not null,
	foreign key(Course_ID) references Courses(Course_ID),
	foreign key(Prereq_ID) references Courses(Course_ID),
	primary key(Course_ID, Prereq_ID),
);

--Create Room Table
create table Room_Number (
	Room_ID int not null identity(1, 1) primary key,
	Capacity int not null,
);

--Create Table Time_Slot
create table Time_Slot (
	Time_Slot_ID int identity(1, 1) primary key,
	Day int not null,
	time_start varchar(10) not null,
	time_end varchar(10) not null,
);

--Create Section Table
create table Section (
	Section_ID int identity(1, 1) primary key,
	Semester varchar(6),
	Year int not null,
	Capacity int not null,
	Room_ID int not null,
	Instructor_ID int not null,
	Time_Slot_ID int not null,
	Course_ID int not null,
	foreign key(Room_ID) references Room_Number(Room_ID),
	foreign key(Instructor_ID) references Instructor(Instructor_ID),
	foreign key(Time_Slot_ID) references Time_Slot(Time_Slot_ID),
	foreign key(Course_ID) references Courses(Course_ID),
);

create table Student (
	Student_ID int identity(1, 1) primary key,
	First_Name varchar(50) not null,
	Last_Name varchar(50) not null,
	Unit_Number INT,
	Street_Number VARCHAR(50),
	Street_Address VARCHAR(50),
	City varchar(50),
	State varchar(50) not null,
	Zip_Code varchar(6) not null,
	-- zip codes are 5 numbers, postal codes have 6, sometimes with a space
	Phone varchar(50) not null,
);

create table Takes(
	Student_ID int not null,
	Section_ID int not null,
	Enrolled bit NOT NULL,
	foreign key(Student_ID) references Student(Student_ID),
	foreign key(Section_ID) references Section(Section_ID),
);