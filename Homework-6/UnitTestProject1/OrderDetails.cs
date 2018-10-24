﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using program1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace program1.Tests
{

    [TestClass()]
    public class OrderServiceTests
    {
        [TestMethod()]
        public void AddOrderTest()
        {
            try
            {
                Order order = new Order("wang", "test1");
                OrderService service = new OrderService();
                service.AddOrder(order);
                service.CheckByClient("wang");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Assert.Fail();
            }
        }


        [TestMethod()]
        public void CheckByIdTest()
        {
            Order order = new Order("wang", "test1");
            String id = order.Id;
            OrderService service = new OrderService();
            service.AddOrder(order);
            Assert.IsNotNull(service.CheckById(id));
        }

        [TestMethod()]
        public void CheckByNameTest()
        {
            Order order = new Order("wang", "test1");
            OrderService service = new OrderService();
            service.AddOrder(order);
            Assert.IsNotNull(service.CheckByName("test1"));
        }

        [TestMethod()]
        public void CheckByClientTest()
        {
            Order order = new Order("wang", "test1");
            OrderService service = new OrderService();
            service.AddOrder(order);
            List<Order> list = service.CheckByClient("wang");
            Assert.AreEqual(list.Count, 1);
        }

        [TestMethod()]
        public void CheckOverTenThousandTest()
        {
           
                Order order = new Order("wang", "test1");
                order.AddDetail("phone", 10, 1100);
                Order another = new Order("Tom", "test2");
                order.AddDetail("rice", 1, 1);
                OrderService service = new OrderService();
                service.AddOrder(order);
                service.AddOrder(another);
                List<Order> list = service.CheckOverTenThousand();
                Assert.AreEqual(list[0].Client, "wang");
            
        }
        [TestMethod()]
        public void DeleteByIdTest()
        {
            try
            {
                Order order = new Order("wang", "test1");
                String id = order.Id;
                OrderService service = new OrderService();
                service.AddOrder(order);
                service.DeleteById(id);
                service.CheckByName("test1");
            }
            catch (Exception e)
            {
                Assert.IsTrue(true);
            }
        }

        [TestMethod()]
        public void DeleteByNameTest()
        {
            try
            {
                Order order = new Order("wang", "test1");
                String id = order.Id;
                OrderService service = new OrderService();
                service.AddOrder(order);
                service.DeleteByName("test1");
                service.CheckByName("test1");
            }
            catch (Exception e)
            {
                Assert.IsTrue(true);
            }
        }

        [TestMethod()]
        public void DeleteByClientTest()
        {
            try
            {
                Order order = new Order("wang", "test1");
                String id = order.Id;
                OrderService service = new OrderService();
                service.AddOrder(order);
                service.DeleteByClient("wang");
                service.CheckByName("test1");
            }
            catch (Exception e)
            {
                Assert.IsTrue(true);
            }
        }

        [TestMethod()]
        public void ExportTest()
        {
            Order order = new Order("wang", "test1");
            String id = order.Id;
            OrderService service = new OrderService();
            service.AddOrder(order);
            FileInfo file = service.Export("testForExport.xml");
            Assert.IsTrue(file.Exists);
            file.Delete();
        }

        [TestMethod()]
        public void ImportTest()
        {
            Order order = new Order("wang", "test1");
            String id = order.Id;
            OrderService service = new OrderService();
            service.AddOrder(order);
            FileInfo file = service.Export("testForImport.xml");
            OrderService newService = OrderService.Import("testForImport.xml");
            file.Delete();
            Assert.IsTrue(newService.CheckByName("test1").Id == id);
        }

    }
}