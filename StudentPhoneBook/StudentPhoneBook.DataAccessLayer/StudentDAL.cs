using System;
using System.Collections.Generic;
using StudentPhoneBook.Entities;
using StudentPhoneBook.Exceptions;

namespace StudentPhoneBook.DataAccessLayer
{
    public class StudentDAL
    {
        public static List<Student> studentList = new List<Student>();

        public bool AddStudentDAL(Student newStud)
        {
            bool studentAdded = false;
            try
            {
                studentList.Add(newStud);
                studentAdded = true;
            }
            catch (SystemException ex)
            {
                throw new StudentPhoneBookException(ex.Message);
            }
            return studentAdded;

        }

        public List<Student> GetAllStudentsDAL()
        {
            return studentList;
        }

        public Student SearchStudentDAL(int searchStudID)
        {
            Student searchStudent = null;
            try
            {
                searchStudent = studentList.Find(student => student.StudentID == searchStudID);
            }
            catch (SystemException ex)
            {
                throw new StudentPhoneBookException(ex.Message);
            }
            return searchStudent;
        }

        public bool UpdateStudentDAL(Student updateStud)
        {
            bool studentUpdated = false;
            try
            {
                for (int i = 0; i < studentList.Count; i++)
                {
                    if (studentList[i].StudentID == updateStud.StudentID)
                    {
                        studentList[i].StudentName = updateStud.StudentName;
                        studentList[i].StudentContactNumber = updateStud.StudentContactNumber;
                        studentUpdated = true;
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new StudentPhoneBookException(ex.Message);
            }
            return studentUpdated;

        }

        public bool DeleteStudentDAL(int deleteStudID)
        {
            bool studentDeleted = false;
            try
            {
                Student deleteStudent = studentList.Find(student => student.StudentID == deleteStudID);

                if (deleteStudent != null)
                {
                    studentList.Remove(deleteStudent);
                    studentDeleted = true;
                }
            }
            catch (SystemException ex)
            {
                throw new StudentPhoneBookException(ex.Message);
            }
            return studentDeleted;

        }
        static void Main()
        {
        }

    }
}





