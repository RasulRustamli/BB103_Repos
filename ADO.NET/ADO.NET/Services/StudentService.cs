using ADO.NET.Data;
using ADO.NET.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET.Services
{
    internal class StudentService
    {
        private Sql _database;

        public StudentService()
        {
            _database = new Sql();
        }

        public void Add(Student student)
        {
            string cmd = $"INSERT INTO Students Values('{student.Name}','{student.Age}')";
           int result= _database.ExecuteNonQuery(cmd);
            if(result >0)
            {
                Console.WriteLine("Data base added");
            }
            else
            {
                Console.WriteLine("We have some problems");
            }
        }
        
        
        public int Delete(int id)
        {
            string command = $"DELETE FROM Students Where Id={id}";
            int result= _database.ExecuteNonQuery(command);
            return result;
        }



        public List<Student> GetAll()
        {
            string command = "Select * From Students";
            var table= _database.ExecuteQuery(command);
            List<Student> students = new List<Student>();

            foreach (DataRow item in table.Rows)
            {
                Student student = new Student()
                {
                    Id = Convert.ToInt32(item["Id"]),
                    Name = item["Name"].ToString(),
                    Age = Convert.ToInt32(item["Age"])
                };
                students.Add(student);
            }
            return students;


        }


    }
}
