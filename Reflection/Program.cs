using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Reflection
{
    internal class Program
    {
        public static string PrintObjectProperties(object ob) //Рефлексия
        {
            if (ob == null)
            {
                throw new ArgumentNullException(nameof(ob), "Object is null" + nameof(ob));
            }
            Type getty = ob.GetType(); // получаем тип
            Console.WriteLine("Обьект: " + getty);
            PropertyInfo[] properties = getty.GetProperties(BindingFlags.Public | BindingFlags.Instance); //  получаем все свойства, не статические (noтpublick на приваченные)
            IEnumerable<string> valueSAreaOfRectangles = properties.Select(x => $"{x.Name} : {x.GetValue(ob)}");
            FieldInfo[] fieldsets = getty.GetFields(BindingFlags.NonPublic | BindingFlags.Instance); //получаем все не публичные поля
            IEnumerable<string> valuesFields = fieldsets.Select(x => $"{x.Name} : {x.GetValue(ob)}");
            MethodInfo[] methods = getty.GetMethods(); //получение методов
            IEnumerable<string> getMethods = methods.Select(x => $"{x.Name} -тип метода> {x.ReturnType.Name}");
            ConstructorInfo[] constructors = getty.GetConstructors(); //получение конструкторов
            IEnumerable<string> valuesGetMethods = constructors.Select(x => $" \n {x.Name} - параметры: {string.Join(",", x.GetParameters().Select(y => $"{y.ParameterType.Name}-{y.Name}"))}");
            return "Cвойства: " + string.Join(", \n", valueSAreaOfRectangles) + "\n Поля: " + string.Join(", \n", valuesFields) + "\n Методы: " + string.Join(", \n", getMethods) + "\n Конструкторы: " + string.Join(", \n", valuesGetMethods); // формируем строку
        }

        private static void Main()
        {
            User user = new User("Cерафим", 11);
            Console.WriteLine(PrintObjectProperties(user));
            Console.ReadLine();
        }
    }
}