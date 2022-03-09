using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("nothing");

            Student[] students =
            {
                new Student(){Ects = 10,Name = "Karol"},
                new Student(){Ects = 10,Name = "Karolina"},
                new Student(){Ects = 10,Name = "Ania"},
                new Student(){Ects = 10,Name = "Piotrek"},
            };
            Array.Sort(students);
            foreach(Student s in students)
            {
                Console.WriteLine(s.Name);
            }

        }

        //public static explicit operator float(Money money)
    }

    class Student : IComparable<Student>
    {
        public int Ects { get; set; }
        public string Name { get; set; }

        public int CompareTo(Student other)
        {
            int result = Ects.CompareTo(other.Ects); // int implementuje CompareTo
            if (result == 0) 
            { 
                return Name.CompareTo(other.Name); // string implementuje CompareTo
            }
            else
            {
                return result;
            }
        }

    }

}
