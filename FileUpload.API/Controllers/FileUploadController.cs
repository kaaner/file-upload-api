using FileUpload.API.Builder;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FileUpload.API.Controllers
{
	[Route("fileupload/api/")]
	[ApiController]
	public class FileUploadController
	  : ControllerBase
	{
		readonly FileUploadBuilder _builder;

		public FileUploadController()
		{
			_builder = new FileUploadBuilder();
		}

		[HttpPost]
		[Route("upload")]
		public ActionResult Upload()
		{
			var httpRequest = HttpContext.Request;
			var postedFile = httpRequest.Form.Files;

			var result = _builder.Upload(postedFile[0]);
			if (result)
				return Ok();
			else
				return NotFound();
		}
	}
}
