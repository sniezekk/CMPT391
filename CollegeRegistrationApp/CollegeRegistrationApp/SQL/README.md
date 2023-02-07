# Mock Data Generation

## How to use

Run the sql files in this order:

1. DatabaseInit
2. Student
3. Instructor
4. Department
5. Courses
6. Prerequsites
7. Room_Number
8. Time_Slot
9. Section
10. Takes

## Troubleshooting

During running those files, there will be a foreign constraint check on some of the files (like Instructor.sql). While I have disabled the constraint check, the constraint name might be different (Example of a constraint name:`FK__Instructo__Dept___3E52440B`), so you will have to modify that in the respective file to the constraint name in your database.
