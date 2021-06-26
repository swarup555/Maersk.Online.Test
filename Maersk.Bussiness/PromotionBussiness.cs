using Maersk.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maersk.Bussiness
{
    public static class PromotionBussiness
    {

        public static int count = 0;

        public static Dictionary<string, double> GenerateInvoice(string[] product, int[] quantity)
        {
            Dictionary<string, int> obprs = new Dictionary<string, int>();
            for (int k = 0; k < product.Length; k++)
            {
                obprs.Add(product[k], quantity[k]);
            }
            Dictionary<string, double> result = new Dictionary<string, double>();
            string[] response = Getdata(product).OrderByDescending(aux => aux.Length).ToArray();
            foreach (var item in response)
            {

                var promotions = GetActivePromotins().Where(x => x.ProductName.SequenceEqual(item.ToCharArray().Select(c => c.ToString()).ToArray().ToList())).FirstOrDefault();
                if (promotions != null)
                {
                    if (promotions.ProductName.Count > 1)
                    {
                        var prodqty = promotions.ProductName.Select(k => obprs[k]).Min();
                        for (int i = 0; i < promotions.ProductName.Count; i++)
                        {
                            double totalprice = 0;
                            if (i == promotions.ProductName.Count - 1)
                            {
                                while (prodqty >= promotions.Quantity)
                                {
                                    prodqty = prodqty - promotions.Quantity;
                                    obprs[promotions.ProductName[i]] = obprs[promotions.ProductName[i]] - promotions.Quantity;
                                    totalprice += promotions.Price;
                                    if (result.ContainsKey(promotions.ProductName[i]))
                                    {
                                        result[promotions.ProductName[i]] = totalprice;
                                    }
                                    else
                                    {
                                        result.Add(promotions.ProductName[i], totalprice);
                                    }
                                }
                            }
                            else
                            {
                                obprs[promotions.ProductName[i]] = obprs[promotions.ProductName[i]] - prodqty;
                                if (result.ContainsKey(promotions.ProductName[i]))
                                {
                                    result[promotions.ProductName[i]] = totalprice;
                                }
                                else
                                {
                                    result.Add(promotions.ProductName[i], totalprice);
                                }
                            }
                        }
                    }
                    else
                    {
                        var prodqty = promotions.ProductName.Select(k => obprs[k]).Min();
                        double totalprice = 0;
                        while (prodqty >= promotions.Quantity)
                        {
                            prodqty = prodqty - promotions.Quantity;
                            obprs[promotions.ProductName[0]] = obprs[promotions.ProductName[0]] - promotions.Quantity;
                            totalprice += promotions.Price;
                            if (result.ContainsKey(promotions.ProductName[0]))
                            {
                                result[promotions.ProductName[0]] = totalprice;
                            }
                            else
                            {
                                result.Add(promotions.ProductName[0], totalprice);
                            }
                        }
                    }
                }

            }
            double total = 0;
            for (int i = 0; i < obprs.Count; i++)
            {
                if (obprs[obprs.Keys.ElementAt(i)] != 0)
                {
                    var products = GetProducts().Where(x => x.ProductName == obprs.Keys.ElementAt(i)).FirstOrDefault();
                    if (result.ContainsKey(obprs.Keys.ElementAt(i)))
                    {
                        result[obprs.Keys.ElementAt(i)] = result[obprs.Keys.ElementAt(i)] + (obprs[obprs.Keys.ElementAt(i)] * products.Price);
                    }
                    else
                    {
                        result.Add(obprs.Keys.ElementAt(i), obprs[obprs.Keys.ElementAt(i)] * products.Price);
                    }

                }
                total += result[obprs.Keys.ElementAt(i)];
            }
            result.Add("Total", total);
            return result;
        }
        public static string[] Getdata(string[] arr)
        {
            count = arr.Length;
            return Combination(string.Join("", arr));
        }
        public static string[] Combination(string str)
        {
            if (string.IsNullOrEmpty(str))
                throw new ArgumentException("Invalid input");
            if (str.Length == 1)
                return new string[] { str };
            char c = str[str.Length - 1];
            string[] returnArray = Combination(str.Substring(0, str.Length - 1));
            List<string> finalArray = new List<string>();
            foreach (string s in returnArray)
                finalArray.Add(s);
            finalArray.Add(c.ToString());
            foreach (string s in returnArray)
            {
                finalArray.Add(s + c);

            }
            Array.Sort(finalArray.ToArray());

            return finalArray.Distinct().ToArray();
        }
        public static List<Product> GetProducts()
        {
            List<Product> objp = new List<Product>();
            Product P1 = new Product();
            P1.ProductName = "A";
            P1.Price = 50;
            objp.Add(P1);
            Product P2 = new Product();
            P2.ProductName = "B";
            P2.Price = 30;
            objp.Add(P2);
            Product P3 = new Product();
            P3.ProductName = "C";
            P3.Price = 20;
            objp.Add(P3);
            Product P4 = new Product();
            P4.ProductName = "D";
            P4.Price = 10;
            objp.Add(P4);
            return objp;
        }
        public static List<ActivePromotins> GetActivePromotins()
        {
            List<ActivePromotins> objp = new List<ActivePromotins>();
            ActivePromotins P1 = new ActivePromotins();
            P1.ProductName = new List<string>() { "A" };
            P1.Quantity = 3;
            P1.Price = 130;
            objp.Add(P1);
            ActivePromotins P2 = new ActivePromotins();
            P2.ProductName = new List<string>() { "B" };
            P2.Quantity = 2;
            P2.Price = 45;
            objp.Add(P2);
            ActivePromotins P3 = new ActivePromotins();
            P3.ProductName = new List<string>() { "C", "D" };
            P3.Quantity = 1;
            P3.Price = 30;
            objp.Add(P3);
            return objp;
        }
    }
}
