using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetsCareCore.Context;

namespace Pets_Care.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly PetCareDbcontext _context;

        public FilesController(PetCareDbcontext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> UploadImageAndGetURL(IFormFile file)
        {
            string uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "Images");
            if (file == null || file.Length == 0)
            {
                return BadRequest("Please Enter Valid File");
            }
            string newFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            string newFilePath = Path.Combine(uploadFolder, newFileName);

            using (var inputFile = new FileStream(newFilePath, FileMode.Create))
            {
                await file.CopyToAsync(inputFile);
            }

            string baseUrl = $"{Request.Scheme}://{Request.Host}{Request.PathBase}";
            string fileUrl = $"{baseUrl}/Images/{newFileName}";

            return Ok(fileUrl);  // Return the URL as a plain text response
        }


    }
}
