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
            Console.WriteLine("DAL");
        }
    }
}

//TODO: check all queries
//TODO: use functions and stored procedures
//TODO: async/await
//TODO: ado | make it use a single connection for all repos