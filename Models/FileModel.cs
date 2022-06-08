using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace u21487822_HW3.Models
{
    public class FileModel
    {

        //Display options.

        //[Display(Name = "File Name")]
        //public string FileName { get; set; }

        //[Required(ErrorMessage = "Please select file.")]
        //[Display(Name = "Browse File")]
        //public HttpPostedFileBase[] Files { get; set; }
        public IEnumerable<HttpPostedFileBase> files { get; set; }
        public string FileName { get; set; }
        
        
    }
}