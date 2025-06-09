using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MosaicLibrary;

namespace DemonstrationLibrary
{
    public class DemonstrationProgram
    {
        private readonly static ClassLibrary c = new ClassLibrary();

        public static void Main(string[] args)
        {
            Console.Write("Введите id типа продукции: ");
            int productTypeId = int.Parse(Console.ReadLine());

            Console.Write("Введите id типа материала: ");
            int materialTypeId = int.Parse(Console.ReadLine());

            Console.Write("Введите количество необходимой продукции: ");
            int productAmount = int.Parse(Console.ReadLine());

            Console.Write("Введите количество продукции на складе: ");
            int stockAmount = int.Parse(Console.ReadLine());

            Console.Write("Введите параметр 1: ");
            int param1 = int.Parse(Console.ReadLine());

            Console.Write("Введите параметр 2: ");
            int param2 = int.Parse(Console.ReadLine());

            int result = c.CalculateMaterial(productTypeId, materialTypeId, productAmount, stockAmount, param1, param2);
            Console.Write($"Необходимо материала: {result}");
        }
    }
}
