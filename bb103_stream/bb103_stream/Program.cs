using Newtonsoft.Json;

namespace bb103_stream
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\rasul\OneDrive\Masaüstü\BB103_Directory";

            #region Directory///File
            ////Directory.CreateDirectory(path);

            ////foreach (var item in info.GetDirectories())
            ////{
            ////    Console.WriteLine(item.Name + "---------" + item.FullName);
            ////}
            ////DirectoryInfo info = new DirectoryInfo(path);
            ////info.Create();

            ////FileInfo fileInfo= new FileInfo(path+@"\test.txt");
            ////fileInfo.Create();

            ////File.Create(path + @"\bb103.txt");

            #endregion

            #region Reader///Writer
            //using (StreamWriter str = new StreamWriter(path + @"\test.txt", true))
            //{

            //    str.Write("hello world");
            //}
            //using (StreamReader sr = new StreamReader(path + @"\test.txt"))
            //{
            //    string result = sr.ReadToEnd();
            //    Console.WriteLine(result);
            //}
            #endregion



            #region Seriealize//Deseriealize
            //Directory.CreateDirectory(@"C:\Users\rasul\OneDrive\Masaüstü\bb103_stream\bb103_stream\Files");

            
            //Product product = new Product { Name = "Alma", Id = 1 };
            //Product product2 = new Product { Name = "Nar", Id = 2 };
            //Product product3 = new Product { Name = "Armud", Id = 3 };

            //List<Product> products = new List<Product>();
            //products.Add(product);
            //products.Add(product2);
            //products.Add(product3);
            //string convert=JsonConvert.SerializeObject(products);

            //using (StreamWriter sw = new StreamWriter(@"C:\Users\rasul\OneDrive\Masaüstü\bb103_stream\bb103_stream\Files\ObjectTest.json"))
            //{
            //    sw.Write(convert);
            //}
            //string resultJson;
            //using (StreamReader sr = new StreamReader(@"C:\Users\rasul\OneDrive\Masaüstü\bb103_stream\bb103_stream\Files\ObjectTest.json"))
            //{
            //     resultJson= sr.ReadToEnd();
            //}


            //List<Product> obj = JsonConvert.DeserializeObject<List<Product>>(resultJson);
            //obj.ForEach(x => Console.WriteLine(x.Name));

            

            


            #endregion












        }
    }

    class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
    }
   

    
}