using LabsApplication.AdoNet;
using LabsApplication.UnitOfWork.Repositories;
using System;

namespace LabsApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string cs = "Server=DESKTOP-9CVRRHV;Database=LabsApplicationDb;Trusted_Connection=True;Encrypt=False;";
            var repo = new OrderRepositoryAdo(cs);

            foreach (var item in repo.List())
            {
                Console.WriteLine(item.Id + " | " + item.CreationTime + " | " +item.CustomerId);
            }
        }
    }
}