using System;
using System.Collections.Generic;
using System.Linq;

namespace FunctionalProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            //var result = Divide(2, new NonZeroInt(0));

            var intList = Enumerable.Range(0, 20);

            //Func<int, bool> evenLambda = a => a % 2 == 0;

            var evenListLambda = intList.Where(a => a % 2 == 0);

            //var evenListMethod = intList.Where(even);

            //Func<int, int> add2 = x => x + 2;

            var selectList = intList.Select(x => x + 2).Where(x => x>10);

            var result = intList.sumEven().rangeList().sumOdd();

            var newResult = 3.rangeList();

            var hello = "world".addAnotherString();

            var student = new Person(1, "salim");
            Console.WriteLine(student.id);


            var newList = new List<int>() { 1, 2, 3, 1, 2, 3, 4, 2};

            var group = newList.GroupBy(x => x).Select(s => new { Key = s.Key, Total = s.Count() });

            var repeat = Enumerable.Repeat("hello", 10);

            Console.WriteLine();
        }

        static int addTwo(int a) => a + 2;

        static void print(int a) => Console.WriteLine(a);

        //static void funcMethod<T>(IEnumerable<T> values, Action<T> action, Func<T, T> function)
        //{
        //    foreach (var i in values.Select(x => function(x)))
        //    {
        //        action(i);
        //    }
        //}
    }

    public static class ExtensionMethod
    {
        public static void funcMethod<T>(this IEnumerable<T> values, Action<T> action, Func<T, T> function)
        {
            foreach (var i in values.Select(x => function(x)))
            {
                action(i);
            }
        }

        public static int sumEven(this IEnumerable<int> values) => values.Where(x => x % 2 == 0).Sum();

        public static int sumOdd(this IEnumerable<int> values) => values.Where(x => x % 2 != 0).Sum();

        public static IEnumerable<int> rangeList(this int a) => Enumerable.Range(0, a);

        public static string addAnotherString(this string str) => "hello " + str;

        //public 
    }

    internal class NonZeroInt
    {
        public int values;

        public NonZeroInt(int _values)
        {
            if (_values == 0) { values = 1; }
            else { values = _values; }
        }
    }

    public class Person
    {
        public int id;
        public string name;

        public Person(int Id, string Name)
        {
            id = Id;
            name = Name;
        }

        public Person addId(int a)
        {
            this.id += a;
            return this;
        }
    }
}
