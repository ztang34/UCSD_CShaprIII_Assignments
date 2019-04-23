using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            ReflectionsTest();
            Console.ReadLine();
        }

        static void ReflectionsTest()
        {
            Assembly asm = Assembly.Load("SharedLib");
            Console.WriteLine(asm);
            PrintModules(asm);
        }

        static void PrintModules(Assembly asm)
        {
            Module[] modules = asm.GetModules();
            foreach(Module m in modules)
            {
                Console.WriteLine($" Module: {m.Name}");
            }
        }
    }
}
