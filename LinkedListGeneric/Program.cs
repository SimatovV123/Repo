using LinkedListGeneric.TestEntities;
using System;
using System.Collections.Generic;

namespace LinkedListGeneric
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> list = new List<Person>();
            list.Add(new Person { FirstName = "qqqqq"});
            list.Add(new Person { FirstName = "wwwww"});
            list.Add(new Person { FirstName = "eeeee"});
            list.Add(new Person { FirstName = "rrrrr"});
            list.Add(new Person { FirstName = "ttttt"});
            LinkedList<Person> linkedList = new LinkedList<Person>(list);
            Console.WriteLine("--------------------------------------------------");


            //linkedList.Add(new Person { FirstName = "aaaaa" });
            //linkedList.Push(new Person { FirstName = "sssss" });
            Console.WriteLine("--------------------------------------------------");


            List<Person> subList = new List<Person>();
            subList.Add(new Person { FirstName = "ttttt" });
            subList.Add(new Person { FirstName = "yyyyy" });
            subList.Add(new Person { FirstName = "uuuuu" });
            subList.Add(new Person { FirstName = "iiiii" });
            subList.Add(new Person { FirstName = "ooooo" });

            //linkedList.AddRange(subList);
            //linkedList.PushRange(subList);
            linkedList.InsertRange(subList,3);
            Console.WriteLine("--------------------------------------------------");



            foreach (Person item in linkedList)
            {
                Console.WriteLine($"Iterating with foreach: {item.FirstName}");
            }
            Console.WriteLine("--------------------------------------------------");


            for (int i = 0; i < linkedList.Count; i++)
            {
                Console.WriteLine($"Iterating with indexer: {linkedList[i].FirstName}");
            }
            Console.WriteLine("--------------------------------------------------");


            linkedList.RemoveAll();

            Console.ReadLine();

        }
    }
}
