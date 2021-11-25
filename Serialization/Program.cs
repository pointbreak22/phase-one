using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Serialization
{
    internal class Program
    {
        private static void Main()
        {
            var jbc = new JamesBondClass
            {
                CanFly = true, CanSubmerge = false,
                TheRadio = new Radio {StationPresets = new[] {89.3, 105.1, 97.1}, HasSubWoofers = true}
            };
            // Сохранить объект в указанном файле в двоичном формате
            SaveBinaryFormat(jbc, "carData.dat");
            LoadFromBinaryFile("carData.dat");
            Console.ReadLine();
        }

        public static void SaveBinaryFormat(JamesBondClass jbc, string fileName)
        {
            if (jbc == null) throw new ArgumentNullException(nameof(jbc), "Object is null " + nameof(jbc));
            var binFormat = new BinaryFormatter();
            using (Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                binFormat.Serialize(fStream, jbc);
            }

            Console.WriteLine("--> Сохранение объекта в Binary format");
        }

        public static void LoadFromBinaryFile(string fileName)
        {
            var binFormat = new BinaryFormatter();
            using Stream fStream = File.OpenRead(fileName);
            {
                var carFromDisk = (JamesBondClass) binFormat.Deserialize(fStream);
                Console.WriteLine("Вывод при изьятии из файла " + carFromDisk.CanFly + " " + carFromDisk.CanSubmerge +
                                  " " + carFromDisk.TheRadio.StationPresets[0]);
            }
        }
    }
}