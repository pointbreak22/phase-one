﻿using System;

namespace Value_types__Cloning
{
    internal class Person : ICloneable
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Company Work { get; set; }

        public object
            Clone() //метод для создания нового обьекта с исходным значением так как при простого присвоения копируется ссылка
        {
            var company = new Company {Name = Work.Name}; // создание ссылки на обьект для глубокого копирования
            return new Person {Name = Name, Age = Age, Work = company}; //поверхосное копирование, кроме Work
            //  return this.MemberwiseClone();   //для упрощения
        }
    }

    internal class Company
    {
        public string Name { get; set; }
    }
}