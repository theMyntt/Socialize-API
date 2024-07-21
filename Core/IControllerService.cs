using System;
using Microsoft.AspNetCore.Mvc;

namespace Socialize.Core
{
	public interface IControllerService<Input, Output>
	{
		Task<ActionResult<Output>> Perform(Input dto);
	}
}

