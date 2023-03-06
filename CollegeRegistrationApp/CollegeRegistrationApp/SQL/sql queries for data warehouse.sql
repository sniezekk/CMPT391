/*sql queries for data warehouse */


--drill down based on Instructor Name
SELECT CONCAT(First_Name, ' ', Last_Name) AS Instructor_Name, COUNT(*) AS Total_Courses
FROM FactTable
JOIN WHinstructor ON FactTable.IID = WHinstructor.IID
GROUP BY CONCAT(First_Name, ' ', Last_Name)
ORDER BY Total_Courses DESC;


-- drill down based on Instructor Department
SELECT WHinstructor.Dept, COUNT(*) as Total_Courses
FROM FactTable
JOIN WHinstructor ON FactTable.IID = WHinstructor.IID
GROUP BY WHinstructor.Dept
ORDER BY Total_Courses DESC


--drill down based on Instructor Title
SELECT WHinstructor.Title, COUNT(*) as Total_Courses
FROM FactTable
JOIN WHinstructor ON FactTable.IID = WHinstructor.IID
GROUP BY WHinstructor.Title
ORDER BY Total_Courses DESC

--drill down based on Instructor Gender
SELECT WHinstructor.Gender, SUM(FactTable.no_course) as TotalCourses
FROM FactTable
INNER JOIN WHinstructor ON FactTable.IID = WHinstructor.IID
GROUP BY WHinstructor.Gender


-- drill down based on Course (ie Chem 101 )
SELECT WHcourses.Dept, WHcourses.Title, COUNT(FactTable.no_course) AS TotalCourses
FROM FactTable
INNER JOIN WHcourses ON FactTable.CID = WHcourses.CID
GROUP BY WHcourses.Dept, WHcourses.Title



--drill down based on Course Department
SELECT WHcourses.Dept, SUM(FactTable.no_course) AS TotalCourses
FROM FactTable
INNER JOIN WHcourses ON FactTable.CID = WHcourses.CID
GROUP BY WHcourses.Dept


--drill down based on Course title alone (just 101)
SELECT WHcourses.Title, COUNT(*) AS TotalCourses
FROM FactTable
JOIN WHcourses ON FactTable.CID = WHcourses.CID
GROUP BY WHcourses.Title
ORDER BY TotalCourses DESC;


--drill down based on Course credits
SELECT 
    No_credits AS Credits, 
    COUNT(*) AS Total_Courses 
FROM 
    WHcourses 
GROUP BY 
    No_credits 
ORDER BY 
    No_credits ASC;



-- drill down based on Date year
SELECT d.d_Year, COUNT(*) AS Total_courses
FROM FactTable f
JOIN WHdate d ON f.dateKey = d.dateKey
GROUP BY d.d_Year


--drill down based on Date term
SELECT d.term, COUNT(*) AS TotalCourses
FROM FactTable f
INNER JOIN WHdate d ON f.dateKey = d.dateKey
GROUP BY d.term



/*add your  induvidual queries here with just the filter u are searching*/