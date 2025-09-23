using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using COMPANY_SUPPLIER.APP.DTO.Supplier;
using COMPANY_SUPPLIER.APP.Interfaces;
using System.Net;

namespace COMPANY_SUPPLIER.MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : Controller
    {
        private readonly ISupplierAppService _supplierAppService;

        public SupplierController(ISupplierAppService supplierAppService)
        {
            (_supplierAppService) = (supplierAppService);
        }

        /// <summary>
        /// Save
        /// </summary>
        /// <remarks>Endpoint used to save the supplier.</remarks>
        /// <response code="200">The request was successful.</response>
        /// <response code="400">Invalid or incorrectly entered parameter.</response>
        /// <response code="500">Internal Server Error.</response>
        [HttpPost("")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(List<SupplierDTO>), (int)HttpStatusCode.OK)]
        [SwaggerOperation("GetAllAdresses")]
        public async Task<IActionResult> Save([FromBody] SupplierDTO supplierdto)
        {
            try
            {
                await _supplierAppService.SaveSupplier(supplierdto);

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
        /// <remarks>Endpoint used to return supplier.</remarks>
        /// <response code="200">The request was successful.</response>
        /// <response code="400">Invalid or incorrectly entered parameter.</response>
        /// <response code="404">No data found.</response>
        /// <response code="500">Internal Server Error.</response>
        [HttpGet("")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(List<SupplierKeyDTO>), (int)HttpStatusCode.OK)]
        [SwaggerOperation("GetAllAdresses")]
        public async Task<IActionResult> Find([FromQuery] SupplierKeyDTO supplierkeydto)
        {
            try
            {
                return Ok(new
                {
                    message = "This request was successfully.",
                    data = await _supplierAppService.FindSupplier(supplierkeydto)
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
        /// Update 
        /// </summary>
        /// <remarks>Endpoint used to update the Supplier.</remarks>
        /// <response code="200">The request was successful.</response>
        /// <response code="400">Invalid or incorrectly entered parameter.</response>
        /// <response code="404">No data found.</response>
        /// <response code="500">Internal Server Error.</response>
        [HttpPut("")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(List<SupplierDTO>), (int)HttpStatusCode.OK)]
        [SwaggerOperation("UpdateCustomerProposal")]
        public async Task<IActionResult> Update([FromBody] SupplierDTO supplierdto)
        {
            try
            {
                await _supplierAppService.UpdateSupplier(supplierdto);

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
        /// <remarks>Endpoint used to delete Supplier.</remarks>
        /// <response code="200">The request was successful.</response>
        /// <response code="400">Invalid or incorrectly entered parameter.</response>
        /// <response code="404">No data found.</response>
        /// <response code="500">Internal Server Error.</response>
        [HttpDelete("")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(List<SupplierKeyDTO>), (int)HttpStatusCode.OK)]
        [SwaggerOperation("DeleteCustomerProposal")]
        public async Task<IActionResult> Delete([FromBody] SupplierKeyDTO supplierkeydto)
        {
            try
            {
                await _supplierAppService.DeleteSupplier(supplierkeydto);

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
