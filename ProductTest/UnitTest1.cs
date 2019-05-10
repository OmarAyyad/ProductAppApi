using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.PlatformAbstractions;
using ProductAppApi;
using ProductAppApi.Controllers;
using ProductAppApi.Persistance;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using Xunit;

namespace ProductTest
{

    public class UnitTest1
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public UnitTest1()
        {
            var asm = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;
            var path = PlatformServices.Default.Application.ApplicationBasePath;
            var contentPath = Path.GetFullPath(Path.Combine(path, $@"\Users\DELL\source\repos\ProductAppApi\ProductAppApi"));

            this._server = new TestServer(new WebHostBuilder()
               .UseContentRoot(contentPath)
               .UseStartup<Startup>()
               .UseEnvironment("Development"));

            this._client = this._server.CreateClient();
        }

        [Fact]
        public async Task CanInvokeController()
        {
            var request = new HttpRequestMessage(new HttpMethod("Get"), "/api/product/");

            var response = await _client.SendAsync(request);

            response.EnsureSuccessStatusCode();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        }



    }

    //public HttpClient Client { get; private set; }

    //public UnitTest1()
    //{
    //     var server = new TestServer(new WebHostBuilder()
    //        .UseEnvironment("Development")
    //        .UseStartup<Startup>());

    //     Client = server.CreateClient();
    //}


    //[Fact]
    //public async Task Test_Get_All()
    //{

    //        var request = new HttpRequestMessage(new HttpMethod("Get"),"/api/product/");

    //        var response = await Client.SendAsync(request);

    //        response.EnsureSuccessStatusCode();

    //        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

    //}


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
    //}
}
