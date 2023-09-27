using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
Create a Bank a class, with Debit & Credit method
You can assign a default balance using constructor
Credit method will accept the amount that needs to be added in balance
Debit method will accept the amount that needs to be deducted from the balance.
If amount is greater than balance raise an event → insufficient balance
If balance is low (< 3000) raise an event low balance
If balance is zero then raise an event zero balance.
Also use exception handling in the code

 */

namespace DelegateProject
{
    public delegate void MyDelegate3();
    public class Bank
    {
        public event MyDelegate3 insufficient_balance;
        public event MyDelegate3 low_balace;
        public event MyDelegate3 zero_balance;
        public int balance;

        public Bank()
        {
            this.balance = 20000;
        }
        public int CreditAmount(int amount)
        {
            
            this.balance=this.balance+amount;
            return this.balance;
        }

        public int DebitAmount(int amount)
        {
            if (amount > this.balance)
            {
                insufficient_balance();
            }
            else
            {
                this.balance = this.balance - amount;
            }
            return this.balance;
        }
        
        public void CheckBalace()
        {
            if(this.balance == 0) 
            {
                zero_balance();
            }
            if(this.balance <= 3000) 
            {
                low_balace();

            }
        }

    }
    public class ExampleEvent
    {
        public static void Main(string[] args)
        {
            try
            {
                Bank bank = new Bank();

                bank.insufficient_balance += delegate () { Console.WriteLine("Cannot Debit:Insufficient Balace"); };
                bank.low_balace += delegate () {  Console.WriteLine("Low Balace"); };
               bank.zero_balance += delegate () { Console.WriteLine("Zero Balace"); };

                Console.WriteLine("Enter Amount to be credited");
                int amt = Convert.ToInt32(Console.ReadLine());
                int credit=bank.CreditAmount(amt);
                Console.WriteLine(credit);

                Console.WriteLine("Enter Amount to be debited");
                int amt1 = Convert.ToInt32(Console.ReadLine());
                int debit=bank.DebitAmount(amt1);

                bank.CheckBalace();
                
                Console.WriteLine(debit);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
             }




        }
        

    }
}
