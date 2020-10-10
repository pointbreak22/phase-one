using System;
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
                throw new ArgumentNullException("Object is null", nameof(ob));
            }
            var gettype = ob.GetType(); // получаем тип
            Console.WriteLine("Обьект: " + gettype);
            var getproperties = gettype.GetProperties(BindingFlags.Public | BindingFlags.Instance); //  получаем все свойства, не статические (noтpublick на приваченные)
            var valuesproperties = getproperties.Select(x => $"{x.Name} : {x.GetValue(ob)}"); // перебираем все  свойства и описываем формат сохранения в строку
            var getfields = gettype.GetFields(BindingFlags.NonPublic | BindingFlags.Instance); //получаем все не публичные поля
            var valuesfields = getfields.Select(x => $"{x.Name} : {x.GetValue(ob)}");
            var getmethods = gettype.GetMethods(); //получение методов
            var valuesmethods = getmethods.Select(x => $"{x.Name} -тип метода> {x.ReturnType.Name}");
            var getconstructors = gettype.GetConstructors(); //получение конструкторов
            var valuesconstructors = getconstructors.Select(x => $" \n {x.Name} - параметры: {string.Join(",", x.GetParameters().Select(y => $"{y.ParameterType.Name}-{y.Name}"))}");
            return "Cвойства: " + string.Join(", \n", valuesproperties) + "\n Поля: " + string.Join(", \n", valuesfields) + "\n Методы: " + string.Join(", \n", valuesmethods) + "\n Конструкторы: " + string.Join(", \n", valuesconstructors); // формируем строку
        }

        private static void Main(string[] args)
        {
            User user = new User("Cерафим", 11);
            Console.WriteLine(PrintObjectProperties(user));
            Console.ReadLine();
        }
    }
}