using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_HW_01.Models;
using Omu.ValueInjecter;

namespace MVC_HW_01.Controllers
{
    public class 客戶資料Controller : Controller
    {
        //private CustomerInformationEntities db = new CustomerInformationEntities();
        private 客戶資料Repository 客戶資料repo;
        public List<SelectListItem> listItems;

        public 客戶資料Controller()
        {
            客戶資料repo = RepositoryHelper.Get客戶資料Repository();
            listItems = 客戶資料repo.GetListItem();
            ViewBag.分類名稱 = listItems;
        }

        public ActionResult ItemSelected(string list客戶分類)
        {
            return View();
        }

        // GET: 客戶資料
        //public ActionResult Index()
        //{
        //    //return View(db.客戶資料.ToList());
        //    return View(客戶資料repo.All());
        //}
        //private void SetViewBag客戶分類(eMovieCategories selectedMovie)
        //{

        //    IEnumerable<eMovieCategories> values =

        //                      Enum.GetValues(typeof(eMovieCategories))

        //                      .Cast<eMovieCategories>();

        //    IEnumerable<SelectListItem> items =

        //        from value in values

        //        select new SelectListItem

        //        {

        //            Text = value.ToString(),

        //            Value = value.ToString(),

        //            Selected = value == selectedMovie,

        //        };

        //    ViewBag.MovieType = items;

        //}
                
        public ActionResult Index(string sortOrder, string 分類名稱)
        {
            ViewBag.CustomerNameSort = String.IsNullOrEmpty(sortOrder) || sortOrder == "CustomerNameSort" ? "CustomerNameDesc" : "CustomerNameSort";
            ViewBag.CustomerClassifySort = sortOrder == "CustomerClassifySort" ? "CustomerClassifyDesc" : "CustomerClassifySort";
            ViewBag.InvoiceSort = sortOrder == "InvoiceSort" ? "InvoiceDesc" : "InvoiceSort";
            ViewBag.PhoneSort = sortOrder == "PhoneSort" ? "PhoneDesc" : "PhoneSort";
            ViewBag.FaxSort = sortOrder == "FaxSort" ? "FaxDesc" : "FaxSort";
            ViewBag.AddressSort = sortOrder == "AddressSort" ? "AddressDesc" : "AddressSort";
            ViewBag.EmailSort = sortOrder == "EmailSort" ? "EmailDesc" : "EmailSort";   

            return View(客戶資料repo.QueryByCustomize(sortOrder, 分類名稱));
        }

        // GET: 客戶資料/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //客戶資料 客戶資料 = db.客戶資料.Find(id);
            客戶資料 客戶資料 = 客戶資料repo.Get客戶資料(id.Value);

            if (客戶資料 == null)
            {
                return HttpNotFound();
            }
            return View(客戶資料);
        }

        // GET: 客戶資料/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: 客戶資料/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(客戶資料 客戶資料)
        {
            if (ModelState.IsValid)
            {
                //db.客戶資料.Add(客戶資料);
                //db.SaveChanges();
                客戶資料repo.Add(客戶資料);
                客戶資料repo.UnitOfWork.Commit();

                return RedirectToAction("Index");
            }

            return View(客戶資料);
        }

        // GET: 客戶資料/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //客戶資料 客戶資料 = db.客戶資料.Find(id);
            客戶資料 客戶資料 = 客戶資料repo.Get客戶資料(id.Value);

            if (客戶資料 == null)
            {
                return HttpNotFound();
            }
            return View(客戶資料);
        }

        // POST: 客戶資料/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, 客戶資料 客戶資料)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(客戶資料).State = System.Data.Entity.EntityState.Modified;
                //db.SaveChanges();
                var item = 客戶資料repo.Get客戶資料(id);
                item.InjectFrom(客戶資料);

                客戶資料repo.UnitOfWork.Commit();

                return RedirectToAction("Index");
            }
            return View(客戶資料);
        }

        // GET: 客戶資料/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //客戶資料 客戶資料 = db.客戶資料.Find(id);
            客戶資料 客戶資料 = 客戶資料repo.Get客戶資料(id.Value);
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }
            return View(客戶資料);
        }

        // POST: 客戶資料/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //客戶資料 客戶資料 = db.客戶資料.Find(id);
            //db.客戶資料.Remove(客戶資料);
            //db.SaveChanges();
            客戶資料 客戶資料 = 客戶資料repo.Get客戶資料(id);
            客戶資料repo.Delete(客戶資料);
            客戶資料repo.UnitOfWork.Commit();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
