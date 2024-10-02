using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;
using System.Linq;
using System.Threading.Tasks;
using WebApplication9.Controllers; // Specific to your application's controllers
using WebApplication9.Data;
using WebApplication9.Models;


namespace TestProject1;

public class InventoryControllerTests
{
    private readonly InventoryContext _context; // The DbContext used in tests
    private readonly InventoryController _controller; // The controller used in tests

    public InventoryControllerTests()
    {
        // Use an in-memory database for testing
        var dbName = $"InventoryTestDb_{Guid.NewGuid()}"; // Unique name for each execution
        var options = new DbContextOptionsBuilder<InventoryContext>()
            .UseInMemoryDatabase(databaseName: dbName)
            .Options;
        _context = new InventoryContext(options);
        _context.Database.EnsureCreated();
        _controller = new InventoryController(_context);
    }

   [Fact]
    public async Task Index_ReturnsAViewResult_WithAListOfProducts()
    {
        // Arrange & Act
        var result = await _controller.Index();

        // Assert
        var viewResult = Assert.IsType<ViewResult>(result);
        Assert.IsAssignableFrom<IEnumerable<Product>>(viewResult.ViewData.Model);
    }

    [Fact]
    public async Task Details_ReturnsViewWithProduct_WhenIdIsValid()
    {
        var product = new Product { Id = 1, Name = "New Product", Description = "New Description"};
        _context.Add(product);
        await _context.SaveChangesAsync();

        var result = await _controller.Details(1);

        var viewResult = Assert.IsType<ViewResult>(result);
        var model = Assert.IsType<Product>(viewResult.Model);
        Assert.Equal(1, model.Id);
    }

    [Fact]
    public async Task Details_ReturnsNotFound_WhenIdIsInvalid()
    {
        var result = await _controller.Details(999);
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task Create_ValidProduct_RedirectsToIndex()
    {
        var product = new Product { Name = "Valid Product", Price = 100, Description = "Valid description"};

        var result = await _controller.Create(product);

        var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
        Assert.Equal("Index", redirectToActionResult.ActionName);
    }

    [Fact]
    public async Task Create_InvalidProduct_ReturnsView()
    {
        _controller.ModelState.AddModelError("Name", "Required");

        var product = new Product();

        var result = await _controller.Create(product);

        var viewResult = Assert.IsType<ViewResult>(result);
        Assert.IsType<Product>(viewResult.Model);
    }

    [Fact]
    public async Task Edit_ValidProduct_RedirectsToIndex()
    {
        var product = new Product { Id = 1, Name = "Product", Description = "Description"};
        _context.Products.Add(product);
        await _context.SaveChangesAsync();

        var result = await _controller.Edit(1, product);

        var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
        Assert.Equal("Index", redirectToActionResult.ActionName);
    }

    [Fact]
    public async Task Edit_InvalidProductId_ReturnsNotFound()
    {
        var product = new Product { Id = 1, Name = "Product" };

        var result = await _controller.Edit(999, product);
        
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task Delete_Confirmed_RedirectsToIndex()
    {
        var product = new Product { Id = 1, Name = "Product", Description = "Description"};
        _context.Products.Add(product);
        await _context.SaveChangesAsync();

        var result = await _controller.DeleteConfirmed(1);

        var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
        Assert.Equal("Index", redirectToActionResult.ActionName);
    }
}