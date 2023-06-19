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
        private IMeetingRepository _meeting;
        public DocumentController(IMeetingRepository meeting,IDocumentRepository document)
        {
            _document = document;
            _meeting = meeting;
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
                return File(wordDoc.Content, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", wordDoc.FileName);
            }
            return NotFound();
        }
        [HttpPost]
        public ActionResult Upload(IFormFile file,int id)
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
                        Content = Content,
                        MeetingId = id
                    };

                    // Save the WordDocument object to the database
                    WordDocument word = _document.GetFileByMeetingId(id);
                    if(word!=null)
                    {
                        word.FileName=file.FileName;
                        word.Content=Content;
                        _document.Update(word);
                    }
                    else
                    {
                        _document.Add(wordDoc);
                        Meeting meeting = _meeting.GetMeetingById(id);
                        meeting.DocumentId = _document.GetFileByMeetingId(id).Id;
                        _meeting.Update(meeting);
                    }
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

            return RedirectToAction("Index","PreviousMeeting");
        }


    }
}