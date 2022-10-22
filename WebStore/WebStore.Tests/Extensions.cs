using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using WebStore.DAL.DatabaseContext;
using WebStore.Model.Models;

namespace WebStore.Tests;
public static class Extensions
{
    // Create sample data
    public static async void SeedData(this IServiceCollection services)
    {
        var serviceProvider = services.BuildServiceProvider();
        var dbContext = serviceProvider.GetRequiredService<WSDbContext>();
        var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
        var roleManager = serviceProvider
         .GetRequiredService<RoleManager<IdentityRole<int>>>();
        // other seed data ...
        //Suppliers
        var supplier1 = new Supplier()
        {
            Id = 1,
            FirstName = "Adam",
            LastName = "Bednarski",
            UserName = "supp1@eg.eg",
            Email = "supp1@eg.eg",
            RegistrationDate = new DateTime(2010, 1, 1),
        };
        await userManager.CreateAsync(supplier1, "User1234");
        //Categories
        var category1 = new Category()
        {
            Id = 1,
            Name = "Computers",
            Tag = "#computer"
        };
        await dbContext.AddAsync(category1);

        //Products
        var p1 = new Product()
        {
            Id = 1,
            CategoryId = category1.Id,
            SupplierId = supplier1.Id,
            Description = "Bardzo praktyczny monitor 32 cale",
            ImageBytes = new byte[] { 0xff, 0xff, 0xff, 0x80 },
            Name = "Monitor Dell 32",
            Price = 1000,
            Weight = 20,
        };
        await dbContext.AddAsync(p1);

        var p2 = new Product()
        {
            Id = 2,
            CategoryId = category1.Id,
            SupplierId = supplier1.Id,
            Description = "Precyzyjna mysz do pracy",
            ImageBytes = new byte[] { 0xff, 0xff, 0xff, 0x70 },
            Name = "Mysz Logitech",
            Price = 500,
            Weight = 0.5f,
        };
        await dbContext.AddAsync(p2);

        // orders
        var o1 = new Order()
        {
            Id = 1,
            TotalAmount = 1,
            TrackingNumber = 1233,
            DeliveryDate = new DateTime(2010, 1, 1),
            OrderDate = new DateTime(2010, 1, 2),
            StationaryStoreId = 1,
            CustomerId = 1,
            Invoiceid = 1
        };
        await dbContext.AddAsync(o1);

        var o2 = new Order()
        {
            Id = 2,
            TotalAmount = 3,
            TrackingNumber = 1244,
            DeliveryDate = new DateTime(2010, 1, 1),
            OrderDate = new DateTime(2010, 1, 2),
            StationaryStoreId = 1,
            CustomerId = 1,
            Invoiceid = 1
        };
        await dbContext.AddAsync(o2);
        // save changes
        await dbContext.SaveChangesAsync();
    }
}