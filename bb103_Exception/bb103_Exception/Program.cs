using bb103_Exception.Exceptions;

namespace bb103_Exception
{
    internal class Program
    {
        static void Main(string[] args)
        {


            try
            {

                //int a = int.Parse(Console.ReadLine());
                //int[] arr = { 1, 3, 4 };
                //arr[6] = 25;

                Student student = new Student();
                student.Name = "Ulvi";
                student.Age = 12;
            }
            catch (FormatException exception)
            {
                
                Console.WriteLine(exception.Message);
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("0 a bolme emeliyyati oldu");
            }
           
            catch (Exception ex)
            {
                
                Console.WriteLine(ex.Message);
            }



           

        }
    }
}