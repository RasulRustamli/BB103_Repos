namespace BB103_Thread
{
    internal class Program
    {

        static int count = 0;

        static object lockobj=new object();
        static object lockobj2=new object();

        static async Task Main(string[] args)
        {
            //var a = await GetHtmlCodebb103();
            //Console.WriteLine(a);
            //Thread thread1 = new Thread(loop);
            //Thread thread2 = new Thread(loop2);
            //thread1.Start();
            //thread2.Start();
            //thread1.Join();
            //thread2.Join();


            //Console.WriteLine(count);
            //Console.WriteLine("salam");

             Task.Run(() =>
              {
                  Console.WriteLine("salam");
              });
            Console.ReadLine();
            
            //Console.WriteLine(GetHtmlCode());


        }

       


        public static string GetHtmlCode()
        {
            HttpClient client = new HttpClient();

            return client.GetStringAsync("https://kontakt.az/").Result;
        }

        public static  Task<string>  GetHtmlCodebb103()
        {
            HttpClient client = new HttpClient();


            
            return client.GetStringAsync("https://kontakt.az/");
        }


        //private static void loop2()
        //{

        //    //Thread.Sleep(5000);
        //    for (int i = 0; i < 1000000; i++)
        //    {
        //        lock(lockobj)
        //        {
        //            lock (lockobj2)
        //            {
        //                count++;
        //            }
        //        }


        //        //Console.WriteLine($"2 ci loop {i}");
        //    }
        //}

        //private static void loop()
        //{
        //    //Thread.Sleep(2000);
        //    for (int i = 0; i < 1000000; i++)
        //    {
        //        lock (lockobj2)
        //        {
        //            lock (lockobj)
        //            {
        //                count--;
        //            }
        //        }

        //        //Console.WriteLine($"1ci loop ise dusdu {i}");
        //    }
        //}
    }
}