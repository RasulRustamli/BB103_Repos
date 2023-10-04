namespace ConsoleApp6
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Print2("sag");

            //Sum(1,2);
            //var number = Sum2(4, 6);
            //CheckNum(number);
            //if(CheckNum1(7))
            //{
            //    Console.WriteLine("Hello world");
            //}
            //else
            //{
            //    Console.WriteLine("salam dunya");
            //}
            //int[] numArr = { 5, 6, 8, 55, 65, 75 };
            //ArraySum(numArr);
            //ArraySumParams(5, 2, 6, 8, 46, 56, 4, 789, 45);
            //Sum(3, 2);
            //Sum(3.2, 4.1);

            Console.WriteLine(SumArray(5, 8, 25, 65, 45));
        }
        #region Print method
        static void Print()
        {
            Console.WriteLine("salam");
            Print2("world");
        }
        static void Print2(string word)
        {
            for (int i = 0; i < word.Length; i++)
            {
                Console.WriteLine(word[i]);
            }


        }
        #endregion

        #region Sum Methods
        //return type olmadan ve parametr qebul ederek ise dusen method
        //static void Sum(int num1,int num2)
        //{
        //    Console.WriteLine(num1+num2);
        //}
        ////return type olan ve parametr qebul ederek ise dusen method
        //static int Sum2(int num1,int num2)
        //{
        //    return num1 + num2;
        //}
        #endregion

        #region Task 1
        //methoduvuz bir int parametr qebul elesin ve
        //hemin parametrin cut olub olmadigini yoxlayin
        static void CheckNum(int num)
        {
            if (num % 2 == 0)
            {
                Console.WriteLine("bu eded cutdur");
            }
            else
            {
                Console.WriteLine("Bu eded tekdir");
            }
        }
        static bool CheckNum1(int num)
        {
            return num % 2 == 0;
        }
        #endregion

        #region Arrays method
        //array method declare 1 ci usul
        static void ArraySum(int[] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum+=arr[i];
            }
            Console.WriteLine(sum);
        }
        //2 ci usul
        static void ArraySumParams(params int[] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            Console.WriteLine(sum);
        }
        #endregion

        #region Method overloading

        static int Sum(int num1, int num2)
        {
            return num1 + num2;
        }
        static double Sum(double num1,double num2)
        {
            return num1 + num2;
        }
        static int Sum(int num1,int num2,int num3)
        {
            return  num1+num2 + num3;
        }
        static int Sum(int num1, int num2, int num3,int num4)
        {
            return num1+num2 + num3+num4;
        }


        #endregion

        #region Default


        static void MultiNum(int a,int b=1)
        {
            Console.WriteLine(a*b);
        }


        #endregion

        #region Task 2
        //2.bir method yaradin parametr olaraq
        //arrayi elnen daxil edin ve hemin arrayin cemini qaytarsin 
        static int SumArray(params int[] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];

            }
            return sum;
        }

        #endregion
    }
}