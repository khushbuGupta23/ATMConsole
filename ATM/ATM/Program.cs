using ATM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ATM
{
    class Program
    {
        static void Main(string[] args)
        {
            Card card = new Card();
            card.Login();

        }
    }
    public static class Globals
    {
        public static int number;
    }
    class Card
    {

        public void Login()
        {

            int ch;
            Console.WriteLine("***** ATM Machine *****");


            Console.WriteLine("******* PLZ ENTER A ATM CARD NUMBER *********");

            Globals.number = Convert.ToInt32(Console.ReadLine());

            ATMEntities db = new ATMEntities();

            ATM_Table atm = new ATM_Table();

            var result = db.ATM_Table.Where(x => x.Card_Number == Globals.number).FirstOrDefault();

            if (result != null)
            {
                Console.WriteLine("******** WELCOME ********** ");

                Login_pin login_Pin = new Login_pin();
                login_Pin.login_2();

            }
            else
            {
                Console.WriteLine("WRONG CARD NUMBER");
                Console.WriteLine("PRESS 0 FOR RETRY");
                int a = int.Parse(Console.ReadLine());
                Console.Clear();
                if (a == 0)
                {

                    Card card = new Card();
                    card.Login();


                }


            }
            Console.ReadLine();
        }


    }


    class Login_pin
    {
        public void login_2()
        {

            int ch;
            Console.Clear();
            Console.WriteLine("******* PLZ ENTER A ATM PIN *********");

            string pwd = "";
            while (true)
            {
                ConsoleKeyInfo i = Console.ReadKey(true);
                if (i.Key == ConsoleKey.Enter)
                {
                    break;
                }
                else if (i.Key == ConsoleKey.Backspace)
                {
                    if (pwd.Length > 0)
                    {
                        pwd.Remove(pwd.Length - 1, 1);
                        Console.Write("\b \b");
                    }
                }
                else if (i.KeyChar != '\u0000')
                {
                    pwd = pwd + i.KeyChar;
                    Console.Write("*");
                }
            }
            int number = 0;
            if (int.TryParse(pwd, out number))
            {

            }


            //int pass = Convert.ToInt32(Console.ReadLine());

            ATMEntities db = new ATMEntities();

            ATM_Table atm = new ATM_Table();

            var result_2 = db.ATM_Table.Where(x => x.Pin == number).FirstOrDefault();

            if (result_2 != null)
            {
                Console.WriteLine("******** WELCOME ********** ");
                Choice choice = new Choice();
                choice.disp();

            }
            else
            {
                Console.WriteLine("WRONG PIN");
                Console.WriteLine("PRESS 0 FOR RETRY");
                int a = int.Parse(Console.ReadLine());
                Console.Clear();
                if (a == 0)
                {
                    Login_pin login_Pin = new Login_pin();
                    login_Pin.login_2();


                }



            }


        }


    }



    class Choice
    {
        public void disp()
        {
            Console.Clear();

            Console.WriteLine("_________________________________________________________________________________________________________________________");
            Console.WriteLine("*****    PRESS 1.FOR DEPOSIT MONEY   *****");
            Console.WriteLine("*****    PRESS 2.FOR WITHDRAW        *****");
            Console.WriteLine("*****    PRESS 3,FOR TOTAL AMOUNT    *****");
            Console.WriteLine("*****    PRESS 4.FOR CHANGE PIN      *****");
            Console.WriteLine("*****    PRESS 5.FOR EXIT            *****");

            int press = int.Parse(Console.ReadLine());

            switch (press)
            {
                case 1:

                    Deposit deposit = new Deposit();
                    deposit.D_money();
                    break;
                case 2:

                    Withdraw withdraw = new Withdraw();
                    withdraw.W_money();
                    break;
                case 3:

                    Amount amount = new Amount();
                    amount.T_money();
                    break;

                case 4:

                    ChangePin changePin = new ChangePin();
                    changePin.change();
                    break;
                case 5:
                    Exit exit = new Exit();
                    exit.disp();


                    break;


                default:
                    Console.WriteLine("WRONG PRESS");
                    Console.WriteLine("PRESS 0 FOR CONTINUE");
                    int ch = int.Parse(Console.ReadLine());
                    Console.Clear();
                    if (ch == 0)
                    {
                        Choice choice = new Choice();
                        choice.disp();


                    }




                    break;


            }


        }

    }
    class Deposit
    {
        public void D_money()
        {
            Console.Clear();
            Console.WriteLine("*****    PRESS 1.FOR DEPOSIT MONEY  *****");
            Console.WriteLine("_____________________________________________________________________________________________________________________________");


            Console.WriteLine("PLZ DEPOSIT MONEY");
            int deposit = int.Parse(Console.ReadLine());
            ATMEntities db = new ATMEntities();

            ATM_Table atm = new ATM_Table();


            var modifi = db.ATM_Table.Where(x => x.Card_Number == Globals.number).FirstOrDefault();


            if (modifi != null)
            {

                modifi.Balance = modifi.Balance + deposit;



            }
            db.SaveChanges();

            var show = from i in db.ATM_Table where (i.Card_Number == Globals.number) select i;
            foreach (var item in show)
            {
                Console.WriteLine("Total_Balance=" + item.Balance);
            }


            Console.WriteLine("PRESS 0 FOR CONTINUE");
            int ch = int.Parse(Console.ReadLine());
            Console.Clear();
            if (ch == 0)
            {
                Choice choice = new Choice();
                choice.disp();


            }





        }
    }
    class Withdraw
    {
        public void W_money()
        {
            Console.Clear();
            Console.WriteLine("*****    PRESS 2.FOR WITHDRAW  *****");
            Console.WriteLine("_________________________________________________________________________________________________________________________________");

            Console.WriteLine("PLZ WITHDRAW MONEY");
            int withdraw = int.Parse(Console.ReadLine());
            ATMEntities db = new ATMEntities();

            ATM_Table atm = new ATM_Table();


            var modifi = db.ATM_Table.Where(x => x.Card_Number == Globals.number).FirstOrDefault();


            if (modifi != null)
            {

                modifi.Balance = modifi.Balance - withdraw;



            }
            db.SaveChanges();

            var show = from i in db.ATM_Table where (i.Card_Number == Globals.number) select i;

            foreach (var item in show)
            {
                Console.WriteLine("Total_Balance=" + item.Balance);
            }



            Console.WriteLine("PRESS 0 FOR CONTINUE");
            int ch = int.Parse(Console.ReadLine());
            Console.Clear();
            if (ch == 0)
            {
                Choice choice = new Choice();
                choice.disp();


            }




        }
    }
    class Amount
    {
        public void T_money()
        {
            Console.Clear();
            Console.WriteLine("*****    PRESS 3,FOR TOTAL AMOUNT    *****");
            Console.WriteLine("____________________________________________________________________________________________________________________________________");
            ATMEntities db = new ATMEntities();

            ATM_Table atm = new ATM_Table();


            var show = from i in db.ATM_Table where (i.Card_Number == Globals.number) select i;

            foreach (var item in show)
            {
                Console.WriteLine("Total_Balance=" + item.Balance);
            }


            Console.WriteLine("PRESS 0 FOR CONTINUE");
            int ch = int.Parse(Console.ReadLine());
            Console.Clear();
            if (ch == 0)
            {
                Choice choice = new Choice();
                choice.disp();


            }

        }
    }
    class ChangePin
    {
        public void change()
        {
            Console.Clear();
            Console.WriteLine("*****    PRESS 4.FOR CHANGE PIN    *****");
            Console.WriteLine("___________________________________________________________________________________________________________________________");


            Console.WriteLine("PLZ ENTER A CARD NUMBER");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine("PLZ ENTER A  NEW PIN");
            int c_pin = int.Parse(Console.ReadLine());
            ATMEntities db = new ATMEntities();

            ATM_Table atm = new ATM_Table();


            var modifi = db.ATM_Table.Where(x => x.Card_Number == number).FirstOrDefault();



            if (modifi != null)
            {
                modifi.Pin = c_pin;

            }
            db.SaveChanges();
            Console.WriteLine("PIN CHANGE SUCCESSFULLY");


            Console.WriteLine("PRESS 0 FOR CONTINUE");
            int ch = int.Parse(Console.ReadLine());
            Console.Clear();
            if (ch == 0)
            {
                Choice choice = new Choice();
                choice.disp();


            }

        }



    }

    class Exit
    {
        public void disp()
        {
            Console.WriteLine("PRESS ANY KEY FOR EXIT");
            Console.ReadKey();

        }
    }
}