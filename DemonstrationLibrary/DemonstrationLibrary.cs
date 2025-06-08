using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MosaicLibrary;

namespace DemonstrationLibrary
{
    internal class DemonstrationLibrary
    {
        private readonly static ClassLibrary c = new ClassLibrary();

        static void Main(string[] args)
        {
            Console.Write("Введите id типа продукции: ");
            int productTypeId = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите id типа материала: ");
            int materialTypeId = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите количество необходимой продукции: ");
            int productAmount = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите количесвто материала на складе: ");
            int stockAmount = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите параметр 1: ");
            double param1 = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите параметр 2: ");
            double param2 = double.Parse(Console.ReadLine());

            int result = c.CalculateMaterial(productTypeId, materialTypeId, productAmount, stockAmount, param1, param2);
            Console.WriteLine($"Необходимо материала: {result}");
        }

    }
}
