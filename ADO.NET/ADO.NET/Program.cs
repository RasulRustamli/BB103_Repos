using ADO.NET.Models;
using ADO.NET.Services;
using System.Data;
using System.Data.SqlClient;

namespace ADO.NET
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region ADO.NET Intro
            /////Non-Query
            ////string con = "server=DESKTOP-FHK353D;database=BB103_ADO;Trusted_connection=true;Integrated security=true";
            ////using (SqlConnection connection = new SqlConnection(con))
            ////{
            ////    connection.Open();

            ////    //string cmd = "INSERT INTO Students Values('Qemze',20)";
            ////    //using (SqlCommand command = new SqlCommand(cmd, connection))
            ////    //{
            ////    //    int result = command.ExecuteNonQuery();
            ////    //    if (result > 0)
            ////    //    {
            ////    //        Console.WriteLine("Succes");
            ////    //    }
            ////    //    else
            ////    //    {

            ////    //        Console.WriteLine("Some Error");
            ////    //    }
            ////    //}

            ////    //query

            ////    string querySelect = "SELECT * FROM Students";
            ////    using(SqlDataAdapter query=new SqlDataAdapter(querySelect,connection))
            ////    {
            ////        DataTable table= new DataTable();
            ////        query.Fill(table);

            ////        foreach(DataRow item in table.Rows)
            ////        {
            ////            Console.WriteLine(item["Id"]+" "+item["Name"]+" "+item["Age"]);
            ////        }

            ////    }

            ////}
            #endregion



            Student student = new Student();
            student.Name = "Narmin";
            student.Age = 20;

            StudentService studentService = new StudentService();

            //studentService.Add(student);
            studentService.Delete(3);



            foreach (var item in studentService.GetAll())
            {
                Console.WriteLine($"{item.Id}   {item.Name}  {item.Age}");
            }




        }
    }
}