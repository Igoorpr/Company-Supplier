using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using COMPANY_SUPPLIER.APP.DTO.Company;
using COMPANY_SUPPLIER.APP.Interfaces;
using System.Net;

namespace COMPANY_SUPPLIER.MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : Controller
    {
        private readonly ICompanyAppService _companyAppService;

        public CompanyController(ICompanyAppService companyAppService)
        {
            (_companyAppService) = (companyAppService);
        }

        /// <summary>
        /// Save
        /// </summary>
        /// <remarks>Endpoint used to save the company.</remarks>
        /// <response code="200">The request was successful.</response>
        /// <response code="400">Invalid or incorrectly entered parameter.</response>
        /// <response code="500">Internal Server Error.</response>
        [HttpPost("")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(List<CompanyDTO>), (int)HttpStatusCode.OK)]
        [SwaggerOperation("GetAllAdresses")]
        public async Task<IActionResult> Save([FromBody] CompanyDTO companydto)
        {
            try
            {
                await _companyAppService.SaveCompany(companydto);

                return Ok(new
                {
                    message = "This request was successfully.",
                });
            }
            catch (ValidationException ex)
            {
                return BadRequest(new 
                {
                    mensagem = ex.Message
                });
            }
            //If the data already exists in the database
            catch (NullReferenceException ex)
            {
                return BadRequest(new 
                {
                    message = ex.Message
                });
            }
            catch (Exception ex)
            {
                return new ObjectResult(new 
                {
                    message = "Internal Server Error."
                })
                {
                    StatusCode = 500
                };
            }
        }

        /// <summary>
        /// Find
        /// </summary>
        /// <remarks>Endpoint used to return company.</remarks>
        /// <response code="200">The request was successful.</response>
        /// <response code="400">Invalid or incorrectly entered parameter.</response>
        /// <response code="404">No data found.</response>
        /// <response code="500">Internal Server Error.</response>
        [HttpGet("")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(List<CompanyKeyDTO>), (int)HttpStatusCode.OK)]
        [SwaggerOperation("GetAllAdresses")]
        public async Task<IActionResult> Find([FromQuery] CompanyKeyDTO companykeydto)
        {
            try
            {
                return Ok(new
                {
                    message = "This request was successfully.",
                    data = await _companyAppService.FindCompany(companykeydto)
                });
            }
            catch (ValidationException ex)
            {
                return BadRequest(new
                {
                    mensagem = ex.Message
                });
            }
            // Data not found
            catch (NullReferenceException ex)
            {
                return NotFound(new 
                {
                    message = ex.Message
                });
            }
            catch (Exception ex)
            {
                return new ObjectResult(new
                {
                    message = "Internal Server Error."
                })
                {
                    StatusCode = 500
                };
            }
        }

        /// <summary>
        /// Update Company
        /// </summary>
        /// <remarks>Endpoint used to update the Company.</remarks>
        /// <response code="200">The request was successful.</response>
        /// <response code="400">Invalid or incorrectly entered parameter.</response>
        /// <response code="404">No data found.</response>
        /// <response code="500">Internal Server Error.</response>
        [HttpPut("")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(List<CompanyDTO>), (int)HttpStatusCode.OK)]
        [SwaggerOperation("UpdateCustomerProposal")]
        public async Task<IActionResult> Update([FromBody] CompanyDTO companydto)
        {
            try
            {
                await _companyAppService.UpdateCompany(companydto);

                return Ok(new
                {
                    message = "This request was successfully.",
                });
            }
            catch (ValidationException ex)
            {
                return BadRequest(new
                {
                    mensagem = ex.Message
                });
            }
            // Data not found
            catch (NullReferenceException ex)
            {
                return NotFound(new 
                {
                    message = ex.Message
                });
            }
            catch (Exception ex)
            {
                return new ObjectResult(new
                {
                    message = "Internal Server Error."
                })
                {
                    StatusCode = 500
                };
            }
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <remarks>Endpoint used to delete Company.</remarks>
        /// <response code="200">The request was successful.</response>
        /// <response code="400">Invalid or incorrectly entered parameter.</response>
        /// <response code="404">No data found.</response>
        /// <response code="500">Internal Server Error.</response>
        [HttpDelete("")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(List<CompanyKeyDTO>), (int)HttpStatusCode.OK)]
        [SwaggerOperation("DeleteCustomerProposal")]
        public async Task<IActionResult> Delete([FromBody] CompanyKeyDTO companykeydto)
        {
            try
            {
                await _companyAppService.DeleteCompany(companykeydto);

                return Ok(new
                {
                    message = "This request was successfully.",
                });
            }
            catch (ValidationException ex)
            {
                return BadRequest(new
                {
                    mensagem = ex.Message
                });
            }
            // Data not found
            catch (NullReferenceException ex)
            {
                return NotFound(new 
                {
                    message = ex.Message
                });
            }
            catch (Exception ex)
            {
                return new ObjectResult(new
                {
                    message = "Internal Server Error."
                })
                {
                    StatusCode = 500
                };
            }
        }
    }
}
