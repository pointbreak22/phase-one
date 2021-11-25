using System;
using System.Linq;
using System.Reflection;

namespace Reflection
{
    internal static class Program
    {
        private static string PrintObjectProperties(object ob) //Рефлексия
        {
            if (ob == null) throw new ArgumentNullException(nameof(ob), "Object is null" + nameof(ob));
            var getty = ob.GetType(); // получаем тип
            Console.WriteLine("Обьект: " + getty);
            var properties =
                getty.GetProperties(BindingFlags.Public |
                                    BindingFlags
                                        .Instance); //  получаем все свойства, не статические (noтpublick на приваченные)
            var valueSAreaOfRectangles = properties.Select(x => $"{x.Name} : {x.GetValue(ob)}");
            var fieldsets =
                getty.GetFields(BindingFlags.NonPublic | BindingFlags.Instance); //получаем все не публичные поля
            var valuesFields = fieldsets.Select(x => $"{x.Name} : {x.GetValue(ob)}");
            var methods = getty.GetMethods(); //получение методов
            var getMethods = methods.Select(x => $"{x.Name} -тип метода> {x.ReturnType.Name}");
            var constructors = getty.GetConstructors(); //получение конструкторов
            var valuesGetMethods = constructors.Select(x =>
                $" \n {x.Name} - параметры: {string.Join(",", x.GetParameters().Select(y => $"{y.ParameterType.Name}-{y.Name}"))}");
            return "Cвойства: " + string.Join(", \n", valueSAreaOfRectangles) + "\n Поля: " +
                   string.Join(", \n", valuesFields) + "\n Методы: " + string.Join(", \n", getMethods) +
                   "\n Конструкторы: " + string.Join(", \n", valuesGetMethods); // формируем строку
        }

        private static void Main()
        {
            var user = new User("Cерафим", 11);
            Console.WriteLine(PrintObjectProperties(user));
            Console.ReadLine();
        }
    }
}