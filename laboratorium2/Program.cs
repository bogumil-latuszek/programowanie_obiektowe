using System;

namespace laboratorium2
{
    class Program
    {
        static void Main(string[] args)
        {
            //base
            /*Aggregate aggregate = new ArrayIntAggregate();
            for (var iterator = aggregate.CreateIterator(); iterator.HasNext();)
            {
                Console.WriteLine(iterator.GetNext());
            }*/
            
            void test(Aggregate a)
            {
                Iterator i = a.CreateIterator();
                bool arrayEnded = false;
                for (i = a.CreateIterator(); !arrayEnded;)
                {
                    Console.WriteLine("**" + i.GetNext() + "**");
                    if (!i.HasNext())
                    {
                        arrayEnded = true;
                        Console.WriteLine("**" + i.GetNext() + "**");
                    }
                }
            }
            //zad.domowe1
            Console.WriteLine("zadanie domowe 1:");

            Aggregate2D a = new Aggregate2D();
            test(a);

            //zad.domowe2
            Console.WriteLine("zadanie domowe 2:");

            Aggregate2D2 a2 = new Aggregate2D2();
            test(a2);

            //zad.domowe3
            Console.WriteLine("zadanie domowe 3:");

            Aggregate2D3 a3 = new Aggregate2D3();
            test(a3);
            //zad.domowe4
            Console.WriteLine("zadanie domowe 4 :to samo co w 3");
            
            //zad.domowe5
            Console.WriteLine("zadanie domowe 5:");

            Aggregate2D5 a5 = new Aggregate2D5();
            test(a5);
        }
    }
}
