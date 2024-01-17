using LatihanDapper.DbContext;
using LatihanDapper.Entity;
using LatihanDapper.Repository;
using Microsoft.Extensions.Configuration;

internal class Program
{
    private static IConfigurationRoot Configuration;
    private static void BuildConfiguration()
    {
        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

        Configuration = builder.Build();

        Console.WriteLine(Configuration.GetConnectionString("NorthWindDS"));
    }
    public static void Main(string[] args)
    {
        BuildConfiguration();
        var adoDbContext = new AdoDbContext(Configuration.GetConnectionString("NorthWindDS"));
        var dapper = new DapperDbContext(Configuration.GetConnectionString("NorthWindDS"));

        IRepositoryBase<Supplier> supplierRepository = new SupplierRepository(dapper, adoDbContext);

        //Create/Save Data
        /*var supp = new Supplier()
        {
            CompanyName = "Test",
            ContactName = "Test",
            ContactTitle = "Test",
        };

        var data = supplierRepository.Save(supp);

        Console.WriteLine(data.ToString());*/

        //Update 
        /*var supp = new Supplier()
        {
            SupplierId = 31,
            CompanyName = "Code Academy",
            ContactName = "Test",
            ContactTitle = "Test",
        };

        supplierRepository.Update(supp);*/

        //Delete 
        /*var supp = new Supplier()
        {
            SupplierId = 32,
            CompanyName = "Test",
            ContactName = "Test",
            ContactTitle = "Test",
        };

        supplierRepository.Delete(supp);*/

        //FindById
        /*var data = supplierRepository.FindById(1);
        foreach (Supplier supplier in data)
        {
            Console.WriteLine(supplier.ToString());
        }*/

        //FindAll 

        var data = supplierRepository.FindAll();
        foreach (var item in data)
        {
            Console.WriteLine(item.ToString());
        }

    }
}
