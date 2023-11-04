namespace bb103_enums
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Course course = new Course();
            course.Name = "Code";
            Person person = new Person();
            person.Name = "Qemze";
            person.Position = Positions.Student;
            Person person2 = new Person();
            person2.Name = "Nermine";
            person2.Position = Positions.Student;
            Person person3 = new Person();
            person3.Name = "Gulgez";
            person3.Position = Positions.Student;
            Person person4 = new Person();
            person4.Name = "Ulvi";
            person4.Position = Positions.Teacher;
            Person person5 = new Person();
            person5.Name = "Yusif";
            person5.Position = Positions.Teacher;
            course.AddPerson(person, person2, person3, person4, person5);
                                
            Console.WriteLine(course[2]);

            course[4] = person;

        }
        
       
    }
}