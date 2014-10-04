using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebAPIDemo.Models
{
    public class WebAPIDemoContextInitializer : DropCreateDatabaseAlways<WebAPIDemoContext>
    {
        protected override void Seed(WebAPIDemoContext context)
        {
            
            var books = new List<Book>
            {
                new Book() {Name = "War and Peace", Author = "Tolstoy", Price = 19.95m},
                new Book() {Name = "Jane Eyre", Author = "Emily Bronte", Price = 29.15m}
            };

            books.ForEach(b => context.Books.Add(b));
            context.SaveChanges();

            var order = new Order() { Customer = "John Doe", OrderDate = new DateTime(2014, 7, 10) };
            var details = new List<OrderDetail>()
            {
                new OrderDetail(){Book = books[0], Quantity = 1, Order = order}
            };
            context.Orders.Add(order);
            details.ForEach(o => context.OrderDetails.Add(o));
            context.SaveChanges();

            order = new Order() { Customer = "Ward Bell", OrderDate = new DateTime(2014, 7, 12) };
            details = new List<OrderDetail>()
            {
                new OrderDetail() {Book = books[1], Quantity=2, Order = order}
            };
            context.Orders.Add(order);
            details.ForEach(od => context.OrderDetails.Add(od));
            context.SaveChanges();

            base.Seed(context);
        }
    }
}