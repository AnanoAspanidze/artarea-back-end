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
        public ActionResult authorexel(FormCollection formCollection)
        {
            ViewBag.result = "";

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

                        // ტრიალდება ფორ ციკლი ექსელის ფაილის რიგებზე
                        for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                        {
                            if (workSheet.Cells[rowIterator, 1].Value != null
                                && workSheet.Cells[rowIterator, 2].Value != null
                                && workSheet.Cells[rowIterator, 3].Value != null
                                && workSheet.Cells[rowIterator, 4].Value != null
                                )

                            {

                                try
                                {

                                    Author newAuthor = new Author();
                                    newAuthor.Photo = "default.png";
                                    newAuthor.Createdate = DateTime.Now;
                                    _db.Authors.Add(newAuthor);


                                    AuthorTranslate newAuthorTranslate = new AuthorTranslate();
                                    newAuthorTranslate.Name = workSheet.Cells[rowIterator, 1].Value.ToString().Trim();
                                    newAuthorTranslate.Surname = workSheet.Cells[rowIterator, 2].Value.ToString().Trim();
                                    newAuthorTranslate.Biography = workSheet.Cells[rowIterator, 3].Value.ToString().Trim();
                                    newAuthorTranslate.Profession = workSheet.Cells[rowIterator, 4].Value.ToString().Trim();
                                    newAuthorTranslate.Authorid = newAuthor.Id;
                                    newAuthorTranslate.LangCode = "ka-ge";
                                    newAuthorTranslate.Createdate = DateTime.Now;
                                    _db.AuthorTranslates.Add(newAuthorTranslate);


                                    _db.SaveChanges();


                                    count++;
                                }

                                catch
                                {
                                    ViewBag.result = "მონაცემთა ჩაწერისას დაფიქსირდა შეცდომა. ჩაიწერა პირველი " + count + " ჩანაწერი. გადაამოწმეთ დოკუმენტი, უკვე ჩაწერილი რიგები წაშალეთ და ახლიდან ატვირთეთ.";
                                }
                          
                            }

                            else
                            {
                                ViewBag.result = "დაფიქსირდა შეცდომა მე-" + (count + 1) + " რიგში. წაშალეთ ჩაწერილი რიგები, გადაამოწმეთ ინფორმაცია დარჩენილ რიგებში და ატვირთეთ ფაილი. დარწმუნდით, რომ ყველა სვეტი შევსებულია.";
                            }

                        }



                    }

                    ViewBag.result = "ყველა მონაცემი წარმატებით ჩაიწერა ბაზაში.";

                }

                else
                {
                    ViewBag.result = "მონაცემების ატვირთვა შეუძლებელია. ფაილი არის ცარიელი ან არასწორ ფორმატში.";
                }

            }

            else
            {
                ViewBag.result = "დაფიქსირდა შეცდომა ფაილის ატვირთვისას.";
            }

            return RedirectToAction("Index", "Admin");
        }


        public ActionResult addauthor()
        {
            return View();
        }

        [HttpPost]
        public ActionResult addauthor(AddAuthor model)
        {

            Author newAuthor = new Author();
            // photo func
            newAuthor.Photo = model.Photo;
            newAuthor.Createdate = DateTime.Now;
            _db.Authors.Add(newAuthor);


            AuthorTranslate newAuthorTranslate = new AuthorTranslate();
            newAuthorTranslate.Name = model.Name;
            newAuthorTranslate.Surname = model.Surname;
            newAuthorTranslate.Profession = model.Profession;
            newAuthorTranslate.Biography = model.Biography;
            newAuthorTranslate.Authorid = newAuthor.Id;
            newAuthorTranslate.LangCode = "ka-ge";
            newAuthorTranslate.Createdate = DateTime.Now;
            _db.AuthorTranslates.Add(newAuthorTranslate);


            _db.SaveChanges();

            return View();
        }















    }
}