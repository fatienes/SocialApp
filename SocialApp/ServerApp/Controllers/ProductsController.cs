using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServerApp.Data;
using ServerApp.Models;  
using Microsoft.EntityFrameworkCore;
using ServerApp.DTO;
using Microsoft.AspNetCore.Authorization;

namespace ServerApp.Controllers
{ 


    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
      private readonly SocialContext _context;
        private object _products;

        public ProductsController(SocialContext context)
      {
         
             _context=context;
      
      
      }
// localhost:5000/api/controller
        [HttpGet]
        [AllowAnonymous]
        public  async  Task<ActionResult> GetProducts(){
           var products = await _context
           .Product
           .Select(p=>ProductToDTO(p))
           .ToListAsync();
           
                  return Ok(products);
        }


[HttpGet("{id}")]
public async  Task<IActionResult> GetProducts(int id)
{
            
            var p = await _context.Product.FindAsync(id);
   if(p==null){
       return NotFound();
   } 
   return Ok(ProductToDTO(p));
}
  [HttpPost]
  public async Task<ActionResult> CreateProduct(Product entitiy) 
  {
_context.Product.Add(entitiy);
await _context.SaveChangesAsync();

return CreatedAtAction(nameof(GetProducts), new{id=entitiy.productId},ProductToDTO(entitiy));
  }
   [HttpPut("{id}")]
   public async Task<ActionResult> UpdateProduct(int id, Product entity){
     if(id!=entity.productId){
       return BadRequest();
     }
     var product =await _context.Product.FindAsync(id);
     if(product==null){
       return NotFound();
     }
     product.Name=entity.Name;
     product.Price=entity.Price;
     try{
       await _context.SaveChangesAsync();
     }
     catch(Exception ){
       return NotFound();
     }
     return NoContent();
   }

[HttpPut("{id}")]
 public async Task<ActionResult> UpdateProductgfgf(int id, Product entity){
   if(id!=entity.productId){
       return BadRequest();
     }
     var product =await _context.Product.FindAsync(id);
     if(product==null){
       return NotFound();
     }
     product.Name=entity.Name;
     product.Price=entity.Price;
     try{
       await _context.SaveChangesAsync();
     }
     catch(Exception ){
       return NotFound();
     }
     return NoContent();
 }
 [HttpDelete("{id}")]
public async Task<IActionResult> DeleteProduct(int id){
  var product =await _context.Product.FindAsync(id);
  if(product==null){
    return NotFound();
  }
  _context.Product.Remove(product);
  await _context.SaveChangesAsync();
  return NoContent();
}
private static ProductDTO ProductToDTO(Product p){
  return new ProductDTO(){
    productId=p.productId,
    Name=p.Name,
    Price=p.Price,
    IsActive=p.IsActive

  };
}

    }

}