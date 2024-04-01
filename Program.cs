namespace Lab_8_ex_5
{
    using System;
    using System.Linq;
    using System.Runtime.CompilerServices;



    internal class Program
    {



        static void Main(string[] args)
        {
            // Student collection
            IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "Frank Furter", Age = 55, Major="Hospitality", Tuition=3500.00} ,
                new Student() { StudentID = 2, StudentName = "Gina Host", Age = 21, Major="Hospitality", Tuition=4500.00 } ,
                new Student() { StudentID = 3, StudentName = "Cookie Crumb",  Age = 21, Major="CIT", Tuition=2500.00 } ,
                new Student() { StudentID = 4, StudentName = "Ima Script",  Age = 48, Major="CIT", Tuition=5500.00 } ,
                new Student() { StudentID = 5, StudentName = "Cora Coder",  Age = 35, Major="CIT", Tuition=1500.00 } ,
                new Student() { StudentID = 6, StudentName = "Ura Goodchild" , Age = 40, Major="Marketing", Tuition=500.00} ,
                new Student() { StudentID = 7, StudentName = "Take Mewith" , Age = 29, Major="Aerospace Engineering", Tuition=5500.00 }
        };
            // Student GPA Collection
            IList<StudentGPA> studentGPAList = new List<StudentGPA>() {
                new StudentGPA() { StudentID = 1,  GPA=4.0} ,
                new StudentGPA() { StudentID = 2,  GPA=3.5} ,
                new StudentGPA() { StudentID = 3,  GPA=2.0 } ,
                new StudentGPA() { StudentID = 4,  GPA=1.5 } ,
                new StudentGPA() { StudentID = 5,  GPA=4.0 } ,
                new StudentGPA() { StudentID = 6,  GPA=2.5} ,
                new StudentGPA() { StudentID = 7,  GPA=1.0 }
            };
            // Club collection
            IList<StudentClubs> studentClubList = new List<StudentClubs>() {
            new StudentClubs() {StudentID=1, ClubName="Photography" },
            new StudentClubs() {StudentID=1, ClubName="Game" },
            new StudentClubs() {StudentID=2, ClubName="Game" },
            new StudentClubs() {StudentID=5, ClubName="Photography" },
            new StudentClubs() {StudentID=6, ClubName="Game" },
            new StudentClubs() {StudentID=7, ClubName="Photography" },
            new StudentClubs() {StudentID=3, ClubName="PTK" },
            };

            // Linq Method syntax for grouping by gpa
            var groupedGpa = studentGPAList.GroupBy(s => s.GPA);

            foreach (var gpaGroup in groupedGpa)
            {
                // Each group has a key indicating how  groups were formed
                // Console.WriteLine("Student GPA: " + gpaGroup);
                // Each group has a inner collection you can access and display
                foreach (StudentGPA s in gpaGroup)
                {

                    Console.WriteLine("Student Gpa: " + s.GPA);
                    Console.WriteLine("Student ID: " + s.StudentID);


                }
                Console.WriteLine();
            }
            /******************************************************************************/


            var clubs = studentClubList.OrderBy(p => p.ClubName).GroupBy(p => p.ClubName);

            {
                Console.WriteLine("Students clubs sorted and grouped and display students ID: ");
                Console.WriteLine();
                foreach (var StudentClubs in clubs)
                {
                    // Console.WriteLine("Club Group: " + clubs);
                    Console.WriteLine("Student ID: " + StudentClubs.Key);

                    foreach (StudentClubs p in StudentClubs)
                    {
                        Console.WriteLine("Clubs: " + p.ClubName);
                        Console.WriteLine("Student ID: " + p.StudentID);
                    }


                }
            }

            /*********************************************************************************/

            var numberOfStudents = studentGPAList.Count((q => q.GPA >= 2.5 && q.GPA <= 4.0));
            Console.WriteLine("");
            Console.WriteLine("Number of students GPA of greater than or equal to 2.5 and less than and equal than 4.0: " + numberOfStudents);
            Console.WriteLine();
            /*********************************************************************************/

            var avgTuition = studentList.Average(d => d.Tuition);
            Console.WriteLine("The tuition average for all students is: " + string.Format("{0:C}", avgTuition));
            Console.WriteLine();

            /************************************************************************************/

            Console.WriteLine("Max tuition: ");
            var maxTuition = studentList.Max(q => q.Tuition);
            foreach (Student s in studentList)
            {
                if (s.Tuition == maxTuition)
                    Console.WriteLine("Student: " + s.StudentName + " \t\t Major: " + s.Major + "\t\tTuition: " + s.Tuition);


            }

            /************************************************************************************/

            //LINQ Query method syntax using join to combine Student list and student gpa


            var innerJoin = studentList.Join(studentGPAList,
                                  student => student.StudentID,
                                  gpa => gpa.StudentID,
                                  (student, gpa) => new
                                  {
                                      StudentName = student.StudentName,
                                      Major = student.Major,
                                      GPA = gpa.GPA,


                                  });

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Students GPA: ");
            Console.WriteLine();
            Console.WriteLine();
            foreach (var s in innerJoin)
            {

                Console.WriteLine($"Name: {s.StudentName}   \t\t Major: {s.Major} \t\t GPA:  {s.GPA} ");
                Console.WriteLine();
            }
            Console.WriteLine();


            /********************************************************************/



            // Lab 8 excercise 5 g


            {



                var selected
                    = studentClubList.Where(x => x.ClubName == "Game")
                                .Join(studentList,
                                student => student.StudentID,
                                club => club.StudentID,
                                (club, student) => new { StudentName = student.StudentName });


                Console.WriteLine("Game Club Students: ");
                Console.WriteLine();

                foreach (var z in selected)
                {

                    Console.WriteLine(z.StudentName);


                }


            }
            {
                // StudentName = student.StudentName,
                // ClubName = club.ClubName




            };

        }

            
            

        }


    

                public class Student
        {
            public int StudentID { get; set; }
            public string? StudentName { get; set; }
            public int Age { get; set; }
            public string? Major { get; set; }
            public double? Tuition { get; set; }
        }

        public class StudentGPA
        {
            public int StudentID { get; set; }
            public double GPA { get; set; }
        }





        public class StudentClubs
        {
            public int StudentID { get; set; }
            public string? ClubName { get; set; }
        }
    }

