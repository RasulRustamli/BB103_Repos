using System.Reflection;

namespace bb103_Reflaction
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Assembly assembly = Assembly.GetExecutingAssembly();

            foreach (Type type in assembly.GetTypes())
            {
                Console.WriteLine("-------------------------");
                Console.WriteLine(type.Name);
                //Console.WriteLine("\t Properties:");
                //foreach (PropertyInfo property in type.GetProperties())
                //{
                //    Console.WriteLine(property);
                //}
                //Console.WriteLine("\t Methods :");
                //foreach (MethodInfo methods in type.GetMethods(BindingFlags.Instance|BindingFlags.NonPublic|BindingFlags.Public|BindingFlags.IgnoreReturn))
                //{
                //    Console.WriteLine(methods);
                //}
                //Console.WriteLine("\t Fields :");
                //foreach (FieldInfo fields in type.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static))
                //{
                //    Console.WriteLine(fields);
                //}
                foreach(var constr in type.GetConstructors())
                {
                    Console.WriteLine(constr);
                }
                

            }


            //Teacher teacher = new Teacher();
            //Type type = typeof(Teacher);

            //FieldInfo field = type.GetField("_id", BindingFlags.NonPublic | BindingFlags.Instance);

            //Console.WriteLine(field.GetValue(teacher));
            //field.SetValue(teacher, 45);
            //Console.WriteLine(field.GetValue(teacher));





        }
    }
}