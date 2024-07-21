using System;
namespace Socialize.Core
{
	public class StandardResponse
	{
		public string message { get; set; }
		public int statusCode { get; set; }

		public StandardResponse(string message, int statusCode)
		{
			this.message = message;
			this.statusCode = statusCode;
		}
	}
}

