using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace ORM_Dapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json")
                            .Build();

            string connString = config.GetConnectionString("DefaultConnection");

            IDbConnection conn = new MySqlConnection(connString);

            #region Department Section
            //var departmentRepo = new DapperDepartmentRepository(conn);

            //departmentRepo.InsertDepartment("New Department");

            //var departments = departmentRepo.GetAllDepartments();

            //foreach (var department in departments)
            //{
            //    Console.WriteLine(department.DepartmentID);
            //    Console.WriteLine(department.Name);
            //    Console.WriteLine(department.DepartmentID);
            //    Console.WriteLine(department.DepartmentID);
            //}
            #endregion

            var productRepository = new DapperProductRepository(conn);

            var productToUpdate = productRepository.GetProduct(940);
            productToUpdate.Name = "UPDATE PASSED";
            productToUpdate.Price = 9.99;
            productToUpdate.CatergoryID= 5;
            productToUpdate.OnSale = false;
            productToUpdate.StockLevel = 23;

            productRepository.UpdateProduct(productToUpdate);

            var products = productRepository.GetAllProducts();

            foreach (var product in products)
            {
                Console.WriteLine(product.ProductID);
                Console.WriteLine(product.Name);
                Console.WriteLine(product.Price);
                Console.WriteLine(product.CatergoryID);
                Console.WriteLine(product.OnSale);
                Console.WriteLine(product.StockLevel);
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}