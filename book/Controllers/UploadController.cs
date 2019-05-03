using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace book.Controllers
{
    public class UploadController : Controller
    {
        // GET: Upload
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult UploadFile(HttpPostedFileBase file)
        {
            try
            {
                if (file != null && file.ContentLength > 0)
                {
                    string _FileName = Path.GetFileName(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/UploadedFiles"), _FileName);
                    file.SaveAs(_path);
                }
                ViewBag.Message = "File Uploaded Successfully!!";
                return Json(new
                {
                    ret =1,
                    link="abc",
                },JsonRequestBehavior.AllowGet);
            }
            catch
            {
                ViewBag.Message = "File upload failed!!";
                return Json(new
                {
                    ret = -1
                }, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpPost]
        [ValidateInput(false)]
        public JsonResult UploadFile2()
        {
            var file = Request.Files[0];
            string[] imgexts = { "BMP", "JPG", "PNG", "GIF", "JPEG", "TIF" };
            // string[] docexts = { "PDF", "ZIP", "RAR", "7Z", "GZ", "GZIP" };
            DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Local);//from 1970/1/1 00:00:00 to now

            DateTime dtNow = DateTime.Now;

            TimeSpan result = dtNow.Subtract(dt);

            int seconds = Convert.ToInt32(result.TotalSeconds);
            string filename =seconds.ToString() + Path.GetFileName(Request.Files[0].FileName);
            string linkfile = "";
            int ret = 0;
            string basepath = "";
            int type = 0;
            
            if (Request.Files.Count < 1)
            {
                ret = -2;
            }
            
            //upload limmit
            if (ret >= 0)
            {
                if (type == 1 && Request.Files[0].ContentLength > 20 * 1048576)
                {
                    Request.Files[0].InputStream.Dispose();
                    ret = -5;
                }
                if (type == 2 && Request.Files[0].ContentLength > 40 * 1048576)
                {
                    Request.Files[0].InputStream.Dispose();
                    ret = -5;

                }
            }
            if (ret >= 0)
            {
                //tính đường dẫn file lưu
                basepath = Server.MapPath("/");
                linkfile = string.Format("UploadedFiles\\{0}\\{1}\\", DateTime.Now.Year, DateTime.Now.Month.ToString("00"));
                basepath += linkfile;
            }
            if (ret >= 0)
            {
                var fileContent = Request.Files[0];
                if (filename != "")
                {
                    linkfile = "/" + linkfile + filename;
                    var stream = fileContent.InputStream;
                    // and optionally write the file to disk
                    try
                    {
                        string _FileName = Path.GetFileName(file.FileName);
                        string _path = Path.Combine(Server.MapPath("~/UploadedFiles"), filename);
                        file.SaveAs(_path);

                        /*  var fileStream = System.IO.File.Create(basepath + filename);
                          stream.CopyTo(fileStream);
                          stream.Close();
                          fileStream.Close();*/
                    }
                    catch (Exception e)
                    {
                        ret = -4;
                    }

                }

            }
            //if (ret >= 0)
            //{
            //    ret = comto.UploadedFile(linkfile, uploadedfilename, "NEWS");
            //}
            return Json(new { sussess = ret, filename = "/UploadedFiles/"+ filename}, JsonRequestBehavior.AllowGet);
        }
    }
}