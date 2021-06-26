using System;
using System.Collections.Generic;
using System.Linq;
using Maersk.Bussiness;
using Maersk.DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Maersk.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCase1()
        {
            string[] product = new string[] {"A","B","C" };
            int[] Quantity = new int[] { 1, 1, 1 };
            var result = PromotionBussiness.GenerateInvoice(product, Quantity);
            Assert.AreEqual(50, result.Where(x=>x.Key=="A").FirstOrDefault().Value);
            Assert.AreEqual(30, result.Where(x => x.Key == "B").FirstOrDefault().Value);
            Assert.AreEqual(20, result.Where(x => x.Key == "C").FirstOrDefault().Value);
            Assert.AreEqual(100, result.Where(x => x.Key == "Total").FirstOrDefault().Value);
        }
        [TestMethod]
        public void TestCase2()
        {
            string[] product = new string[] { "A", "B", "C" };
            int[] Quantity = new int[] { 5, 5, 1 };
            var result = PromotionBussiness.GenerateInvoice(product, Quantity);
            Assert.AreEqual(230, result.Where(x => x.Key == "A").FirstOrDefault().Value);
            Assert.AreEqual(120, result.Where(x => x.Key == "B").FirstOrDefault().Value);
            Assert.AreEqual(20, result.Where(x => x.Key == "C").FirstOrDefault().Value);
            Assert.AreEqual(370, result.Where(x => x.Key == "Total").FirstOrDefault().Value);
        }
        [TestMethod]
        public void TestCase3()
        {
            string[] product = new string[] { "A", "B", "C", "D" };
            int[] Quantity = new int[] { 3, 5, 1, 1 };
            var result = PromotionBussiness.GenerateInvoice(product, Quantity);
            Assert.AreEqual(130, result.Where(x => x.Key == "A").FirstOrDefault().Value);
            Assert.AreEqual(120, result.Where(x => x.Key == "B").FirstOrDefault().Value);
            Assert.AreEqual(0, result.Where(x => x.Key == "C").FirstOrDefault().Value);
            Assert.AreEqual(30, result.Where(x => x.Key == "D").FirstOrDefault().Value);
            Assert.AreEqual(280, result.Where(x => x.Key == "Total").FirstOrDefault().Value);
        }
        [TestMethod]
        public void TestCase4()
        {
            string[] product = new string[] { "A", "B", "C", "D" };
            int[] Quantity = new int[] { 3, 4, 1, 2 };
            var result = PromotionBussiness.GenerateInvoice(product, Quantity);
            Assert.AreEqual(130, result.Where(x => x.Key == "A").FirstOrDefault().Value);
            Assert.AreEqual(90, result.Where(x => x.Key == "B").FirstOrDefault().Value);
            Assert.AreEqual(0, result.Where(x => x.Key == "C").FirstOrDefault().Value);
            Assert.AreEqual(40, result.Where(x => x.Key == "D").FirstOrDefault().Value);
            Assert.AreEqual(260, result.Where(x => x.Key == "Total").FirstOrDefault().Value);
        }
        [TestMethod]
        public void TestCase5()
        {
            string[] product = new string[] { "A", "B", "D" };
            int[] Quantity = new int[] { 3, 4, 2};
            var result = PromotionBussiness.GenerateInvoice(product, Quantity);
            Assert.AreEqual(130, result.Where(x => x.Key == "A").FirstOrDefault().Value);
            Assert.AreEqual(90, result.Where(x => x.Key == "B").FirstOrDefault().Value);
            Assert.AreEqual(20, result.Where(x => x.Key == "D").FirstOrDefault().Value);
            Assert.AreEqual(240, result.Where(x => x.Key == "Total").FirstOrDefault().Value);
        }
        [TestMethod]
        public void TestCase6()
        {
            string[] product = new string[] { "A", "B", "D" };
            int[] Quantity = new int[] { 6, 6, 4 };
            var result = PromotionBussiness.GenerateInvoice(product, Quantity);
            Assert.AreEqual(260, result.Where(x => x.Key == "A").FirstOrDefault().Value);
            Assert.AreEqual(135, result.Where(x => x.Key == "B").FirstOrDefault().Value);
            Assert.AreEqual(40, result.Where(x => x.Key == "D").FirstOrDefault().Value);
            Assert.AreEqual(435, result.Where(x => x.Key == "Total").FirstOrDefault().Value);
        }
        [TestMethod]
        public void TestCase7()
        {
            string[] product = new string[] { "A", "B","C", "D" };
            int[] Quantity = new int[] { 1, 2, 5,2 };
            var result = PromotionBussiness.GenerateInvoice(product, Quantity);
            Assert.AreEqual(50, result.Where(x => x.Key == "A").FirstOrDefault().Value);
            Assert.AreEqual(45, result.Where(x => x.Key == "B").FirstOrDefault().Value);
            Assert.AreEqual(60, result.Where(x => x.Key == "C").FirstOrDefault().Value);
            Assert.AreEqual(60, result.Where(x => x.Key == "D").FirstOrDefault().Value);
            Assert.AreEqual(215, result.Where(x => x.Key == "Total").FirstOrDefault().Value);
        }
        [TestMethod]
        public void TestCase8()
        {
            string[] product = new string[] { "A", "B", "C", "D" };
            int[] Quantity = new int[] { 4, 5,1,1 };
            var result = PromotionBussiness.GenerateInvoice(product, Quantity);
            Assert.AreEqual(180, result.Where(x => x.Key == "A").FirstOrDefault().Value);
            Assert.AreEqual(120, result.Where(x => x.Key == "B").FirstOrDefault().Value);
            Assert.AreEqual(0, result.Where(x => x.Key == "C").FirstOrDefault().Value);
            Assert.AreEqual(30, result.Where(x => x.Key == "D").FirstOrDefault().Value);
            Assert.AreEqual(330, result.Where(x => x.Key == "Total").FirstOrDefault().Value);
        }
        [TestMethod]
        public void TestCase9()
        {
            string[] product = new string[] { "A", "C", "D" };
            int[] Quantity = new int[] { 2, 3, 5};
            var result = PromotionBussiness.GenerateInvoice(product, Quantity);
            Assert.AreEqual(100, result.Where(x => x.Key == "A").FirstOrDefault().Value);
            Assert.AreEqual(0, result.Where(x => x.Key == "C").FirstOrDefault().Value);
            Assert.AreEqual(110, result.Where(x => x.Key == "D").FirstOrDefault().Value);
            Assert.AreEqual(210, result.Where(x => x.Key == "Total").FirstOrDefault().Value);
        }
        [TestMethod]
        public void TestCase10()
        {
            string[] product = new string[] { "A", "B", "D" };
            int[] Quantity = new int[] { 4, 7, 4 };
            var result = PromotionBussiness.GenerateInvoice(product, Quantity);
            Assert.AreEqual(180, result.Where(x => x.Key == "A").FirstOrDefault().Value);
            Assert.AreEqual(165, result.Where(x => x.Key == "B").FirstOrDefault().Value);
            Assert.AreEqual(40, result.Where(x => x.Key == "D").FirstOrDefault().Value);
            Assert.AreEqual(385, result.Where(x => x.Key == "Total").FirstOrDefault().Value);
        }

    }
}
