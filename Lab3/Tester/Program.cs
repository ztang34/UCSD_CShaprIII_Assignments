using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Dynamic;

namespace Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting Reflection test...");
            Console.WriteLine();
            ReflectionsTest();
            Console.WriteLine(new string('=', 40));
           
            Console.WriteLine("Starting Person test...");
            Console.WriteLine();
            PersonTest();
            Console.WriteLine(new string('=', 40));
            
            Console.WriteLine("Starting MathStuff test...");
            Console.WriteLine();
            MathStuffTest();
            Console.WriteLine(new string('=', 40));
           
            Console.WriteLine("Starting Custom Attribute test...");
            Console.WriteLine();
            CustomAttributeTest();
            Console.WriteLine();

            Console.WriteLine("Press <ENTER> to quit...");
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
                PrintTypes(m);
            }
        }

        static void PrintTypes (Module mdl)
        {
            Type[] types = mdl.GetTypes();
            foreach(Type t in types)
            {
                Console.WriteLine($"  Type: {t.Name} class");
                PrintMethods(t);
            }
        }

        static void PrintMethods(Type type)
        {
            MethodInfo[] methods = type.GetMethods();
            foreach(MethodInfo m in methods)
            {
                Console.WriteLine($"   Method: {m.Name} returns {m.ReturnType}");
                PrintParameters(m);
            }
        }

        static void PrintParameters(MethodInfo method)
        {
            ParameterInfo[] parameters = method.GetParameters();
            Console.WriteLine("    Parameters:");
            foreach(ParameterInfo p in parameters)
            {
                Console.WriteLine($"     {p.ParameterType} {p.Name}");
            }
        }

        static void PersonTest()
        {
            Assembly asm = Assembly.Load("SharedLib");
            dynamic p1 = asm.CreateInstance("SharedLib.Person");
            p1.LastName = "Smith";
            p1.FirstName = "Jane";
            p1.DOB = DateTime.Parse("12/01/2000");

            Type enumType = asm.GetType("SharedLib.Person+Genders");
            p1.Gender = (dynamic)Enum.Parse(enumType, "Female");

            Console.WriteLine(p1);
        }

        static void MathStuffTest()
        {
            Assembly asm = Assembly.Load("SharedLib");
            Type mathType = asm.GetType("SharedLib.MathStuff");
            var areaMethod = mathType.GetMethod("CircleArea", BindingFlags.Public | BindingFlags.Static);
            double area = (double)areaMethod.Invoke(null, new object[] { 12.34 });
            Console.WriteLine($"Circle area is {area:f3}");
        }

        static void CustomAttributeTest()
        {
            Assembly asm = Assembly.Load("SharedLib");
            Type mathType = asm.GetType("SharedLib.MathStuff");
            Type personType = asm.GetType("SharedLib.Person");
            Type specialType = asm.GetType("SharedLib.SpecialClassAttribute");
            Type studentType = asm.GetType("SharedLib.Student");
            Type swapType = asm.GetType("SharedLib.Swap");

            var attrs_math = mathType.GetCustomAttributes(specialType);

            foreach (dynamic attr in attrs_math)
            {
                Console.WriteLine($"{mathType.Name} has the special class ID of {attr.ID}");
            }

            var attrs_Person = personType.GetCustomAttributes(specialType);

            foreach (dynamic attr in attrs_Person)
            {
                Console.WriteLine($"{personType.Name} has the special class ID of {attr.ID}");
            }

            var attrs_Student = studentType.GetCustomAttributes(specialType);
            foreach (dynamic attr in attrs_Student)
            {
                Console.WriteLine($"{studentType.Name} has the special class ID of {attr.ID}");
            }

            var attrs_Swap = swapType.GetCustomAttributes(specialType);
            foreach (dynamic attr in attrs_Swap)
            {
                Console.WriteLine($"{swapType.Name} has the special class ID of {attr.ID}");
            }


        }
    }
}
