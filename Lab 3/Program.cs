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
            Assistant assistant = new Assistant("Max Troy", 21);  
            do
            {
                

                manager.PickOption();

                var menu_punct = Convert.ToInt32(Console.ReadLine());
                switch (menu_punct)
                {
                    case 0:
                        Computer.ViewTours(ref manager, menu_punct);
                        break;
                    case 1:
                        Computer.buyTickets(ref manager, menu_punct);
                        break;
                    case 2:
                        Computer.myTickets(ref manager, menu_punct);
                        break;
                    case 3:
                        Computer.changeManager(ref manager, menu_punct);
                        break;
                    case 4:
                        Computer.ChooseAssistant(ref assistant, ref manager, menu_punct);
                        break;
                    case 5:
                        Bag.MoneyCount();
                        break;
                    case 6:
                        Computer.AboutAgency(ref manager, menu_punct);
                        break;
                    case 7:
                        manager.Talk(ref manager, menu_punct);
                        break;
                    case 10:
                        System.Environment.Exit(-1);
                        break;
                    default:
                        Console.WriteLine("It's imposible!");//це неможливо
                        return;

                }

            }
            while (true);
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
        public static int[] TicketsCount { get; set; } = new int[mytickets.GetUpperBound(0) + 1];


        public Customer(string name, int age) : base(name, age)
        {

        }

    }
    public class Computer
    {
        public static string[] prefix = new string[] { "Country:", "Arrival date:", "Cost($):" };
        public static object[,] tours = new object[,]
        {
            { "Alps", "01.10.2022", "500"},
            { "Norway", "20.12.2022", "250" },
            { "Sahara desert", "14.12.2022", "350" }

        };
        public static void ViewTours(ref Manager manager, int menu_punct)
        {
            manager.Talk(ref manager, menu_punct);
            for (int y = 0; y <= 2; y++)
            {
                for (int i = 0; i < tours.GetUpperBound(0) + 1 ; i++)
                {

                    Console.WriteLine(prefix[i]);
                    Console.WriteLine(tours[y, i]);
                }
                Console.WriteLine("\n");

            }
        }
        public static void buyTickets(ref Manager manager , int menu_punct)
        {
            Computer.ViewTours(ref manager, menu_punct);
            Console.WriteLine("Choose tour, you want to buy tickets to.");
            var punct = Convert.ToInt32(Console.ReadLine());
            manager.Talk(ref manager, menu_punct);
            menu_punct = 8;
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

        }

        public static void buyTickets(int i)
        {
            for (int x = 0; x < 1; x++)
            {
                for (int y = 0; y < tours.GetUpperBound(0) + 1; y++)
                {
                    if (Convert.ToString(Customer.mytickets[x, y]) != "")
                    {
                        x++;
                    }
                    Customer.mytickets[x, y] = tours[i, y];
                    Customer.TicketsCount[x]++;
                }
            }
        }
        public static void myTickets(ref Manager manager, int menu_punct)
        {
            manager.Talk(ref manager, menu_punct);

            for (int y = 0; y <= 2; y++)
            {
                for (int i = 0; i < Customer.TicketsCount[y]; i++)
                {

                    Console.Write(prefix[i]);
                    Console.WriteLine(Customer.mytickets[y, i]);
                }
                Console.WriteLine("\n");

            }

        }
        public static void changeManager(ref Manager manager, int menu_punct) 
        {


            manager.Talk(ref manager, menu_punct);

            if (Convert.ToString(manager._name) != "John Cat")
            {
                manager = new Manager("John Cat", 31);
                Console.WriteLine("Hi, i'm " + manager._name + ", my age is " + manager._age + ", and i will be your new manager.");
                
            }
            else
            {
                manager = new Manager("Micky Green", 31);
                Console.WriteLine("Hi, i'm " + manager._name + ", my age is " + manager._age + ", and i will be your new manager.");
                
            }
        }
        public static void ChooseAssistant(ref Assistant assistant,ref Manager manager ,int menu_punct)
        {
            manager.Talk(ref manager, menu_punct);
            Console.WriteLine("Hi, im " + assistant._name + ", my age is " + assistant._age + ", and i will be your assistant");
        }
        public static void AboutAgency(ref Manager manager, int punct)
        {
            manager.Talk(ref manager, punct);
            Console.WriteLine("Our agensy is cool");

        }
    }
    public class Manager : Person
    {
        public string[] questions = new string[] {"\nChoose a punct:", "0. View current tours", "1. Buy tickets",
                    "2. My tickets", "3. Change manager", "4. Choose assistant", "5. My money", "6. About our agency" };
        public string[] phrases = new string[] {"Here is our current tours: \n", "You can buy tickets for this tours: \n", "Here is your tickets: \n", "Ok, i will ask another manager.\n", "Here is your assistant: \n", "", "About our agency: \n", "" };
        public Manager(string name, int age) : base(name, age)
        {

        }

        public void PickOption()
        {
            for (int i = 0; i < questions.Length; i++)
            {
                Console.WriteLine(questions[i]);
            }
        }
        public void Talk(ref Manager manager, int punct)
        {
            Console.WriteLine(manager._name + ":\n" + phrases[punct]);
            if(punct == 10)
            {
                Console.WriteLine(manager._name + ":\n");

            }
        }

    }
    public class Assistant : Person
    {
        public Assistant(string name, int age) : base(name, age)
        {

        }
    }
    public class Bag
    {

        public class Money
        {
        public static int _count = 500;
        }

        public class Items
        {
            public string[] items = new string[] { };
        }
        public static void MoneyCount()
        {
            Console.WriteLine("Your money: " + Bag.Money._count + "$");
        }
    }
    public class Country
    {

    }
    public class AR
    {

    }
    public class Quest
    {
        public string[] items = new string[] {"Alpine flower", "Catfish teeth", "Cammel wool"};

        public static void Alps_Quest()
        {

        }

        public static void Norway_Quest()
        {

        }

        public static void Sahara_Quest()
        {

        }
    }
    /*Ideas:
     * change program conception to adaptive reality tour agency
     * add each country own class(Jamaica, Vienna, Changhai), where all quests contains
     * add opportunity to enter to chosen country and do some quests
     * add opportunity to collect some items from quests
     * create a bag, where you can see your collected items from tours
     the game will be finished, when all items are collected 
     add assistante class an hiwm function
     add apartive reality system 
    */
}