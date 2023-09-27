using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateProject
{
    public delegate string DelegateName(string name);
    class User
    {
        public string name;

        public User()
        {
            
        }

        public string ConvertToUpper(string str)
        {
            return str.ToUpper();
        }
        public string ConvertToLower(string str)
        {
            return str.ToLower();
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            User u1 = new User();
            Console.WriteLine("Enter Name");
            string str=Console.ReadLine();
            DelegateName DN = new DelegateName(u1.ConvertToUpper);
            DN += new DelegateName(u1.ConvertToLower);

            Delegate[] list =DN.GetInvocationList();
            foreach(Delegate d in list)
            {
                Console.WriteLine(DN.Method);
                string result = Convert.ToString(d.DynamicInvoke(str));
                Console.WriteLine(result);

            }
           /* string str2=DN.Invoke(str);
            Console.WriteLine(str2);*/

        }
    }
}
