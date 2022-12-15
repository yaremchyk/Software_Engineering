using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    public class Program
    {
        public static void Main()
        {
            Customer person = new Customer("John Balboa", 22);
            Manager manager = new Manager("Micky Green", 31);

            manager.PickOption();

            var punct = Convert.ToInt32(Console.ReadLine());
            switch (punct)
            {
                case 0:
                    Computer.ViewTours();
                    break;
                case 1:
                    Computer.buyTickets();
                    break;
                case 2:
                    Computer.myTickets();
                    break;
                case 3:
/*                    Computer.changeManager();
*/                    break;
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
        public static object[,] mytickets = new object[,]
        {
            { "", "", ""},
            { "", "", "" },
            { "", "", "" }

        };
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
            for(int y = 0; y <= 2; y++) 
            {
            for (int i = 0; i < tours.GetUpperBound(0) + 1 ; i++)
            {

                Console.WriteLine(prefix[i]);
                Console.WriteLine(tours[y, i]);
            }
                Console.WriteLine("\n");

            }
            
        }   
        public static void buyTickets()
        {
            Computer.ViewTours();
            Console.WriteLine("Choose tour, you want to buy tickets to.");
            var punct = Convert.ToInt32(Console.ReadLine());
            switch (punct)
            {
                case 0:
                    buyTickets(0);
                    Console.WriteLine("Succesfully buyed");
                    
                    break;
                case 1:
                    buyTickets(1);
                    Console.WriteLine("Succesfully buyed");
                    
                    break;
                case 2:
                    buyTickets(2);
                    Console.WriteLine("Succesfully buyed");
                    break;
                default:
                    Console.WriteLine("It's imposible!");//це неможливо
                    return;

            }
            Program.Main();
        }

        public static void buyTickets(int i)
        {
            for (int x = 0; x < 1; x++)
            { 
                for (int y = 0; y < tours.GetUpperBound(0) + 1; y++)
                {
                    if (Convert.ToString(Customer.mytickets[x,y]) != "")
                    {
                        x++;
                        Customer.mytickets[x, y] = tours[i, y];
                    }
                    else
                    {
                        Customer.mytickets[x, y] = tours[i, y];

                    }
                }
            }
        }
        public static void myTickets()
        {
            for (int y = 0; y <= 2; y++)
            {
                for (int i = 0; i <= 2; i++)
                {

                    Console.WriteLine(prefix[i]);
                    Console.WriteLine(Customer.mytickets[y, i]);
                }
                Console.WriteLine("\n");

            }
            Program.Main();
        }
        /*public static void changeManager()
        {
            Manager manager = new Manager("John Cat", 31);


            if (Convert.ToString(manager._name) != "John Cat")
            {
                Manager manager = new Manager("John Cat", 31);
                Console.WriteLine("Hi, i'm " + manager._name + ", my age is " + manager._age + ", and i will be your new manager.");
                Program.Main();
            }
            else
            {
                Manager manager = new Manager("Micky Green", 31);
                Console.WriteLine("Hi, i'm " + manager._name + ", my age is " + manager._age + ", and i will be your new manager.");
                Program.Main();
            }
        }*/
        public static void AboutAgency()
        {
            Console.WriteLine("Our agensy is cool");
            Program.Main();
        }
    }
    public class Manager : Person
    {
        public string[] questions = new string[] {"\nChoose a punct:", "0. View current tours", "1. Buy tickets",
                    "2. My tickets", "3. Change manager", "4. About our agency\n" };
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