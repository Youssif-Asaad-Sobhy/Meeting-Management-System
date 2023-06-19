using Meeting_Manegment_System.Data;
using Meeting_Manegment_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Meeting_Manegment_System.Interface;

namespace Meeting_Manegment_System.Controllers
{
    public class DocumentController : Controller
    {
        private IDocumentRepository _document;
        public DocumentController(IDocumentRepository document)
        {
            _document = document;
        }
        public IActionResult Upload()
        {
            return View();
        }
        public IActionResult Download(int id)
        {
            WordDocument wordDoc = _document.GetFileById(id);
            if (wordDoc != null)
            {
                return File(wordDoc.FileContent, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", wordDoc.FileName);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public ActionResult Upload(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                // Check if the file is a Word document
                if (file.ContentType == "application/msword" || file.ContentType == "application/vnd.openxmlformats-officedocument.wordprocessingml.document")
                {
                    // Read the file content into a byte array
                    byte[] Content;
                    using (var memoryStream = new MemoryStream())
                    {
                        file.CopyTo(memoryStream);
                        Content = memoryStream.ToArray();
                    }

                    // Create a new WordDocument object
                    WordDocument wordDoc = new WordDocument
                    {
                        FileName = file.FileName,
                        FileContent = Content
                    };

                    // Save the WordDocument object to the database
                    _document.Add(wordDoc);

                    ViewBag.Message = "File uploaded successfully.";
                }
                else
                {
                    ViewBag.Error = "Please choose a Word document.";
                }
            }
            else
            {
                ViewBag.Error = "Please choose a file to upload.";
            }

            return View();
        }


    }
}