using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Serialization
{
    internal class Program
    {
        private static void Main()
        {
            JamesBondClass jbc = new JamesBondClass { CanFly = true, CanSubmerge = false, TheRadio = new Radio { StationPresets = new double[] { 89.3, 105.1, 97.1 }, HasSubWoofers = true } };
            // Сохранить объект в указанном файле в двоичном формате
            SaveBinaryFormat(jbc, "carData.dat");
            LoadFromBinaryFile("carData.dat");
            Console.ReadLine();
        }

        public static void SaveBinaryFormat(JamesBondClass jbc, string fileName)
        {
            if (jbc == null)
            {
                throw new ArgumentNullException("Object is null", nameof(jbc));
            }
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
            using Stream fStream = File.OpenRead(fileName);
            JamesBondClass carFromDisk = (JamesBondClass)binFormat.Deserialize(fStream);
            Console.WriteLine("Вывод при изьятии из файла " + carFromDisk.CanFly.ToString() + " " + carFromDisk.CanSubmerge.ToString() + " " + carFromDisk.TheRadio.StationPresets[0]);
        }
    }
}