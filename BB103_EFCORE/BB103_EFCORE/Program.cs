using BB103_EFCORE.DAL;
using BB103_EFCORE.Models;

namespace BB103_EFCORE
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AppDbContext context=new AppDbContext();
            //Student student = new Student
            //{
            //    Name = "Qemze",
            //    Age = 21
            //};
            //context.Students.Add(student);
            //context.SaveChanges();

            //var student = context.Students.FirstOrDefault(x=>x.Id==1);
            //if(student!=null)
            //{

            //    Console.WriteLine(student.Name);
            //    context.Students.Remove(student);
            //    context.SaveChanges();
            //}
            //else
            //{
            //    Console.WriteLine("Bele bir object yoxdur ");
            //}


            //var students = context.Students.Where(x => x.Age > 21).ToList();
            //foreach (var student in students)
            //{
            //    Console.WriteLine(student.Name+" "+student.Age);
            //}





        }
    }
}