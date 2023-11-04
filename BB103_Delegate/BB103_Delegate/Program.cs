namespace BB103_Delegate
{


    //internal delegate bool CheckNum(int num);
    //internal delegate void PrintConsole<T>(T word);
    internal class Program
    {

        static void Main(string[] args)
        {

            //string word = "saLam";
            //PrintConsole<string> print = PrintCapitalize;
            ////print.Invoke(word);
            ////print += PrintToUpper;
            ////print += PrintToLower;
            ////print(word);
            ////Console.WriteLine("------------------------");
            ////print -= PrintCapitalize;
            ////print(word);
            ////print += delegate (string a)
            ////  {
            ////      Console.WriteLine(a[0]);
            ////  };
            //print += (s) => Console.WriteLine(s[2]);

            //print("sagol");



            int[] arr = { 1, 2, 3, 4, 5, 6, 7 };
            List<string> list = new List<string>();
            list.Add("Salam");
            list.Add("Hello");
            list.Add("World");
            list.Add("word");


            //list.ForEach(s => Console.WriteLine(s));
            Console.WriteLine(list.FindAll(x => x.ToLower().Contains("w")));
            //foreach (string s in list)
            //{
            //    Console.WriteLine(s);
            //}


            //int result = Sum(arr, delegate (int number)
            //{
            //    return true;
            //});
            //int result = Sum(arr, number => number%3==0);
            //Console.WriteLine(result);

        }


        public static void PrintToLower(string word)
        {
            Console.WriteLine(word.ToLower());
        }
        public static void PrintToUpper(string a)
        {
            Console.WriteLine(a.ToUpper());

        }
        public static void PrintCapitalize(string word)
        {
            Console.WriteLine(char.ToUpper(word[0])+word.Substring(1).ToLower());
        }

        public static void PrintNum(int a)
        {
            Console.WriteLine(a);
        }


        public static int Sum(int[] arr, Func<int,bool> a,Action<int> action)
        {
            int sum = 0;
          
            for (int i = 0; i < arr.Length; i++)
            {
                if (a(arr[i]))
                {
                    sum += arr[i];
                }
            }
            action(sum);
            return sum;
        }
       public static bool CheckEven(int num)
        {
            return num % 2 == 0;
        }
        public static bool CheckOdd(int num)
        {
            return num % 2 != 0;
        }
        public static bool CheckPositive(int num)
        {
            return num > 0;
        }


    }
}