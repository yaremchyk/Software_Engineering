using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Необхідно сворити додаток за допомогою якого можна буде імітувати роботу обмінника валют.

namespace Lab2
{

    enum Exchanges { 
        GrnToDollar,
        GrnToEuro,
        DollarToGrn,
        EuroToGrn
    }
    class Program
    {
        #region Methods
        static void Main(string[] args) // Point of enter
        {
            Customer person = new Customer("Barak Obama Studentovich", 22);
            (string name, int age) = person;
            Console.WriteLine(name);
            Console.WriteLine(age);

            //Console.WriteLine(Customer.Name);
            //Console.WriteLine(Customer._age)
            #region Password
            Random rnd = new Random();
            int x = rnd.Next(3, 20);
            string[] truePassw = { x.ToString() };//вірний пароль
            Lab1.Program.Main(truePassw);
            Console.Write("Key = " + x + ". Enter the password = ");//ключ = x. Введіть пароль
            double customerPassw = Convert.ToDouble(Console.ReadLine());//пароль, отриманий від клієнта
            #endregion

            localFunction();

            void localFunction()
            {
                if (Convert.ToDouble(truePassw[0]) == customerPassw)
                {
                    Computer computer = new Computer(40.5, 45, 41, 41.8);
                    Employee employee = new Employee(computer, 55555, 88888);//працівник
                    Customer customer = new Customer("Barak Obama Studentovich", 22);//клієнт
                    customer.StartExchange(employee);
                }
                else
                {
                    Console.WriteLine("We're simply sitting here");//Ми просто сидимо тут
                }

            }

        }
        #endregion
    }
    class Customer //клієнт
    {
        #region Properties
      public const string Name = "Barak Obama Studentovich";
      public  int Age  { get { return age + 1; } set { age = value; } }
         string name;
        int age;
        
        public Customer( string name, int age)
        {
            this.name = name;
            this.age = age;
        }
        public Customer(string name)
        {
            this.name = name;
            
        }
        public void Deconstruct(out string personName,out int personAge)
        {
            personName = name;
            personAge = age;
        }
        #endregion


        #region Methods
        public void StartExchange(Employee employee)//початок обміну
        {
            float customerStartMoney;//початкові гроші клієнта
            double? customerResultMoney;//результуючі гроші клієнта

            string[] questions = new string[] {"Choose a punct:", "0. End of exchange", "1. Exchange grn to dollar",
                    "2. Exchange grn to euro", "3. Exchange dollar to grn", "4. Exchange euro to grn" };
            employee.Question1(questions);//питання 1
            employee.Question1("Choose a punct:", "0. End of exchange", "1. Exchange grn to dollar",
                    "2. Exchange grn to euro", "3. Exchange dollar to grn", "4. Exchange euro to grn");//питання 1
            var punct = Convert.ToInt32(Console.ReadLine());
            switch (punct)
            {
                case 0:
                    break;
                case 1:
                    employee.Question2("grn to dollar");//питання 2
                    customerStartMoney = Convert.ToSingle(Console.ReadLine());
                    customerResultMoney = employee.Exchange(Exchanges.GrnToDollar, customerStartMoney);
                    //_name + " дав " + customerStartMoney + " грн і отримав " + customerResultMoney + " доларів"
                    Console.WriteLine(Name + " get " + customerStartMoney + " grn and received " + customerResultMoney + " dollars");
                    break;
                case 2:
                    employee.Question2("grn to euro");
                    customerStartMoney = (float) Convert.ToDouble(Console.ReadLine());
                    customerResultMoney = employee.Exchange(Exchanges.GrnToEuro, customerStartMoney);
                    //_name + " дав " + customerStartMoney + " грн і отримав " + customerResultMoney + " євро"
                    Console.WriteLine(Name + " get " + customerStartMoney + " grn and received " + customerResultMoney + " euros");
                    break;
                default:
                    Console.WriteLine("It's imposible!");//це неможливо
                    return;
            }
        }
        #endregion
    }
    struct Employee //працівник обмінника
    {
        #region Properties //властивості
        public string[] _name;
        public object _computer;

        public double? _grnAmount ;//кількість гривень в касі
        public double? _dollarAmount ;//кількість доларів в касі
        public double? _euroAmount;//кількість євро в касі
        #endregion

        #region Methods
        public Employee(Computer computer, double? dollarAmount, double? euroAmount)
        {
            _computer = computer;
            _name = new string[] {"Alex", "Tommy", "John", "William", "Jordan", "Bob", "Benjamin"  };
            _grnAmount = 125644560;
            _dollarAmount = dollarAmount;
            _euroAmount = euroAmount;
        }

        public double? Exchange(Exchanges currencyOut, double customerStartMoney)
        {
            double? resultAmount = ((Computer)_computer).Exchange(currencyOut, customerStartMoney);
            switch (currencyOut)
            {
                case Exchanges.GrnToDollar:
                    _dollarAmount -= resultAmount;
                    break;

                case Exchanges.GrnToEuro :
                    if (resultAmount >= _euroAmount)
                    {
                        return null;
                    }
                        _euroAmount -= resultAmount;
                 
                    break;
                case  Exchanges.DollarToGrn:
                   if (resultAmount < _grnAmount)
                   {
                        return null;
                   }
                      _grnAmount -= resultAmount;
            
                    break;

                case Exchanges.EuroToGrn:
                    if (resultAmount < _grnAmount)
                    {
                        return null;
                    }
                      _grnAmount -= resultAmount;
            
                    break;
                default:

                    return null;
            }
            _grnAmount += customerStartMoney;


            return resultAmount;
        }
        public void Question1(params string[] questions)
        {   
            for (int i = 0; i < questions.Length; i++)
            {
                Console.WriteLine(questions[i]);
            }
        }
        public void Question2(string currencyOut)
        {
            Random rnd = new Random();
            int value = rnd.Next(0, 7);
            Console.Write("Today employee is " + _name[value] + ". ");//Сьогодні працівником є name.
            Console.WriteLine("How many " + currencyOut + " you want to exchange?");//Скільки currencyOut Ви хочете обміняти
        }
        #endregion
    }
    class Computer //комп'ютер
    {
        #region Properties
        double _dollarRateSell;//ціна продажу
        double _dollarRateBuy;//ціна купівлі
        double _euroRateSell;//ціна продажу
        double _euroRateBuy;//ціна купівлі
        #endregion

        #region Methods
        public Computer(double dollarRateSell = 40.5, double dollarRateBuy = 45, double euroRateSell = 41, double euroRateBuy = 41.8)
        {
            this._dollarRateSell = dollarRateSell;
            this._dollarRateBuy = dollarRateBuy;
            _euroRateSell = euroRateSell;
            _euroRateBuy = euroRateBuy;


        }

        public double? Exchange( Exchanges currencyOut, double customerStartMoney)
        {

            switch (currencyOut)
            {
                case Exchanges.GrnToDollar:
                    return customerStartMoney / _dollarRateSell;
                case Exchanges.GrnToEuro :
                    return customerStartMoney / _euroRateSell;
                case Exchanges.DollarToGrn:
                    return customerStartMoney / _dollarRateBuy;
                case Exchanges.EuroToGrn:
                    return customerStartMoney / _euroRateBuy;
                default:
                    return null;
            }
        }
        #endregion
    }
}
