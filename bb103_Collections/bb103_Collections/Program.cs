using System.Collections;

namespace bb103_Collections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person();

            #region Non-generic
            #region ArrayList
            //ArrayList arrayList = new ArrayList();
            //arrayList.Add(1);
            //arrayList.Add(true);
            //arrayList.Add("Salam");
            //arrayList.Add(new Person() { Name = "Ulvi" });
            //arrayList.Add(new Person() { Name = "Ulvi" });

            //foreach (var item in arrayList)
            //{
            //    Console.WriteLine(item);
            //}
            ////arrayList.Clear();
            ////Console.WriteLine("After Clear");

            //Console.WriteLine("------------------------------");

            //arrayList.RemoveAt(0);
            //arrayList.RemoveAt(0);
            //Console.WriteLine(arrayList.Count);
            //foreach (var item in arrayList)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine(arrayList.Capacity);
            #endregion


            #region Queue


            //Queue queue = new Queue();

            //queue.Enqueue(true);//que-ye daxil edir
            //queue.Enqueue(1);
            //queue.Enqueue("salam");

            //foreach (var item in queue)
            //{
            //    Console.WriteLine(item);
            //}
            ////queue.Dequeue();//siradakin queden cixardir
            //Console.WriteLine("------------------------------------------");
            //foreach (var item in queue)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine("siradaki element : "+queue.Peek());
            #endregion


            #region Stack
            //Stack stack = new Stack();
            //stack.Push("salam");
            //stack.Push(true);
            //stack.Push(false);
            //foreach (var item in stack)
            //{
            //    Console.WriteLine(item);
            //}




            #endregion


            #region Hashtable
            //Hashtable ht = new Hashtable();
            //ht.Add(1, "salam");
            //ht.Add("hello", "salam");
            //ht.Add(11, true);

            ////foreach (var item in ht.Keys)
            ////{
            ////    Console.WriteLine(item);
            ////}
            //Console.WriteLine(ht["hello"]);
            #endregion
            #region SortedList
            //SortedList sortedList = new SortedList();
            //sortedList.Add("salam", 13);
            //sortedList.Add(1, 13);
            //sortedList.Add('A', 13) ;


            #endregion
            #endregion

            #region List<T>

            //List<int> list = new List<int>();
            //list.Add(3);
            //list.Add(1);
            //list.Add(4);

            //for (int i = 0; i < list.Count; i++)
            //{
            //    Console.WriteLine(list[i]);
            //}
            ////list.RemoveRange(0,2);
            ////list.RemoveAt();
            //Console.WriteLine("----------------------");

            //list.Sort();
            //for (int i = 0; i < list.Count; i++)
            //{
            //    Console.WriteLine(list[i]);
            //}

            #endregion

            #region SortedList

            //SortedList<int,string> sortedList = new SortedList<int,string>();
            //sortedList.Add(1, "sagol");
            //sortedList.Add(2, "sagol");
            //sortedList.Add(5, "filankes");
            //sortedList.Add(12, "world");
            //sortedList.Add(3, "hello");

            //foreach (var item in sortedList.Values)
            //{
            //    Console.WriteLine(item);
            //}

            #endregion

        }
    }
}