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
            list.Add(new Person { FirstName = "wqwqw"});
            list.Add(new Person { FirstName = "weqwe"});
            list.Add(new Person { FirstName = "vdvds"});
            list.Add(new Person { FirstName = "saada"});
            list.Add(new Person { FirstName = "dsdsd"});

            LinkedList<Person> linkedList = new LinkedList<Person>(list);
            Console.WriteLine("--------------------------------------------------");

            foreach(Person item in linkedList)
            {
                Console.WriteLine($"Iterating with foreach: {item.FirstName}");
            }
            Console.WriteLine("--------------------------------------------------");

            for (int i = 0; i < linkedList.Count; i++)
            {
                Console.WriteLine($"Iterating with indexer: {linkedList[i].FirstName}");
            }
            Console.WriteLine("--------------------------------------------------");

            linkedList.Add(new Person { FirstName = "qwwqq" });
            linkedList.Push(new Person { FirstName = "dssdd" });

            Console.WriteLine("--------------------------------------------------");

            linkedList.RemoveAll();

            Console.ReadLine();

        }
    }
}
