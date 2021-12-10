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
            list.Add(new Person { FirstName = "list0"});
            list.Add(new Person { FirstName = "list2"});
            list.Add(new Person { FirstName = "list3"});
            list.Add(new Person { FirstName = "list4"});
            list.Add(new Person { FirstName = "list5"});

            LinkedList<Person> linkedList = new LinkedList<Person>(list);


            linkedList.Add(new Person { FirstName = "Added" });
            linkedList.Push(new Person { FirstName = "Pushed" });
            linkedList.Insert(new Person { FirstName = "Inserted to the beginning" }, 0);
            linkedList.Insert(new Person { FirstName = "Inserted to the end" }, 7);
            linkedList.Insert(new Person { FirstName = "Inserted to the 3rd index" }, 3);


            foreach (Person item in linkedList)
            {
                Console.WriteLine($"Iterating with foreach: {item.FirstName}");
            }

            Console.WriteLine("--------------------------------------------------");


            List<Person> subList = new List<Person>();
            subList.Add(new Person { FirstName = "sublist0" });
            subList.Add(new Person { FirstName = "sublist1" });
            subList.Add(new Person { FirstName = "sublist2" });
            subList.Add(new Person { FirstName = "sublist3" });
            subList.Add(new Person { FirstName = "sublist4" });

            linkedList.AddRange(subList);
            linkedList.PushRange(subList);
            linkedList.InsertRange(subList, 3);


            for (int i = 0; i < linkedList.Count; i++)
            {
                Console.WriteLine($"Iterating with indexer: {linkedList[i].FirstName}");
            }


            linkedList.RemoveAll();

            Console.ReadLine();
        }
    }
}
