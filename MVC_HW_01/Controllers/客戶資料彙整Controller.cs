using MVC_HW_01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_HW_01.Controllers
{
    public class 客戶資料彙整Controller : Controller
    {
        private CustomerInformationEntities db = new CustomerInformationEntities();

        // GET: 客戶資料彙整
        public ActionResult Index()
        {
            var model = db.Get客戶資料彙整;

            return View(model);
        }
    }
}