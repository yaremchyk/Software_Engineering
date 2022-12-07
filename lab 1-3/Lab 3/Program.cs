using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
        }
    }
    public abstract class Person
    {
        protected string _name;
        protected int _age;
        public Person(string name, int age)
        {
            _name = name;
            _age = age;
        }
    }
    public class Customer : Person
    {
        public Customer(string name, int age) : base(name, age)
        {

        }

    }
    public class Computer
    {

    }
    public class Manager : Person
    {

    }
}