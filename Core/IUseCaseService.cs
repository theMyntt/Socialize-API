using System;
using Microsoft.AspNetCore.Mvc;

namespace Socialize.Core
{
	public interface IUseCaseService<Input, Output>
	{
		Task<ActionResult<Output>> run(Input dto);
	}
}

