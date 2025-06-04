using AnalisisSistemasAPI.Interfaces;
using AnalisisSistemasAPI.Models.DataBase;
using AnalisisSistemasAPI.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AnalisisSistemasAPI.Controllers
{    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        IProductsRepository repository;

        public ProductController(IProductsRepository repository)
        {
            this.repository = repository;  
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            try
            {
                var products = repository.GetProducts();
                return Ok(products);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            try
            {
                var product = repository.GetProduct(id);
                
                if (product == null)
                    return NotFound($"Producto con ID {id} no encontrado");
                    
                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult InsertProduct([FromBody] ProductCreateDTO productDTO)
        {
            try
            {
                // Mapear el DTO a la entidad Product
                var product = new Product
                {
                    CodeBar = productDTO.CodeBar,
                    Name = productDTO.Name,
                    PurchasePrice = productDTO.PurchasePrice,
                    GainPercentage = productDTO.GainPercentage,
                    UnitPrice = productDTO.UnitPrice,
                    Description = productDTO.Description,
                    State = productDTO.State,
                    MeasureId = productDTO.MeasureId,
                    BrandId = productDTO.BrandId,
                    CategoryId = productDTO.CategoryId
                    // No establecemos las propiedades de navegación (Brand, Category, Measure)
                    // Serán manejadas por Entity Framework
                };
                
                repository.InsertProduct(product);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdateProduct([FromBody] ProductUpdateDTO productDTO)
        {
            try
            {
                var existingProduct = repository.GetProduct(productDTO.ProductId);
                
                if (existingProduct == null)
                    return NotFound($"Producto con ID {productDTO.ProductId} no encontrado");

                // Mapear el DTO a la entidad Product
                var product = new Product
                {
                    ProductId = productDTO.ProductId,
                    CodeBar = productDTO.CodeBar,
                    Name = productDTO.Name,
                    PurchasePrice = productDTO.PurchasePrice,
                    GainPercentage = productDTO.GainPercentage,
                    UnitPrice = productDTO.UnitPrice,
                    Description = productDTO.Description,
                    State = productDTO.State,
                    MeasureId = productDTO.MeasureId,
                    BrandId = productDTO.BrandId,
                    CategoryId = productDTO.CategoryId
                    // No establecemos las propiedades de navegación (Brand, Category, Measure)
                };
                
                repository.UpdateProduct(product);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            try
            {
                var existingProduct = repository.GetProduct(id);
                
                if (existingProduct == null)
                    return NotFound($"Producto con ID {id} no encontrado");
                
                repository.DeleteProduct(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
