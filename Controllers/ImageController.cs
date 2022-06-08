using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using u21487822_HW3.Models;

namespace u21487822_HW3.Controllers
{
    public class ImageController : Controller
    {
        // GET: Images
        public ActionResult Images()
        {
            List<FileModel> fileUploads = new List<FileModel>();
            //Fetch all files in the Folder (Directory).
            foreach (string newFile in Directory.GetFiles(Server.MapPath("~/Media/Image")))
            {
                FileInfo fileUp = new FileInfo(newFile);
                FileModel item = new FileModel();
                item.FileName = fileUp.Name;

                fileUploads.Add(item);
            }
            //Copy File names to Model collection.
            //The return below returns to the list here.

            //List<FileModel> ObjFiles = new List<FileModel>();
            return View(fileUploads);
        }
        public FileResult Download(string fileName)
        {
            //Build the File Path.                           /Media/Image/Something.jpeg
            string path = Path.Combine(Server.MapPath("~/Media/Image"), fileName);
            //Read the File data into Byte Array.
            //Use a byte array becasue of octet-stream.
            byte[] bytes = System.IO.File.ReadAllBytes(path);
            //Send the File to Download.
            //The OCTET-STREAM format is used for file attachments on the Web with an
            //unknown file type. These .octet-stream files are arbitrary binary data
            //files that may be in any multimedia format.
            return File(bytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }
        public ActionResult Delete(string fileName)
        {
            // Delete the file inside ~/Media/Document folder 
            string path = Path.Combine(Server.MapPath("~/Media/Image"), fileName);
            FileInfo file = new FileInfo(path);

            System.IO.File.Delete(fileName);
            file.Delete();
            //return RedirectToAction("Document()");
            return RedirectToAction("Images");
        }
    }
}