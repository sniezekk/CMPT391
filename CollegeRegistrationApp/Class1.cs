using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
namespace XMLdemo1
{
    class Program
    {
        //Model Class  
        class Student
        {
            public Student(string name, string location)
            {
                //With this, we are trying to target the class's field  
                this.Name = name;
                this.Location = location;
            }
            public string Name { get; set; }
            public string Location { get; set; }
        }
        public static void Main(string[] args)
        {
            // Populate the List  
            List<Student> student = CreateStudent();
            // creating the Document  
            var studentXml = new XDocument();
            //Now, we are Adding the Root Element  
            var rootElement = new XElement("Students");
            studentXml.Add(rootElement); //done with it  
            // Now we will add the child Element  
            foreach (Student temp in student)
            {
                // Create Child Element  
                var studntElem = new XElement("Student");
                //Now, add their child Element  
                var nameElement = new XElement("Name", temp.Name);
                studntElem.Add(nameElement);
                //Again, add Location in the same way  
                var locationElement = new XElement("Location", temp.Location);
                studntElem.Add(locationElement);
                // add the Main Child element to root  
                rootElement.Add(studntElem);
            }
            // Now, we will read the Created File  
            Console.WriteLine(studentXml.ToString());
            studentXml.Save("myData.xml");
            Console.ReadKey();
        }
        private static List<Student> CreateStudent()
        {
            List<Student> stud = new List<Student>()
            {
                new Student("Abhishek","Dhanbad"),
                new Student("Aman","Samastipur"),
                new Student("Vicky","Munger"),
                new Student("Chandan","Bhagalpur"),
                new Student("Ravi","Dhanbad")
            };
            //returning the Generic list  
            return stud;
        }
    }
}  
	}
}
