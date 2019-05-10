using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using ProductAppApi;
using ProductAppApi.Controllers;
using ProductAppApi.Persistance;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace ProductTest
{
    public class TestClientProvider
    {
        public HttpClient Client { get; private set; }

        public TestClientProvider()
        {
            var server = new TestServer(new WebHostBuilder().UseStartup<Startup>());

            Client = server.CreateClient();
        }
    }

    public class UnitTest1
    {

        [Fact]
        public async Task Test_Get_All()
        {

            using (var client = new TestClientProvider().Client)
            {
                var response = await client.GetAsync("/api/product");

                response.EnsureSuccessStatusCode();

                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }


        //protected readonly DbContextOptions optionsBuilder;
        //protected readonly ProductContext productContext;
        //protected readonly UnitOfWork uni;



        //public UnitTest1()
        //{
        //var builder = new DbContextOptionsBuilder<ProductContext>()
        // .UseInMemoryDatabase();

        //optionsBuilder = new DbContextOptionsBuilder<ProductContext>().UseSqlServer("server=.;database=ProductDB;Trusted_Connection=True;MultipleActiveResultSets=True;").Options;
        //optionsBuilder = new DbContextOptionsBuilder<ProductContext>().UseInMemoryDatabase( databaseName: "ProductDB").Options;
        //productContext = new ProductContext(optionsBuilder);
        //uni = new UnitOfWork(productContext);

        //}

        //[Fact]
        //public void Test1()
        //{
        //var productController = new ProductController(productContext);
        //var result = productController.Get();
        //Assert.Contains("Cam",result.Value.ToString());
        //var pro = productContext.products.ToListAsync();
        //}


        //[Fact]
        //public void Add_writes_to_database()
        //{
        //    var options = new DbContextOptionsBuilder<ProductContext>()
        //        .UseInMemoryDatabase(databaseName: "ProductDB")
        //        .Options;

        //    // Run the test against one instance of the context
        //    using (var context = new ProductContext(options))
        //    {
        //        var service = new BlogService(context);
        //        service.Add("http://sample.com");
        //    }

        //    // Use a separate instance of the context to verify correct data was saved to database
        //    using (var context = new BloggingContext(options))
        //    {
        //        Assert.AreEqual(1, context.Blogs.Count());
        //        Assert.AreEqual("http://sample.com", context.Blogs.Single().Url);
        //    }
        //}
    }
}
