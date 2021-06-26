using Maersk.Bussiness;
using Maersk.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maersk
{
    class Program
    {
        public static int count = 0;

        static void Main(string[] args)
        {
            do {
                Console.WriteLine("Enter the Products(Space separated):");
                string[] myarr = Console.ReadLine().Split();
                Console.WriteLine("Enter the Quantity for each Products(Space separated):");
                string[] arr = Console.ReadLine().Split();
                int[] Quantity = Array.ConvertAll(arr, s => int.Parse(s));
                if (myarr.Length != Quantity.Length)
                {
                    Console.WriteLine("Enter Valid input");
                    return;
                }
                var result = PromotionBussiness.GenerateInvoice(myarr, Quantity);
                var list = result.Keys.ToList();
                list.Sort();
                foreach (var key in list)
                {
                    Console.WriteLine("{0}: {1}", key, result[key]);
                }
                Console.WriteLine("Do you want to continue (Y/N)? ");
            } while (Console.ReadKey().KeyChar == 'Y');

            Console.ReadLine();
        }
    }
}
