using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateProject
{
    public delegate void MyDelegate();
    public class Student
    {
        public event MyDelegate pass;
        public event MyDelegate fail;

        public void AcceptPercentage(int per)
        {
            if(per<40)
            {
                fail();
            }
            else
            {
                pass();
            }
        }

    }
    public class Exampleeventdelegate
    {
        public void Successmessage()
        {
            Console.WriteLine("You are pass");
        }

        public void Failmessage()
        { 
            Console.WriteLine("You are Fail");
        }

    }

    public class program1
    {
        public static void Main(string[] args)
        {
            try
            {
                Student stud = new Student();
                Exampleeventdelegate ex = new Exampleeventdelegate();

                stud.fail += new MyDelegate(ex.Failmessage);
                stud.pass += new MyDelegate(ex.Successmessage);

                stud.AcceptPercentage(30);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

    }


}

