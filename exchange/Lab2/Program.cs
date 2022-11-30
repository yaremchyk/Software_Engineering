using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Необхідно сворити додаток за допомогою якого можна буде імітувати роботу обмінника валют.

namespace Lab2
{
    class Program
    {
        #region Methods
        static void Main(string[] args) // Point of enter
        {
            #region Password
            Random rnd = new Random();
            int x = rnd.Next(3, 20);
            string[] truePassw = { x.ToString() };//вірний пароль
            Lab1.Program.Main(truePassw);
            Console.Write("Key = " + x + ". Enter the password = ");//ключ = x. Введіть пароль
            double customerPassw = Convert.ToDouble(Console.ReadLine());//пароль, отриманий від клієнта
            #endregion

            if (Convert.ToDouble(truePassw[0]) == customerPassw)
            {
                Computer computer = new Computer();
                Employee employee = new Employee(computer, 55555);//працівник
                Customer customer = new Customer();//клієнт
                customer.StartExchange(employee);
                
            }
            else
            {
                Console.WriteLine("We're simply sitting here");//Ми просто сидимо тут
            }
        }
        #endregion
    }
    class Customer //клієнт
    {
        #region Properties
        string _name = "Studentov Student Studentovich";
        #endregion

        #region Methods
        public void StartExchange(Employee employee)//початок обміну
        {
            int punct;
            double customerStartMoney;//початкові гроші клієнта
            double? customerResultMoney;//результуючі гроші клієнта

            employee.Question1();//питання 1
            punct = Convert.ToInt32(Console.ReadLine());
            switch (punct)
            {
                case 0:
                    break;
                case 1:
                    employee.Question2("grn to dollar");//питання 2
                    customerStartMoney = Convert.ToDouble(Console.ReadLine());
                    customerResultMoney = employee.Exchange("grn to dollar", customerStartMoney);
                    //_name + " дав " + customerStartMoney + " грн і отримав " + customerResultMoney + " доларів"
                    Console.WriteLine(_name + " get " + customerStartMoney + " grn and received " + customerResultMoney + " dollars");
                    break;
                case 2:
                    employee.Question2("grn to euro");
                    customerStartMoney = Convert.ToDouble(Console.ReadLine());
                    customerResultMoney = employee.Exchange("grn to euro", customerStartMoney);
                    //_name + " дав " + customerStartMoney + " грн і отримав " + customerResultMoney + " євро"
                    Console.WriteLine(_name + " get " + customerStartMoney + " grn and received " + customerResultMoney + " euros");
                    break;
                default:
                    Console.WriteLine("It's imposible!");//це неможливо
                    return;
            }
        }
        #endregion
    }
    class Employee //працівник обмінника
    {
        #region Properties //властивості
        public string Name { get; set; } = "Pracivnikov Pracivnik Pracivnikovich";//ім'я
        Computer _computer;

        double? _grnAmount = 2147483647;//кількість гривень в касі
        double? _dollarAmount = 65535;//кількість доларів в касі
        double? _euroAmount = 128;//кількість євро в касі
        #endregion

        #region Methods
        public Employee(Computer _computer)
        {
            this._computer = _computer;
        }
        public Employee(Computer _computer, double? grnAmount)
        {
            this._computer = _computer;
            _grnAmount = grnAmount;
        }


        public double? Exchange(string currencyOut, double customerStartMoney)
        {
            double? resultAmount = _computer.Exchange(currencyOut, customerStartMoney);
            switch (currencyOut)
            {
                case "grn to dollar":
                    _dollarAmount -= resultAmount;
                    break;
                case "grn to euro":
                    _euroAmount -= resultAmount;
                    break;
                default:
                    return null;
            }
            _grnAmount += customerStartMoney;


            return resultAmount;
        }
        public void Question1()
        {
            Console.WriteLine("Choose a punct:");//виберіть пункт
            Console.WriteLine("0. End of exchange");//завершення обміну
            Console.WriteLine("1. Exchange grn to dollar");//обміняти гривні на долари
            Console.WriteLine("2. Exchange grn to euro");//обміняти гривні на євро
            Console.WriteLine("3. Exchange dollar to grn");//обміняти долари на гривні
            Console.WriteLine("4. Exchange euro to grn");//обміняти євро на гривні
        }
        public void Question2(string currencyOut)
        {
            Console.Write("Today employee is " + name + ". ");//Сьогодні працівником є name.
            Console.WriteLine("How many " + currencyOut + " you want to exchange?");//Скільки currencyOut Ви хочете обміняти
        }
        #endregion
    }
    class Computer //комп'ютер
    {
        #region Properties
        double _dollarRateSell = 41.6;//ціна продажу
        double _dollarRateBuy = 41.5;//ціна купівлі
        double _euroRateSell = 40.9;//ціна продажу
        double _euroRateBuy = 40.8;//ціна купівлі
        #endregion

        #region Methods
        public double? Exchange(string currencyOut, double customerStartMoney)
        {
            switch (currencyOut)
            {
                case "grn to dollar":
                    return customerStartMoney / _dollarRateSell;
                case "grn to euro":
                    return customerStartMoney / _euroRateSell;
                default:
                    return null;
            }
        }
        #endregion
    }
}
