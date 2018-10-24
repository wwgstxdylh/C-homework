using System;
using System.Runtime.Serialization;

namespace program1
{
    class Program
    {
        static void Main(string[] args)
        {

            Order myOrder = new Order("Tom", "Order1");
            myOrder.AddDetail("apple", 5, 5);
            myOrder.AddDetail("banana", 3, 3);
            Order newOrder = new Order("Jordan", "Order2");
            newOrder.AddDetail("pear", 6, 4);
            OrderService service = new OrderService();
            service.AddOrder(myOrder);
            service.AddOrder(newOrder);
            service.Export();
            OrderService newService = OrderService.Import("s.xml");
            newService.Export("g.xml");
        }
    }
}

class CanNotFindOrder : ApplicationException
{
    public CanNotFindOrder(String message) : base(message) { }
}

class CanNotFindEntry : ApplicationException
{
    public CanNotFindEntry(String message) : base(message) { }
}