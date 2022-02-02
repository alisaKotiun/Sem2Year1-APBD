using System;
using System.Collections.Generic;

namespace LinqTutorials
{
    class Program
    {
        static void Main(string[] args)
        {
            var t1 = LinqTasks.Task1();
            Console.WriteLine("\n\tTask1");
            PrintList(t1);

            var t2 = LinqTasks.Task2();
            Console.WriteLine("\n\tTask2");
            PrintList(t2);

            var t3 = LinqTasks.Task3();
            Console.WriteLine("\n\tTask3");
            Console.WriteLine(t3);

            var t4 = LinqTasks.Task4();
            Console.WriteLine("\n\tTask4");
            PrintList(t4);

            var t5 = LinqTasks.Task5();
            Console.WriteLine("\n\tTask5");
            PrintList(t5);

            var t6 = LinqTasks.Task6();
            Console.WriteLine("\n\tTask6");
            PrintList(t6);

            var t7 = LinqTasks.Task7();
            Console.WriteLine("\n\tTask7");
            PrintList(t7);

            var t8 = LinqTasks.Task8();
            Console.WriteLine("\n\tTask8");
            Console.WriteLine(t8);

            var t9 = LinqTasks.Task9();
            Console.WriteLine("\n\tTask9");
            Console.WriteLine(t9);

            var t10 = LinqTasks.Task10();
            Console.WriteLine("\n\tTask10");
            PrintList(t10);

            var t11 = LinqTasks.Task11();
            Console.WriteLine("\n\tTask11");
            PrintList(t11);

            var t12 = LinqTasks.Task12();
            Console.WriteLine("\n\tTask12");
            PrintList(t12);

            var t13 = LinqTasks.Task13(new[]{ 1,1,1,1,1,10,10,1,1,1,3});
            Console.WriteLine("\n\tTask13");
            Console.WriteLine(t13);

            var t14 = LinqTasks.Task14();
            Console.WriteLine("\n\tTask14");
            PrintList(t14);
        }

        private static void PrintList(IEnumerable<Object> list)
        {
            foreach(Object o in list){
                Console.WriteLine(o);
            }
        }
    }
}
