using MediatR;
using Microsoft.AspNetCore.Mvc;
using TyreManagement.Core.DTO;
using TyreManagement.Core.Application.Features.TyreProduct.Commands.CreateTyreProduct;
using TyreManagement.Core.Application.Features.TyreProduct.Commands.UpdateTyreProduct;
using TyreManagement.Core.Application.Features.TyreProduct.Commands.DeleteTyreProduct;
using TyreManagement.Core.Application.Features.TyreProduct.Queries.GetAllTyreProducts;
using TyreManagement.Core.Application.Features.TyreProduct.Queries.GetTyreProduct;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TyreManagement.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TyreProductsController : ControllerBase
{
  private readonly IMediator _mediator;
  public TyreProductsController(IMediator mediator)
  {
    this._mediator = mediator;
  }

  // GET: api/<TyreProductsController>
  [HttpGet]
  public async Task<List<TyreProductDto>> Get()
  {
    var tyreProducts = await _mediator.Send(new GetAllTyreProductsQuery());
    return tyreProducts;
  }

  // GET api/<TyreProductsController>/5
  [HttpGet("{id}")]
  public async Task<ActionResult<TyreProductDto>> Get(int id)
  {
    var tyreProduct = await _mediator.Send(new GetTyreProductQuery(id));
    return Ok(tyreProduct);
  }

  // POST api/<TyreProductsController>
  [HttpPost]
  [ProducesResponseType(StatusCodes.Status201Created)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  public async Task<ActionResult> Post(CreateTyreProductCommand tyreProduct)
  {
    var response = await _mediator.Send(tyreProduct);
    return CreatedAtAction(nameof(Get), new { id = response });
  }

  // PUT api/<TyreProductsController>
  [HttpPut]
  [ProducesResponseType(StatusCodes.Status204NoContent)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  [ProducesDefaultResponseType]
  public async Task<ActionResult> Put(UpdateTyreProductCommand tyreProduct)
  {
    await _mediator.Send(tyreProduct);
    return NoContent();
  }

  // DELETE api/<TyreProductsController>/5
  [HttpDelete("{id}")]
  [ProducesResponseType(StatusCodes.Status204NoContent)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  [ProducesDefaultResponseType]
  public async Task<ActionResult> Delete(int id)
  {
    var command = new DeleteTyreProductCommand { Id = id };
    await _mediator.Send(command);
    return NoContent();
  }
}
