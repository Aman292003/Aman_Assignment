using SimpleCRUD.Models;
using SimpleCRUD.Repositories;
namespace SimpleCRUD
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var northwindEntities = new NorthWindContext();
            var newproduct = new CustomProduct
            {
                Name = "super-widget",
                Price = 89.54M,
                Stock = 23
            };
            NorthWindContext cnt = new NorthWindContext();
            CustumerProductrepo obj = new CustumerProductrepo(cnt);
            await obj.AddAsync(newproduct);
            await obj.SaveChangesAsync();

            var toupdate = await obj.GetByIdAsync(1);
            if (toupdate != null)
            {
                toupdate.Price = 34.67M;
                toupdate.Stock = 60;
                await obj.UpdateAsync(toupdate);
                await obj.SaveChangesAsync();
            }
            var all = await obj.GetAllAsync();
            Console.WriteLine("\n All Products");
            foreach(var p in all)
            {
                Console.WriteLine($"{p.Id}--{p.Name}--{p.Price}");
            }


        }
    }
}
