using AnalisisSistemasAPI.Interfaces;
using AnalisisSistemasAPI.Models.CartModels;
using AnalisisSistemasAPI.Models.DataBase;
using Microsoft.AspNetCore.Mvc;

namespace AnalisisSistemasAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CartController : ControllerBase
    {
        private ICartRepository repository;

        public CartController(ICartRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult GetCartItems()
        {
            var cartItems = repository.GetCartItems();
            return Ok(cartItems);
        }

        [HttpGet("{id}")]
        public IActionResult GetCartItem(int id)
        {
            var cartItem = repository.GetCartItem(id);
            if (cartItem == null)
                return NotFound();
                
            return Ok(cartItem);
        }

        [HttpPost]
        public IActionResult Insert([FromBody] CartModel cartItem)
        {
            if (cartItem == null)
                return BadRequest();

            try
            {
                repository.Insert(cartItem);
                return CreatedAtAction(nameof(GetCartItem), new { id = cartItem.CartId }, cartItem);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] CartModel cartItem)
        {
            if (cartItem == null || cartItem.CartId == 0)
                return BadRequest();

            try
            {
                var existingCartItem = repository.GetCartItem(cartItem.CartId);
                if (existingCartItem == null)
                    return NotFound();

                repository.Update(cartItem);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var existingCartItem = repository.GetCartItem(id);
                if (existingCartItem == null)
                    return NotFound();

                repository.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }

        [HttpDelete("clear")]
        public IActionResult ClearCart()
        {
            try
            {
                repository.ClearCart();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }
    }
}
