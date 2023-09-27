using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateProject
{
    public delegate void MyDelegate1();
    public class Student1
    {
        public event MyDelegate pass;
        public event MyDelegate fail;

        public void AcceptPercentage(int per)
        {
            if (per < 40)
            {
                fail();
            }
            else
            {
                pass();
            }
        }

    }
    internal class ExampleofAnonymouseMethod
    {
        public static void Main(string[] args)
        {
            try
            {
                Student1 stud = new Student1();


                stud.fail += delegate () { Console.WriteLine("You are Fail"); };
                stud.pass += delegate () { Console.WriteLine("You are pass"); };

                stud.AcceptPercentage(30);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }
    }
}
