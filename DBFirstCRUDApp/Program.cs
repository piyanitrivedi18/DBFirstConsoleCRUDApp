// See https://aka.ms/new-console-template for more information

using DBFirstCRUDApp.Models;

namespace DBFirstCRUDApp
{
    internal class Program
    {
        static StudentDbContext dbContext = null;
        static void Main(string[] args)
        {
            dbContext = new StudentDbContext();
            string ch = "yes";
            while (ch == "yes")
            {
                int choice = Menu();
                switch (choice)
                {
                    case 1:
                        {
                            Console.WriteLine("enter name");
                            string name = Console.ReadLine();
                            Console.WriteLine("enter batch");
                            string batch = Console.ReadLine();
                            Console.WriteLine("enter marks");
                            int marks = byte.Parse(Console.ReadLine());
                            Student student = new Student()
                            {
                                StudentName = name,
                                Batch = batch,
                                Marks = marks
                            };
                            Console.WriteLine(AddStudent(student));
                            break;
                        }
                    case 2:
                        {

                            List<Student> students = GetStudents();
                            if (students != null)
                            {
                                foreach (Student student in students)
                                {
                                    Console.WriteLine($"ID : {student.StudentId}Name : {student.StudentName}" +
                                        $"Batch is {student.Batch}Marks are {student.Marks}");
                                }

                            }
                            else
                                Console.WriteLine("No records");
                            break;
                        }

                    case 3:
                        {

                            Console.WriteLine("Enter id to search");
                            int id = Byte.Parse(Console.ReadLine());
                            Student student = GetStudent(id);
                            if (student != null)
                            {

                                Console.WriteLine($"ID : {student.StudentId}  Name : {student.StudentName}" +
                                    $"  Batch is {student.Batch}  Marks are {student.Marks}");


                            }
                            else
                                Console.WriteLine("No record with this ID");
                            break;
                        }

                    case 4:
                        {

                            Console.WriteLine("Enter id to delete");
                            int id = Byte.Parse(Console.ReadLine());
                            bool student = DeleteStudent(id);
                            if (student == true)
                            {
                                Console.WriteLine("Record deleted");
                            }
                            break;
                        }


                    case 5:
                        {

                            Console.WriteLine("Enter id to edit");
                            int id = Byte.Parse(Console.ReadLine());
                            Console.WriteLine("enter new batch");
                            string batch = Console.ReadLine();
                            Console.WriteLine("enter updated marks");
                            int marks = byte.Parse(Console.ReadLine());
                            Student student = GetStudent(id);
                            student = new Student()
                            {
                                StudentId = id,
                                StudentName = student.StudentName,
                                Batch = batch,
                                Marks = marks
                            };
                            bool edited = EditRecord(id, student);
                            if (edited == true)
                            {
                                Console.WriteLine("Record edited");
                            }
                            break;
                        }
                }


                Console.WriteLine("Want to repeat?");
                ch = Console.ReadLine();
            }
        }

        static int Menu()
        {
            Console.WriteLine("1. Insert");
            Console.WriteLine("2. Get STudents");
            Console.WriteLine("3. Search Student");
            Console.WriteLine("4. Delete Record");
            Console.WriteLine("5. Edit Record");
            Console.WriteLine("enter your choice");
            int ch = byte.Parse(Console.ReadLine());
            return ch;
        }

        static int AddStudent(Student student)
        {
            dbContext.Students.Add(student);
            dbContext.SaveChanges();
            return 1;
        }

        static bool DeleteStudent(int id)
        {
            Student stud = GetStudent(id);
            if (stud != null)
            {
                dbContext.Students.Remove(stud);
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        static Student GetStudent(int id)
        {
            Student student = null;
            student = dbContext.Students.Where(x => x.StudentId == id).FirstOrDefault();
            return student;
        }

        static bool EditRecord(int id, Student student)
        {
            Student temp = GetStudent(id);
            if (temp != null)
            {
                temp.Batch = student.Batch;
                temp.Marks = student.Marks;
                dbContext.SaveChanges();
                return true;
            }
            else
                return false;
        }


        static List<Student> GetStudents()
        {
            if (dbContext.Students.ToList().Count == 0)
                return null;
            else
                return dbContext.Students.ToList();
        }
    }
}



