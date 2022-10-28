using LabsApplication.AdoNet;
using LabsApplication.UnitOfWork.EF;
using LabsApplication.UnitOfWork.EF.Models;
using LabsApplication.UnitOfWork.Repositories;
using Microsoft.EntityFrameworkCore;
using System;

namespace LabsApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string cs = "Server=DESKTOP-9CVRRHV;Database=LabsApplicationDb;Trusted_Connection=True;Encrypt=False;";
            var ob = new DbContextOptionsBuilder();
            ob.UseSqlServer(cs);

            var repo = new AppDbContext(ob.Options);

            //repo.Insert(new CustomerDTO()
            //{
            //    Firstname = "Arnold",
            //    Lastname = "Somebody",
            //    Age = 88,
            //    Country = "USA",
            //    Gender = true,
            //    EmailAddress = "arnold@",
            //    Password = "11111111",
            //    ProfilePicture = null            
            //});
            //foreach (var item in new CustomerDTO[] { repo.Get(2) })
            //{
            //    Console.WriteLine(item.Id);
            //    Console.WriteLine(item.Firstname);
            //    Console.WriteLine(item.Lastname);
            //    Console.WriteLine(item.Age);
            //    Console.WriteLine(item.Country);
            //    Console.WriteLine(item.Gender);
            //    Console.WriteLine(item.EmailAddress);
            //    Console.WriteLine(item.Password);
            //    Console.WriteLine(new String('*', 100));
            //}
            //repo.PaymentMethods.Add(new PaymentMethod { Commission = 0.02, Name = "NovaPay" });
           // repo.SaveChanges();
            //repo.Orders.Add(new Order { CreationTime = DateTime.Now, CustomerId = 1, PaymentMethodId = 1 });
            //repo.SaveChanges();

            foreach (var item in repo.Orders)
            {
                Console.WriteLine(item.Id);
                Console.WriteLine(item.CustomerId);
                Console.WriteLine(item.PaymentMethodId);
                Console.WriteLine(item.CreationTime);
                Console.WriteLine(new String('&', 100));
            }
        }
    }
}