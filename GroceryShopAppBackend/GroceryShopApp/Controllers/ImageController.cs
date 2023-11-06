using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;

namespace GroceryShop.API.Controllers
{
    [ApiController]
    [EnableCors("AllowSpecificOrigin")]
    public class ImageController : ControllerBase
    {
        private readonly IWebHostEnvironment _environment;
        public ImageController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        [HttpPost("UploadFile")]
        public async Task<ActionResult> UploadFile(IFormFile file)
        {
            try
            {
                file = Request.Form.Files[0];
                string fName = file.FileName;
                string path = Path.Combine(_environment.ContentRootPath, "Images", file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                return Ok(new { fileName = file.FileName });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error uploading file: {ex.Message}");
            }
        }

    

        [HttpGet("GetImage/{imageName}")]
        public IActionResult GetImage(string imageName)
        {
            string imagePath = Path.Combine(_environment.ContentRootPath, "Images", imageName);
            if (!System.IO.File.Exists(imagePath))
                return NotFound("Image not found");

            byte[] imageBytes = System.IO.File.ReadAllBytes(imagePath);
            return File(imageBytes, "image/jpeg");
        }
    }
}
