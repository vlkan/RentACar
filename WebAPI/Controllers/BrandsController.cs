using Application.Features.Brands.Commands.Create;
using Application.Features.Brands.Commands.Delete;
using Application.Features.Brands.Commands.Update;
using Application.Features.Brands.Queries.GetById;
using Application.Features.Brands.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers;

namespace WebAPI.Kontrollerse;

[Route("api/[controller]")]
[ApiController]
public class BrandsController : BaseController
{
    [HttpPost("Add")]
    public async Task<IActionResult> Add([FromBody] CreateBrandCommand createBrandCommand) 
    {
        CreatedBrandResponse response = await Mediator.Send(createBrandCommand);
        return Ok(response);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] UpdateBrandCommand updateBrandCommand) 
    {
        UpdatedBrandResponse response = await Mediator.Send(updateBrandCommand);
        return Ok(response);
    }

    [HttpGet("GetList")]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListBrandQuery getListBrandQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListBrandListItemDto> response = await Mediator.Send(getListBrandQuery);

        return Ok(response);
    }

    [HttpGet("GetById/{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id) 
    {
        GetByIdBrandQuery getByIdBrandQuery = new() { Id = id };
        GetByIdBrandResponse response = await Mediator.Send(getByIdBrandQuery);

        return Ok(response);
    }

    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete([FromBody] DeleteBrandCommand deleteBrandCommand) 
    {
        DeletedBrandResponse response = await Mediator.Send(deleteBrandCommand);
        return Ok(response);
    }
}
