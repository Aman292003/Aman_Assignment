using CodeFirstEFdemo;
using CodeFirstEFdemo.Data;
using CodeFirstEFdemo.Models;
using Microsoft.EntityFrameworkCore;

var context = new AddDbContext();
//var electronics = new Category
//{
//    Name = "Electronics"
//};
////context.categories.Add(electronics);
////await context.SaveChangesAsync();

//context.AddRange(
//    new Product { Name = "Laptop", Price = 999.99M, category = electronics },
//   new Product { Name = "Mouse", Price = 699.99M, category = electronics }

//);
//await context.SaveChangesAsync();

//var laptop = await context.products.FirstAsync(p => p.Name == "laptop");
//laptop.Price = 599.99m;
//await context.SaveChangesAsync();

//context.products.Remove(laptop);
//await context.SaveChangesAsync();

//var authors = await context.author.Include(c => c.courses).ToListAsync();

//foreach(var au in authors)
//{
//    Console.WriteLine($" Author : {au.Name}");
//    foreach(var course in au.courses)
//    {
//        Console.WriteLine($"{course.Title}--{course.Description}--{course.level}");
//    }
//}

//IProductRepository ob = new ProductRepository(context);
//var newproduct = new Product { Name = "SmartPhone", Price = 549.99M, CategoryId = 5};
//await ob.AddAsync(newproduct);

//var toupdate = context.products
//                      .FirstOrDefault(p => p.Id == 2);
//if (toupdate != null)
//{
//    toupdate.Price = 999.99M;
//    toupdate.Name = "Phone";
//    await ob.UpdateAsync(toupdate);
//    Console.WriteLine("THE PRODUCT IS UPDATED");
//}
IProductRepository obj2 = new ProductRepo(context);
var newProd = new Product
{
    Name = "Tablet",
    Price = 233.45M,
    CategoryId = 3
};
await obj2.AddAsync(newProd);



