using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ArtareaNew.Models;
using OfficeOpenXml;
using System.Activities.Statements;

namespace ArtareaNew.Controllers
{
    public class AdminController : BaseController
    {

        ArtareaEntities _db = new ArtareaEntities();
   
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult authorexel()
        {
            var list = _db.Authors.ToList();
            var author = _db.AuthorTranslates.ToList();
            List<AutorForAdmin> autor = new List<AutorForAdmin>();
            foreach (var i in list)
            {
                autor.Add(new AutorForAdmin
                {
                    photo = i.Photo,
                    name = author.Where(a=>a.Authorid==i.Id).Select(b=>b.Name).FirstOrDefault(),
                   surname = author.Where(a => a.Authorid == i.Id).Select(b => b.Surname).FirstOrDefault(),
                   profession = author.Where(a => a.Authorid == i.Id).Select(b => b.Profession).FirstOrDefault(),
                   leCode = author.Where(a => a.Authorid == i.Id).Select(b => b.LangCode).FirstOrDefault(),
                biography = author.Where(a => a.Authorid == i.Id).Select(b => b.Biography).FirstOrDefault()
               });


            }
            return View(autor);
        }

        [HttpPost]
        public ActionResult authorexel(FormCollection formCollection)
        {
            ViewBag.result = "";
            AuthorTranslate newAuthorTranslate = new AuthorTranslate();
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
                            if (workSheet.Cells[rowIterator, 1].Value == null
                                  || workSheet.Cells[rowIterator, 2].Value == null
                                  || workSheet.Cells[rowIterator, 3].Value == null
                                  || workSheet.Cells[rowIterator, 4].Value == null
                                  )
                            {

                                ViewBag.result1 = "დაფიქსირდა შეცდომა მე-" + (count + 1) + " რიგში. გთხოვთ შეავსოთ ყველა სვეტი.";

                                return View();
                            }


                        }

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
                                    Author newAuthor = new Author
                                    {
                                        Photo = "default.png",
                                        Createdate = DateTime.Now
                                    };
                                    _db.Authors.Add(newAuthor);
                                    newAuthorTranslate.Name = workSheet.Cells[rowIterator, 1].Value.ToString().Trim();
                                    newAuthorTranslate.Surname = workSheet.Cells[rowIterator, 2].Value.ToString().Trim();
                                    newAuthorTranslate.Biography = workSheet.Cells[rowIterator, 3].Value.ToString().Trim();
                                    newAuthorTranslate.Profession = workSheet.Cells[rowIterator, 4].Value.ToString().Trim();

                                    newAuthorTranslate.Authorid = newAuthor.Id;
                                    newAuthorTranslate.LangCode = "ka-ge";
                                    newAuthorTranslate.Createdate = DateTime.Now;
                                    _db.AuthorTranslates.Add(newAuthorTranslate);
                                    _db.SaveChanges();
                                    ViewBag.result = "ყველა მონაცემი წარმატებით ჩაიწერა ბაზაში.";
                                    //if (workSheet.Cells[rowIterator, 1].Value.ToString().Trim()==null|| workSheet.Cells[rowIterator, 2].Value.ToString().Trim() == null || workSheet.Cells[rowIterator, 3].Value.ToString().Trim() == null || workSheet.Cells[rowIterator, 4].Value.ToString().Trim() == null)
                                    //    {
                                    //        throw new Exception("testg");
                                    //    }
                                    count++;
                                }

