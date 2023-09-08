using Entity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.UnitOfWork;

namespace UnitOfWorkExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IUnitOfWorks _unitOfWorks;

        public BrandController(IUnitOfWorks unitOfWorks)
        {
            _unitOfWorks = unitOfWorks;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Brand>>> Get()
        {
            var brand = await _unitOfWorks.BrandRepository.GetAllItemWithCondition();
            return Ok(brand);
        }
        [HttpPost]
        public async Task<ActionResult<string>> Create(Brand brand)
        {
            if(ModelState.IsValid)
            {
                await _unitOfWorks.BrandRepository.Insert(brand);
                await _unitOfWorks.Save();
                return "ok";
            }
            else
            {
                _unitOfWorks.Dispose();
                return "dispose";
            }
            
        }
    }
}
