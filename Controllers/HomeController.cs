using System;
using System.Collections.Generic;
using System.Linq;
using u21487822_HW3.Models;
//Contains types that allow reading and writing to files and data
//streams, and types that provide basic file and directory support.
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace u21487822_HW3.Controllers
{
    public class HomeController : Controller
    {
        public string FileRadio;

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "A little description of myself";
            return View();
        }
        public string GetFileType(FormCollection frm)
        {
            FileRadio = frm["FileType"].ToString();
            return FileRadio;
        }

        public ActionResult FileUpload(FormCollection frm)
        {
            FileRadio = frm["FileType"].ToString();
            List<FileModel> uploadFile = new List<FileModel>();
            foreach (string file in Directory.GetFiles(Server.MapPath("~/Media/" + FileRadio)))
            {
                //copy existing file into a new file
                FileInfo existingFile = new FileInfo(file); 
                FileModel nFile = new FileModel();

                nFile.FileName = existingFile.Name;

                uploadFile.Add(nFile);
            }


            return View(uploadFile);
        }
        [HttpPost]
        public ActionResult FileUpload(FileModel doc, FormCollection frm)
        {
            FileRadio = frm["FileType"].ToString();
            foreach (var file in doc.files)
            {

                if (file.ContentLength > 0)
                {
                    // extract only the filename
                    var fileName = Path.GetFileName(file.FileName);
                    // store the file inside ~/App_Data/uploads folder
                    var path = Path.Combine(Server.MapPath("~/Media/" + FileRadio), fileName);
                    // The chosen default path for saving
                    file.SaveAs(path);
                }
            }
            // redirect back to the index action to show the form once again
            return RedirectToAction("Index");
        }

            //public ActionResult Index(HttpPostedFileBase files) //INSIDE HOME
            //{
            //    // Verify that the user selected a file
            //    // Not null and has a length

            //    if (files != null && files.ContentLength > 0)
            //    {
            //        // extract only the filename

            //        var fileName = Path.GetFileName(files.FileName);

            //        // store the file inside ~/App_Data/uploads folder

            //        var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);

            //        // The chosen default path for saving

            //        files.SaveAs(path);
            //    }
            //    // redirect back to the index action to show the form once again

            //    return RedirectToAction("Index");
            //}



        
    }
}