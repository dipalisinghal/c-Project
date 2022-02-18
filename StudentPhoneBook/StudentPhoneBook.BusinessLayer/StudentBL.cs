
using System.Text;
using System;
using System.Collections.Generic;
using StudentPhoneBook.Entities;
using StudentPhoneBook.Exceptions;
using StudentPhoneBook.DataAccessLayer;

namespace StudentPhoneBook.BusinessLayer
{
    public class StudentBL
    {
        private static bool ValidateStudent(Student stud)
        {
            StringBuilder sb = new StringBuilder();
            bool validStudent = true;
            if (stud.StudentID <= 0)
            {
                validStudent = false;
                sb.Append(Environment.NewLine + "Student Id is Invalid");

            }
            if (stud.StudentName == string.Empty)
            {
                validStudent = false;
                sb.Append(Environment.NewLine + "Require Student Name");

            }
            if (stud.StudentContactNumber.Length < 10)
            {
                validStudent = false;
                sb.Append(Environment.NewLine + "Required 10 Digit Contact Number");
            }
            if (validStudent == false)
                throw new StudentPhoneBookException(sb.ToString());
            return validStudent;
        }

        public static bool AddStudentBL(Student newStud)
        {
            bool studentAdded = false;
            try
            {
                if (ValidateStudent(newStud))
                {
                    StudentDAL studentDAL = new StudentDAL();
                    studentAdded = studentDAL.AddStudentDAL(newStud);
                }
            }
            catch (StudentPhoneBookException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return studentAdded;
        }

        public static List<Student> GetAllStudentsBL()
        {
            List<Student> studentList = null;
            try
            {
                StudentDAL studentDAL = new StudentDAL();
                studentList = studentDAL.GetAllStudentsDAL();
            }
            catch (StudentPhoneBookException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return studentList;
        }

        public static Student SearchStudentBL(int searchStudID)
        {
            Student searchStudent = null;
            try
            {
                StudentDAL studentDAL = new StudentDAL();
                searchStudent = studentDAL.SearchStudentDAL(searchStudID);
            }
            catch (StudentPhoneBookException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return searchStudent;

        }

        public static bool UpdateStudentBL(Student updateStud)
        {
            bool studentUpdated = false;
            try
            {
                if (ValidateStudent(updateStud))
                {
                    StudentDAL studentDAL = new StudentDAL();
                    studentUpdated = studentDAL.UpdateStudentDAL(updateStud);
                }
            }
            catch (StudentPhoneBookException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return studentUpdated;
        }

        public static bool DeleteStudentBL(int deleteStudID)
        {
            bool studentDeleted = false;
            try
            {
                if (deleteStudID > 0)
                {
                    StudentDAL studentDAL = new StudentDAL();
                    studentDeleted = studentDAL.DeleteStudentDAL(deleteStudID);
                }
                else
                {
                    throw new StudentPhoneBookException("Invalid Student ID");
                }
            }
            catch (StudentPhoneBookException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return studentDeleted;
        }
        static void Main()
        {
        }

    }
}