using FileUpload.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace FileUpload.Test
{
	[TestClass]
	public class FileUploadServiceTests
	{
		/// <summary>
		/// Test that if test file is exist in 'Files' folder
		/// </summary>
		[TestMethod]
		public void IsExistFileName()
		{
			FileUploadService service = new FileUploadService();
			var fileName = "testDocument.docx";
			List<FileDTO> file = service.GetAllFileNames(fileName);

			Assert.AreEqual(false, file.Any(i => i.FileName == fileName));
		}

		/// <summary>
		/// Test that if test file is not exist in 'Files' folder
		/// </summary>
		[TestMethod]
		public void IsNotExistFileName()
		{
			FileUploadService service = new FileUploadService();
			var fileName = "testDocument.docx";
			List<FileDTO> file = service.GetAllFileNames(fileName);
			Assert.AreNotEqual(true, file.Any(i => i.FileName == fileName));
		}

		/// <summary>
		/// Test that if test file has extension in file name
		/// </summary>
		[TestMethod]
		public void HasFileExtension()
		{
			FileUploadService service = new FileUploadService();
			var fileName = "testDocument.docx";
			bool hasFileExtension = service.HasFileExtension(fileName);
			Assert.AreEqual(true, hasFileExtension);
		}

		/// <summary>
		/// Test that if test file has not extension in file name
		/// </summary>
		[TestMethod]
		public void HasNotFileExtension()
		{
			FileUploadService service = new FileUploadService();
			var fileName = "testDocument.docx";
			bool hasNotFileExtension = service.HasFileExtension(fileName);
			Assert.AreNotEqual(false, hasNotFileExtension);
		}
	}
}
