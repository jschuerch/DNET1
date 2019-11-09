using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Playground
{
    public class Program
    {
        static void Main(string[] args)
        {
            object o = new Test();
            CallHello(o);

            Console.ReadKey();
        }

        public static void CallHello(object o)
        {
            Type tp = o.GetType();
            Console.WriteLine(tp.Equals(typeof(Test)));

            MethodInfo mt = tp.GetMethod("Hello");

            mt.Invoke(o, null);

            mt = tp.GetMethod("HelloParam");
            mt.Invoke(o, new object[] {"Arschloch"});

            /*mt = tp.GetMethod("PersonalBubble");

            mt.Invoke(o, null);*/
        }
    }


    public class Test
    {
        public void Hello()
        {
            Console.WriteLine("Hello du");
        }

        public void HelloParam(string test)
        {
            Console.WriteLine("Hello du " + test);
        }

        private void PersonalBubble()
        {
            Console.WriteLine("private method");
        }
    }
}
