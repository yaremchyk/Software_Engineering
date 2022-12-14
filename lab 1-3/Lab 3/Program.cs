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
            Customer person = new Customer("John Balboa", 22);
            Manager manager = new Manager("Micky Green", 31);

            Console.WriteLine("Hi, I'm " + person._name + ", my age is " +person._age);
            Console.WriteLine("Hello, my name is " + manager._name + ", I'm " + manager._age + " and Im your manager");

            Console.WriteLine("Choose your option");
            manager.PickOption();

            var punct = Convert.ToInt32(Console.ReadLine());
            switch (punct)
            {
                case 0:
                    Computer.ViewTours();
                    break;
                case 1:

                    break;
                case 2:

                    break;
                case 3:

                    break;
                case 4:
                    Computer.AboutAgency();
                    break;
                default:
                    Console.WriteLine("It's imposible!");//це неможливо
                    return;

            }
        }
    }
    public abstract class Person
    {
        public string _name;
        public int _age;
        public Person(string name, int age)
        {
            this._name = name;
            this._age = age;
        }
    }
    public class Customer : Person
    {
        public Customer(string name, int age) : base(name, age)
        {

        }
        
    }
    public  class Computer
    {
        public static string[] prefix = new string[] { "Country:", "Arrival date:", "Cost($):" };
        public static object[,] tours = new object[,] 
        { 
            { "Jamaica", "01.10.2022", "500"}, 
            { "Vienna", "20.12.2022", "250" },
            { "Changhai", "14.12.2022", "350" }

        };
        public static void ViewTours()
        {
            for(int y = 0; y < 3; y++) 
            {
            for (int i = 0; i <= 2; i++)
            {

                Console.WriteLine(prefix[i]);
                Console.WriteLine(tours[y, i]);
            }
                Console.WriteLine("\n");

            }
        }   
        public static void AboutAgency()
        {
            Console.WriteLine("Our agensy is cool");
        }
    }
    public class Manager : Person
    {
        public string[] questions = new string[] {"Choose a punct:", "0. View current tours", "1. Buy tickets",
                    "2. My tickets", "3. Change manager", "4. About our agency" };
        public Manager(string name, int age) : base(name, age)
        {

        }

        public void PickOption()
        {
            for (int i=0 ;i < questions.Length ; i++)
            {
                Console.WriteLine(questions[i]);
            }
        }
        
    }
}