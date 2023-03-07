using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class BaseApiController : ControllerBase
	{
		private IMediator _mediator;

		// if _mediator is not null it will be assigned to Mediator
		// if _mediator is null then what's on the right of ??= will be
		// assigned to Mediator
		protected IMediator Mediator => _mediator ??=
			HttpContext.RequestServices.GetService<IMediator>();

	}
}
