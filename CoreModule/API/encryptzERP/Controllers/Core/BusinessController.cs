using Entities.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Core.Interface;

namespace encryptzERP.Controllers.Core
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessController : ControllerBase
    {
        private readonly IBusinessRepository _businessRepository;

        public BusinessController(IBusinessRepository businessRepository)
        {
            _businessRepository = businessRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Business>>> GetAll()
        {
            try
            {
                return Ok(await _businessRepository.GetAllAsync());
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Business>> GetById(long id)
        {
            try
            {
                var business = await _businessRepository.GetByIdAsync(id);
                if (business == null) return NotFound();
                return Ok(business);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> Create(Business business)
        {
            try
            {
                await _businessRepository.AddAsync(business);
                return CreatedAtAction(nameof(GetById), new { id = business.Id }, business);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, Business business)
        {
            try
            {
                if (id != business.Id) return BadRequest();
                await _businessRepository.UpdateAsync(business);
                return NoContent();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                await _businessRepository.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
    }
}
