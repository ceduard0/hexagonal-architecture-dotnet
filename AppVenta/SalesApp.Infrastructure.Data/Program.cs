using System;
using SalesApp.Infrastructure.Data.Context;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("SalesApp.Infrastructure.Data");
Console.WriteLine("Creating the database");
SaleContext db = new SaleContext();
db.Database.EnsureCreated();
Console.WriteLine("The database was created");