                                catch
                                {
                                    ViewBag.result = "მონაცემთა ჩაწერისას დაფიქსირდა შეცდომა. ჩაიწერა პირველი " + count + " ჩანაწერი. გადაამოწმეთ დოკუმენტი, უკვე ჩაწერილი რიგები წაშალეთ და ახლიდან ატვირთეთ.";
                                }
                            }
                        }
                    }
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
            return View();
        }


        public ActionResult addauthor()
        {
            return View();
        }

        [HttpPost]
        public ActionResult addauthor(AddAuthor model, HttpPostedFileBase file)
        {

            Author newAuthor = new Author();
            // photo func

            string fileName = Random32();
            string ext = Path.GetExtension(file.FileName);
            string path = Path.Combine(Server.MapPath("~/Images"), fileName + ext);
            newAuthor.Photo = model.Photo = fileName + ext;
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


            return RedirectToAction("Index", "Admin");
        }


        public static string Random32()
        {
            return Guid.NewGuid().ToString("N");
        }







        public ActionResult addcategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult addcategory(addCategory model)
        {

            Category newcategory = new Category();

            newcategory.Createdate = DateTime.Now;
            _db.Categories.Add(newcategory);



            CategoryTranslate newCategoryTranslate = new CategoryTranslate();
            newCategoryTranslate.Name = model.Name;
            newCategoryTranslate.Categoryid = newcategory.Id;
            newCategoryTranslate.LangCode = "ka-ge";
            newCategoryTranslate.Createdate = DateTime.Now;
            _db.CategoryTranslates.Add(newCategoryTranslate);
            _db.SaveChanges();

            return RedirectToAction("Index", "Admin");
        }




        public ActionResult categoryexel()
        {
            var list = _db.Categories.ToList();
            var category = _db.CategoryTranslates.ToList();
            List<CategoryForAdmin> categori = new List<CategoryForAdmin>();
            foreach (var i in list)
            {
                categori.Add(new CategoryForAdmin
                {
                    Name = category.Where(a => a.Categoryid == i.Id).Select(b => b.Name).FirstOrDefault(),
                    leCode = category.Where(a => a.Categoryid == i.Id).Select(b => b.LangCode).FirstOrDefault(),
                });


            }
            return View(categori);
        }




        [HttpPost]
        public ActionResult categoryexel(FormCollection formCollection)
        {
            ViewBag.result = "";
            CategoryTranslate newCategoryTranslate = new CategoryTranslate();
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
                            if (workSheet.Cells[rowIterator, 1].Value == null)
                            {

                                ViewBag.result1 = "დაფიქსირდა შეცდომა მე-" + (count + 1) + " რიგში. გთხოვთ შეავსოთ ყველა სვეტი.";

                                return View();
                            }


                        }

                        // ტრიალდება ფორ ციკლი ექსელის ფაილის რიგებზე
                        for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                        {
                            if (workSheet.Cells[rowIterator, 1].Value != null)

                            {

                                try
                                {
                                    Category newCategory = new Category
                                    {
                                        Createdate = DateTime.Now
                                    };
                                    _db.Categories.Add(newCategory);
                                    newCategoryTranslate.Name = workSheet.Cells[rowIterator, 1].Value.ToString().Trim();

                                    newCategoryTranslate.Categoryid = newCategory.Id;
                                    newCategoryTranslate.LangCode = "ka-ge";
                                    newCategoryTranslate.Createdate = DateTime.Now;
                                    _db.CategoryTranslates.Add(newCategoryTranslate);
                                    _db.SaveChanges();
                                    ViewBag.result = "ყველა მონაცემი წარმატებით ჩაიწერა ბაზაში.";
                                    //if (workSheet.Cells[rowIterator, 1].Value.ToString().Trim()==null|| workSheet.Cells[rowIterator, 2].Value.ToString().Trim() == null || workSheet.Cells[rowIterator, 3].Value.ToString().Trim() == null || workSheet.Cells[rowIterator, 4].Value.ToString().Trim() == null)
                                    //    {
                                    //        throw new Exception("testg");
                                    //    }
                                    count++;
                                }

                                catch
                                {
                                    ViewBag.result = "მონაცემთა ჩაწერისას დაფიქსირდა შეცდომა. ჩაიწერა პირველი " + count + " ჩანაწერი. გადაამოწმეთ დოკუმენტი, უკვე ჩაწერილი რიგები წაშალეთ და ახლიდან ატვირთეთ.";
                                }
                            }
                        }
                    }
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
            return View();
        }

    }
}