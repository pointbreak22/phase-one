﻿using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Xml.Serialization;


namespace Serialization
{
    [Serializable]
    public class Radio
    {
        public bool HasTweeters { get; set; }
        public bool HasSubWoofers { get; set; }
        public double[] StationPresets { get; set; }
        [NonSerialized]
        public string radioID = "XF-552RF6";
    }
    [Serializable]
    public class Car
    {
        public Radio TheRadio { get; set; }
        public bool IsHatchBack { get; set; }
    }

    [Serializable]
    public class JamesBondClass : Car
    {
        public bool CanFly { get; set; }
        public bool CanSubmerge { get; set; }
    }

    class Program
    {
        static void Main()
        {
            JamesBondClass jbc = new JamesBondClass { CanFly = true, CanSubmerge = false, TheRadio = new Radio { StationPresets = new double[] { 89.3, 105.1, 97.1 }, HasSubWoofers = true } };
            // Сохранить объект в указанном файле в двоичном формате
            SaveBinaryFormat(jbc, "carData.dat");
            LoadFromBinaryFile("carData.dat");
            Console.ReadLine();
        }
        public static void SaveBinaryFormat(JamesBondClass jbc, string fileName)
        {
            BinaryFormatter binFormat = new BinaryFormatter();
            using (Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                binFormat.Serialize(fStream, jbc);
            }
            Console.WriteLine("--> Сохранение объекта в Binary format");
        }
        public static void LoadFromBinaryFile(string fileName)
        {
            BinaryFormatter binFormat = new BinaryFormatter();
            using (Stream fStream = File.OpenRead(fileName))
            {
                JamesBondClass carFromDisk = (JamesBondClass)binFormat.Deserialize(fStream);
                Console.WriteLine("Вывод при изьятии из файла " + carFromDisk.CanFly.ToString() + " " + carFromDisk.CanSubmerge.ToString() + " " + carFromDisk.TheRadio.StationPresets[0]);

            }
        }
    }
}