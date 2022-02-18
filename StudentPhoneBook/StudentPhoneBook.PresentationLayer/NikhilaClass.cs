using System;
using System.Collections.Generic;
using StudentPhoneBook.Entities;
using StudentPhoneBook.BusinessLayer;
using StudentPhoneBook.Exceptions;

namespace StudentPhoneBook.PresentationLayer
{
    class NikhilaClass
    {
        static void Main()
        {
            int code;
            do
            {
                PrintMenu();
                Console.WriteLine("Enter your Choice:");
                code = Convert.ToInt32(Console.ReadLine());
                switch (code)
                {
                    case 1:
                        AddStudent();
                        break;
                    case 2:
                        ListAllStudents();
                        break;
                    case 3:
                        SearchStudentByID();
                        break;
                    case 4:
                        UpdateStudent();
                        break;
                    case 5:
                        DeleteStudent();
                        break;
                    case 6:
                        return;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            } while (code != -1);
        }

        private static void DeleteStudent()
        {
            try
            {
                int delStudentID;
                Console.WriteLine("Enter the StudentID to Delete:");
                delStudentID = Convert.ToInt32(Console.ReadLine());
                Student deleteGuest = StudentBL.SearchStudentBL(delStudentID);
                if (deleteGuest != null)
                {
                    bool studentdeleted = StudentBL.DeleteStudentBL(delStudentID);
                    if (studentdeleted)
                        Console.Write("Student is Deleted");
                    else
                        Console.Write("Student is not Deleted ");
                }
                else
                {
                    Console.Write("No Students Details are Available");
                }


            }
            catch (StudentPhoneBookException ex)
            {
                Console.Write(ex.Message);
            }
        }

        private static void UpdateStudent()
        {
            try
            {
                int updateStudID;
                Console.WriteLine("Enter StudentID to Update Details:");
                updateStudID = Convert.ToInt32(Console.ReadLine());
                Student updatedStudent = StudentBL.SearchStudentBL(updateStudID);
                if (updatedStudent != null)
                {
                    Console.WriteLine("Enter Student Name to Update :");
                    updatedStudent.StudentName = Console.ReadLine();
                    Console.WriteLine("Enter PhoneNumber to be Updated :");
                    updatedStudent.StudentContactNumber = Console.ReadLine();
                    bool studentUpdated = StudentBL.UpdateStudentBL(updatedStudent);
                    if (studentUpdated)
                        Console.Write("Student Details are Updated");
                    else
                        Console.Write("Student Details not Updated ");
                }
                else
                {
                    Console.Write("No Students Details Available");
                }


            }
            catch (StudentPhoneBookException ex)
            {
                Console.Write(ex.Message);
            }
        }

        private static void SearchStudentByID()
        {
            try
            {
                int searchStudID;
                Console.WriteLine("Enter StudentID to Search:");
                searchStudID = Convert.ToInt32(Console.ReadLine());
                Student searchStudent = StudentBL.SearchStudentBL(searchStudID);
                if (searchStudent != null)
                {
                    Console.WriteLine("---------------");
                    Console.WriteLine("StudentID\t\tName\t\tPhoneNumber");
                    Console.WriteLine("---------------");
                    Console.WriteLine("{0}\t\t{1}\t\t{2}", searchStudent.StudentID, searchStudent.StudentName, searchStudent.StudentContactNumber);
                    Console.WriteLine("---------------");
                }
                else
                {
                    Console.Write("No Student Details Available");
                }

            }
            catch (StudentPhoneBookException ex)
            {
                Console.Write(ex.Message);
            }
        }

        private static void ListAllStudents()
        {
            try
            {
                List<Student> studentList = StudentBL.GetAllStudentsBL();
                if (studentList != null)
                {
                    Console.WriteLine("-----------------");
                    Console.WriteLine("StudentID\t\tName\t\tPhoneNumber");
                    Console.WriteLine("------------------");
                    foreach (Student student in studentList)
                    {
                        Console.WriteLine("{0}\t\t{1}\t\t{2}", student.StudentID, student.StudentName, student.StudentContactNumber);
                    }
                    Console.WriteLine("---------------");

                }
                else
                {
                    Console.WriteLine("No Student Details are Available");
                }
            }
            catch (StudentPhoneBookException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void AddStudent()
        {
            try
            {
                Student newStudent = new Student();
                Console.WriteLine("Enter StudentID :");
                newStudent.StudentID = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Student Name :");
                newStudent.StudentName = Console.ReadLine();
                Console.WriteLine("Enter Contact Number :");
                newStudent.StudentContactNumber = Console.ReadLine();
                bool studentAdded = StudentBL.AddStudentBL(newStudent);
                if (studentAdded)
                    Console.Write("Student details Added");
                else
                    Console.Write("Student not Added");
            }
            catch (StudentPhoneBookException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private static void PrintMenu()
        {
            Console.WriteLine("\n-------Student PhoneBook Menu-------");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. List All Students");
            Console.WriteLine("3. Search Student by ID");
            Console.WriteLine("4. Update Student");
            Console.WriteLine("5. Delete Student");
            Console.WriteLine("6. Exit");
            Console.WriteLine("-------");
           
        }
    }
}