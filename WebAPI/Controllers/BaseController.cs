using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

public class BaseController : ControllerBase
{
    private IMediator? _mediator;

    //Protected oldugu icin buyuk
    protected IMediator? Mediator => _mediator??= HttpContext.RequestServices.GetService<IMediator>();
}
 
