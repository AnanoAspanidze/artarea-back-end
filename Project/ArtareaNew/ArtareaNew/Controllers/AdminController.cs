using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ArtareaNew.Models;
using OfficeOpenXml;

namespace ArtareaNew.Controllers
{
    public class AdminController : BaseController
    {

        ArtareaEntities _db = new ArtareaEntities();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult authorexel()
        {
            return View();
        }

        [HttpPost]
        public ActionResult authorexel(FormCollection formCollection, Author translate)
        {
            ViewBag.result = "";
            ViewBag.count = "";

            var count = 0;

            if (Request != null)
            {
                HttpPostedFileBase file = Request.Files["UploadedFile"];

                if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
                {
                    string fileName = file.FileName;
                    string fileContentType = file.ContentType;
                    byte[] fileBytes = new byte[file.ContentLength];
                    var data = file.InputStream.Read(fileBytes, 0, Convert.ToInt32(file.ContentLength));

                    using (var package = new ExcelPackage(file.InputStream))
                    {
                        var currentSheet = package.Workbook.Worksheets;
                        var workSheet = currentSheet.First();
                        var noOfCol = workSheet.Dimension.End.Column;
                        var noOfRow = workSheet.Dimension.End.Row;


                        for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                        {
                            if (workSheet.Cells[rowIterator, 1].Value != null
                                && workSheet.Cells[rowIterator, 2].Value != null
                                && workSheet.Cells[rowIterator, 3].Value != null
                                && workSheet.Cells[rowIterator, 4].Value != null
                                )
                            {
                                AuthorTranslate newemail = new AuthorTranslate();
                                newemail.Name = workSheet.Cells[rowIterator, 1].Value.ToString();
                                newemail.Surname = workSheet.Cells[rowIterator, 2].Value.ToString();
                                newemail.Biography = workSheet.Cells[rowIterator, 3].Value.ToString();
                                newemail.Profession = workSheet.Cells[rowIterator, 4].Value.ToString();
                                newemail.Authorid = translate.Id;
                                newemail.LangCode = "ka-ge";
                                newemail.Createdate = DateTime.Now;

                                _db.AuthorTranslates.Add(newemail);
                                _db.SaveChanges();

                                count++;
                            }
                            else
                            {

                                var all = from c in _db.AuthorTranslates select c;
                                _db.AuthorTranslates.RemoveRange(all);
                                _db.SaveChanges();

                                ViewBag.count = "მე-" + (count + 1) + " სვეტში და შეიყვანეთ ინფორმაცია ახლიდან";
                                ViewBag.result = "შეავსეთ ყველა ველი";
                                return View();
                            }

                        }
                    }

                    ViewBag.result = "yay";
                    ViewBag.count = count;

                }
            }

            else
            {
                ViewBag.result = "buuu";
                ViewBag.count = "შეყვანილია "+count+"მონაცემი";
            }

            return RedirectToAction("Index","Admin");
        }



        public ActionResult addauthor()
        {

            return View();
        }

        [HttpPost]
        public ActionResult addauthor(AuthorTranslate translate, Author autor)
        {
            AuthorTranslate newemail = new AuthorTranslate();

            newemail.Name = translate.Name;
            newemail.Surname = translate.Surname;
            newemail.Profession = translate.Profession;
            newemail.Biography = translate.Biography;
            newemail.Authorid = autor.Id;
            newemail.LangCode = "ka-ge";
            newemail.Createdate = DateTime.Now;

            _db.AuthorTranslates.Add(newemail);
            _db.SaveChanges();
            return View();
        }




    }
}