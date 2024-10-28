using Microsoft.AspNetCore.Mvc;
using UnitOfWorkPatternDemo.Models;
using UnitOfWorkPatternDemo.Repositories.Abstractions;

namespace UnitOfWorkPatternDemo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductsController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        var products = await _unitOfWork.Products.GetAllAsync();
        return Ok(products);
    }

    [HttpPost]
    public async Task<IActionResult> AddProduct(Product product)
    {
        await _unitOfWork.Products.AddAsync(product);
        await _unitOfWork.CompleteAsync();
        return Ok(product);
    }
}