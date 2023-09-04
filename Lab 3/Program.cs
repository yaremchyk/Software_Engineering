using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Program
{
    public class Program
    {
        public static void Main()
        {
            
            #region Properties

            Customer person = new Customer("John Balboa", 22);
            Manager manager = new Manager("Micky Green", 31);
            Assistant assistant = new Assistant("Max Troy", 21);

            #endregion

            #region Methods


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
                        Bag.Items.ShowItems();
                        break;
                    case 6:
                        assistant.PickQuest(ref assistant);
                        break;
                    case 7:
                        Computer.AboutAgency(ref manager, menu_punct);
                        break;
                    case 8:
                        Quest.QuestProcess();
                        /*Adapter.Talk();*/
/*                        var adapter = new Adapter();
*/                        break;
                    case 9:

                        var boxFight = new BoxFight();
                        IObserver riskyPlayer = new RiskyPlayer();
                        IObserver conservativePlayer = new ConservativePlayer();
                        boxFight.AttachObserver(riskyPlayer);
                        boxFight.AttachObserver(conservativePlayer);
                        Console.WriteLine("-A- \t -B-");
                        do
                        {
                            boxFight.NextRound();
                        }
                        while (boxFight.RoundNumber < 12);
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
        #endregion

    }
    public abstract class Person
    {
        #region Properties

        public string _name;
        public int _age;
        #endregion

        #region Methods

        public Person(string name, int age)
        {
            this._name = name;
            this._age = age;
        }
        #endregion

    }
    sealed class Singleton
    {
        private static Singleton _name;

        private Singleton()
        {
            
        }

        public static Singleton getInstance()
        {
            if (_name == null)
                _name = new Singleton();
            return _name;
        }
    }
    public class Customer : Person
    {
        #region Properties


        public static object[,] mytickets = new object[,]
        {
            { "", "", ""},
            { "", "", "" },
            { "", "", "" }

        };
        public static int[] TicketsCount { get; set; } = new int[mytickets.GetUpperBound(0) + 1];
        #endregion

        #region Methods

        public Customer(string name, int age) : base(name, age)
        {

        }
        public static string CheckForTicket(string country)
        {
            for (int i = 0; i < 2; i++)
            {
                if (Convert.ToString(Customer.mytickets[0,i]) == country)
                {
                    return "true";
                }
            }
            return "false";
        }
        #endregion

    }
    public class Computer
    {
        #region Properties

        public static string[] prefix = new string[] { "Country:", "Arrival date:", "Cost($):" };
        public static object[,] tours = new object[,]
        {
            { "Alps", "01.10.2022", "500"},
            { "Norway", "20.12.2022", "250" },
            { "Sahara desert", "14.12.2022", "350" }

        };
        #endregion

        #region Methods

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
            
                manager.Talk(ref manager, menu_punct);
            
            menu_punct = 19;
            var punct = Convert.ToInt32(Console.ReadLine());

            switch (punct)
            {
                case 0:
                    buyTickets(0);
                    Console.WriteLine("Succesfully buyed");
                    Bag.Money.MoneyMinus(Convert.ToInt32(Computer.tours[0,2]));
                    break;
                case 1:
                    buyTickets(1);
                    Console.WriteLine("Succesfully buyed");
                    Bag.Money.MoneyMinus(Convert.ToInt32(Computer.tours[1, 2]));
                    break;
                case 2:
                    buyTickets(2);
                    Console.WriteLine("Succesfully buyed");
                    Bag.Money.MoneyMinus(Convert.ToInt32(Computer.tours[2, 2]));
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
        #endregion

    }
    /*public class Adapter : Person //adapter pattern
    {
        Manager _adapter;
        public Adapter(Manager manager) : base(manager._name, manager._age)
        {

        }
        public void Talk(string text)
        {
            Manager.phrases[10] = text;
            _adapter.Talk(ref Manager _adapter, 10);
            Manager.phrases[10] = "";

        }
    }*/

    interface ISay
    {
        void Say()
        {
            
        }

    }

    public class Manager : Person
    {
        #region Properties

        public string[] questions = new string[] {"\nChoose a punct:", "0. View current tours", "1. Buy tickets",
                    "2. My tickets", "3. Change manager", "4. Choose assistant", "5. My money and items", "6. Enter quest", "7. About our agency" };
        public static string[] phrases = new string[] {"Here is our current tours: \n", "You can buy tickets for this tours: \n", "Here is your tickets: \n", "Ok, i will ask another manager.\n", "Here is your assistant: \n", "", "About our agency: \n", "", "", "10" };
        #endregion

        #region Methods

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
            Console.WriteLine(_name + ":\n" + phrases[punct]);
            if(punct == 10)
            {
                Console.WriteLine(_name + ":\n");

            }
        }
        #endregion

    }
    public class Assistant : Person
    {
        #region Properties
        #endregion

        #region Methods

        public Assistant(string name, int age) : base(name, age)
        {

        }
        public void AssistantTalk(string text)
        {
            Console.WriteLine("\n" + _name + ": \n" + text + "\n");
        }
        public void PickQuest(ref Assistant assistant)
        {
            AssistantTalk("Pick quest: \n0.Alps \n1.Norway \n2.Sahara desert");
            var punct = Convert.ToInt32(Console.ReadLine());
            switch (punct)
            {
                case 0:
                    AssistantTalk("Want to start quest?");
                    
                    if (Customer.CheckForTicket("Alps") == "true")
                    {
                        AssistantTalk("Before we start, I want to show you that you can adjust the brightness and volume of your AR.");
                        Quest.Alps_Quest();
                    }
                    else { AssistantTalk("You don't have tickets for this quest, or something went wrong"); }  
                    break;
                case 1:
                    AssistantTalk("Before we start, I want to show you that you can adjust the brightness and volume of your AR.");

                    if (Customer.CheckForTicket("Norway") == "true")
                    {
                        Quest.Norway_Quest();
                    }
                    else { AssistantTalk("You don't have tickets for this quest, or something went wrong"); }

                    break;
                case 2:
                    AssistantTalk("Before we start, I want to show you that you can adjust the brightness and volume of your AR.");

                    if (Customer.CheckForTicket("Sahara desert") == "true")
                    {
                        Quest.Sahara_Quest();
                    }
                    else { AssistantTalk("You don't have tickets for this quest, or something went wrong"); }

                    break;
                default:
                    Console.WriteLine("It's imposible!");//це неможливо
                    return;

            }
        }
        #endregion

    }
    public class Bag
    {
        #region Properties
        #endregion

        public class Money
        {
            #region Properties
            public static int _count = 500;
            #endregion

            #region Methods

            public static void MoneyPlus(int amount)
            { 
                Bag.Money._count = Bag.Money._count + amount;
            }
            public static void MoneyMinus(int amount)
            {
                Bag.Money._count = Bag.Money._count - amount;

            }
            #endregion


        }

        public class Items
        {
            #region Properties
            public static string[] items = new string[] {"", "", "" };

            public static int[] ItemsCount { get; set; } = new int[items.GetUpperBound(0) + 1];
            #endregion


            #region Methods

            public static void AddItem(int num)
            {           
                Bag.Items.items[num] = Quest.items[num];
            }
            public static void ShowItems()
            {
                Console.WriteLine("Your items:");
                
                    for (int i = 0; i < items.GetUpperBound(0) + 1; i++) //int i = 0; i < Bag.Items.ItemsCount[y]; i++
                    {
                        Console.WriteLine(items[i]);
                    }
                
            }

        }
        public static void MoneyCount()
        {
            Console.WriteLine("Your money: " + Bag.Money._count + "$");
        }
        #endregion

    }
    public class AR
    {
        #region Properties

        #endregion


        #region Methods
        public static void FixBrightness()
        {
            Console.WriteLine("Something went wrong with your AR set. You can't see anything. \n 0.Fix brightness ");
            var punct = Convert.ToInt32(Console.ReadLine());
            switch (punct)
            {
                case 0:
                    Console.WriteLine("Succesfully fixed.");
                break;
            }
        }
        public static void FixVolume()
        {
            Console.WriteLine("Something went wrong with your AR set. You can't see anything. \n0.Fix volume ");
            var punct = Convert.ToInt32(Console.ReadLine());
            switch (punct)
            {
                case 0:
                    Console.WriteLine("Succesfully fixed.");
                break;
            }
        }
        public static void AREvent()
        {
            Random random = new Random();
            int a;
            a = random.Next(100);

            if(a<50) {AR.FixBrightness(); };
            
            if (a > 50 && a < 99) { AR.FixVolume(); };

        }
        #endregion

    }
    public class Quest
    {
        #region Properties
        public static string[] items = new string[] {"Alpine flower", "Catfish teeth", "Cammel wool"};
        public int RoundNumber { get; private set; }
        private Random _random = new Random();
        public static int PlayerAScore { get; set; }
        public static int PlayerBScore { get; set; }
        public static string Winner = "null";
        

        #endregion


        #region Methods
        public static void Alps_Quest()
        {
            Bag.Items.AddItem(0);
            Bag.Money.MoneyPlus(350);
            AR.AREvent();
            Console.WriteLine("Quest done, you received: " + Quest.items[0] + " and 350$");

        }

        public static void Norway_Quest()
        {
            Bag.Items.AddItem(1);
            Bag.Money.MoneyPlus(250);
            AR.AREvent();
            Console.WriteLine("Quest done, you received: " + Quest.items[1] + " and 250$");
        }

        public static void Sahara_Quest()
        {
            Bag.Items.AddItem(2);
            Bag.Money.MoneyPlus(450);
            AR.AREvent();
            QuestProcess();
            if(Winner == "Player")
            {
                Console.WriteLine("Quest done, you received: " + Quest.items[2] + " and 450$");

            }
            else { Console.WriteLine("You lost, try again"); }
        }
        public void NextRound()
        {
            RoundNumber++;
            PlayerAScore += _random.Next(0, 5);
            PlayerBScore += _random.Next(0, 5);
            Console.WriteLine(PlayerAScore + " \t \t" + PlayerBScore);
            
        }
        public static void QuestProcess()
        {
            var boxFight = new Quest();
            Console.WriteLine("-Player- \t -Boss-");
            do
            {
                boxFight.NextRound();
            }
            while (boxFight.RoundNumber < 12);
            if (PlayerAScore > PlayerBScore)
            {
                Winner = "Player";
                Console.WriteLine("Winner: " + Winner);
            }
            else
            {
                Winner = "Boss";
                Console.WriteLine("Winner: " + Winner);
            }
        }
        
        

        #endregion
    }
    class Player
    {
        public string BoxerToPutMoneyOn { get; set; }
        public void Update(BoxFight subject)
        {
            var boxFight = subject;
            if (boxFight.BoxerAScore > boxFight.BoxerBScore)
                BoxerToPutMoneyOn = "I put on boxer A";
            else
            {
                BoxerToPutMoneyOn = "I put on boxer B";
                Console.WriteLine($"PLAYER:{BoxerToPutMoneyOn}");
            }
                
        }

    }
    class BoxFight
    {
        public int RoundNumber { get; private set; }
        private Random _random = new Random();
        public int BoxerAScore { get; set; }
        public int BoxerBScore { get; set; }
        IObserver[] _observer = new IObserver[2000];
        int _observerCounter;
        public void AttachObserver(IObserver observer)
        {
            _observer[_observerCounter] = observer;
            ++_observerCounter;
        }
        public void NextRound()
        {
            RoundNumber++;
            BoxerAScore += _random.Next(0, 5);
            BoxerBScore += _random.Next(0, 5);
            Console.WriteLine(BoxerAScore + " \t " +
            BoxerBScore);
            Notify();
        }
        public void Notify()
        {
            for (int i = 0; i < _observerCounter; ++i)
            {
                _observer[i].Update(this);
            }
        }
    }
    interface IObserver
    {
        void Update(BoxFight subject);

    }

    class RiskyPlayer : IObserver
    {
        public string BoxerToPutMoneyOn { get; set; }
        public void Update(BoxFight subject)
        {
            var boxFight = subject;
            if (boxFight.BoxerAScore > boxFight.BoxerBScore)
            {
                BoxerToPutMoneyOn = "I put on boxer B, if he win I get more!";
            }
            else {
                BoxerToPutMoneyOn = "I put on boxer A, if he win I get more!";
                Console.WriteLine("RISKYPLAYER:{0}", BoxerToPutMoneyOn);
            }
                
        }
    }

    class ConservativePlayer : IObserver
    {
        public string BoxerToPutMoneyOn { get; set; }
        public void Update(BoxFight subject)
        {
            var boxFight = subject;
            if (boxFight.BoxerAScore < boxFight.BoxerBScore)
            {
                BoxerToPutMoneyOn = "I put on boxer B, better be safe!";
            }
            else
            {
                BoxerToPutMoneyOn = "I put on boxer A, better be safe!";
                Console.WriteLine("CONSERVATIVEPLAYER:{0}", BoxerToPutMoneyOn);
            }
                
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
     add adapative reality system 
    */
}