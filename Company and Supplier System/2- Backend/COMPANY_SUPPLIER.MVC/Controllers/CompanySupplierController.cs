using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using COMPANY_SUPPLIER.APP.DTO;
using COMPANY_SUPPLIER.APP.Interfaces;
using System.Net;

namespace COMPANY_SUPPLIER.MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanySupplierController : Controller
    {
        private readonly ICompanySupplierAppService _companysupplierAppService;

        public CompanySupplierController(ICompanySupplierAppService companysupplierAppService)
        {
            (_companysupplierAppService) = (companysupplierAppService);
        }

        /// <summary>
        /// Save
        /// </summary>
        /// <remarks>Endpoint used to link a supplier and a company.</remarks>
        /// <response code="200">The request was successful.</response>
        /// <response code="400">Invalid or incorrectly entered parameter.</response>
        /// <response code="500">Internal Server Error.</response>
        [HttpPost("")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(List<CompanySupplierDTO>), (int)HttpStatusCode.OK)]
        [SwaggerOperation("GetAllAdresses")]
        public async Task<IActionResult> Save([FromBody] CompanySupplierDTO companysupplierdto)
        {
            try
            {
                await _companysupplierAppService.SaveCompanySupplier(companysupplierdto);

                return Ok(new
                {
                    message = "This request was successfully.",
                });
            }
            catch (ValidationException ex)
            {
                return BadRequest(new
                {
                    message = ex.Message
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
        /// <remarks>Endpoint used to return supplier.</remarks>
        /// <response code="200">The request was successful.</response>
        /// <response code="400">Invalid or incorrectly entered parameter.</response>
        /// <response code="404">No data found.</response>
        /// <response code="500">Internal Server Error.</response>
        [HttpGet("")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(List<CompanySupplierDTO>), (int)HttpStatusCode.OK)]
        [SwaggerOperation("GetAllAdresses")]
        public async Task<IActionResult> Find([FromQuery] CompanySupplierDTO companysupplierkeydto)
        {
            try
            {
                return Ok(new
                {
                    message = "This request was successfully.",
                    data = await _companysupplierAppService.FindCompanySupplier(companysupplierkeydto)
                });
            }
            catch (ValidationException ex)
            {
                return BadRequest(new
                {
                    message = ex.Message
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
        /// <remarks>Endpoint used to delete Supplier.</remarks>
        /// <response code="200">The request was successful.</response>
        /// <response code="400">Invalid or incorrectly entered parameter.</response>
        /// <response code="404">No data found.</response>
        /// <response code="500">Internal Server Error.</response>
        [HttpDelete("")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(List<CompanySupplierDTO>), (int)HttpStatusCode.OK)]
        [SwaggerOperation("DeleteCustomerProposal")]
        public async Task<IActionResult> Delete([FromBody] CompanySupplierDTO companysupplierdto)
        {
            try
            {
                await _companysupplierAppService.DeleteCompanySupplier(companysupplierdto);

                return Ok(new
                {
                    message = "This request was successfully.",
                });
            }
            catch (ValidationException ex)
            {
                return BadRequest(new
                {
                    message = ex.Message
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
