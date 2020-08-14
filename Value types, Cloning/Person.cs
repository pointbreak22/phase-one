using System;
using System.Collections.Generic;
using System.Text;

namespace ValueTypesCloning
{
    class Person : ICloneable
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Company Work { get; set; }
        public object Clone()  //метод для создания нового обьекта с исходным значением так как при простого присвоения копируется ссылка
        {
            Company company = new Company { Name = this.Work.Name }; // создание ссылки на обьект для глубокого копирования
            return new Person { Name = this.Name, Age = this.Age, Work = company };  //поверхосное копирование, кроме Work
                                                                                     //  return this.MemberwiseClone();   //для упрощения
        }
    }
    class Company
    {
        public string Name { get; set; }
    }
}
