using System;
using System.Linq;
using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;

namespace MVC_HW_01.Models
{
	public  class 客戶資料Repository : EFRepository<客戶資料>, I客戶資料Repository
	{
        public override IQueryable<客戶資料> All()
        {
            return base.All().Where(p => p.is_delete == false);
        }

        public 客戶資料 Get客戶資料(int id)
        {
            return base.All().FirstOrDefault(p => p.Id == id);
        }

        public override void Delete(客戶資料 entity)
        {
            // -> 可用以下code跳過驗證
            this.UnitOfWork.Context.Configuration.ValidateOnSaveEnabled = false;
            entity.is_delete = true;
        }

        public List<SelectListItem> GetListItem()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            var data = this.All().DistinctBy(p => p.客戶分類);

            items.Add(new SelectListItem { Text = "default", Value = "default" });
            foreach (var rec in data)
            {
                items.Add(new SelectListItem { Text = rec.客戶分類, Value = rec.客戶分類 });
            }
            return items;
        }

        public IOrderedQueryable<客戶資料> QueryByCustomize(string sortOrder, string 分類名稱)
        {
            IQueryable<客戶資料> data = this.All();            
            if (分類名稱 != null && 分類名稱 != "")
            {
                if (分類名稱 == "default")
                {
                    data = this.All();
                }
                else
                {
                    data = this.All().Where(p => p.客戶分類 == 分類名稱);
                }                
            }
            IOrderedQueryable<客戶資料> result = this.All().OrderBy(s => s.客戶名稱);
            switch (sortOrder)
            {
                case "CustomerNameSort":
                    //result = this.All().OrderBy(s => s.客戶名稱);
                    result = data.OrderBy(s => s.客戶名稱);
                    break;
                case "CustomerNameDesc":
                    //result = this.All().OrderByDescending(s => s.客戶名稱);
                    result = data.OrderByDescending(s => s.客戶名稱);
                    break;
                case "CustomerClassifySort":
                    //result = this.All().OrderBy(s => s.客戶分類);
                    result = data.OrderBy(s => s.客戶分類);
                    break;
                case "CustomerClassifyDesc":
                    //result = this.All().OrderByDescending(s => s.客戶分類);
                    result = data.OrderByDescending(s => s.客戶分類);
                    break;
                case "InvoiceSort":
                    //result = this.All().OrderBy(s => s.統一編號);
                    result = data.OrderBy(s => s.統一編號);
                    break;
                case "InvoiceDesc":
                    //result = this.All().OrderByDescending(s => s.統一編號);
                    result = data.OrderByDescending(s => s.統一編號);
                    break;
                case "PhoneSort":
                    //result = this.All().OrderBy(s => s.電話);
                    result = data.OrderBy(s => s.電話);
                    break;
                case "PhoneDesc":
                    //result = this.All().OrderByDescending(s => s.電話);
                    result = data.OrderByDescending(s => s.電話);
                    break;
                case "FaxSort":
                    //result = this.All().OrderBy(s => s.傳真);
                    result = data.OrderBy(s => s.傳真);
                    break;
                case "FaxDesc":
                    //result = this.All().OrderByDescending(s => s.傳真);
                    result = data.OrderByDescending(s => s.傳真);
                    break;
                case "AddressSort":
                    //result = this.All().OrderBy(s => s.地址);
                    result = data.OrderBy(s => s.地址);
                    break;
                case "AddressDesc":
                    //result = this.All().OrderByDescending(s => s.地址);
                    result = data.OrderByDescending(s => s.地址);
                    break;
                case "EmailSort":
                    //result = this.All().OrderBy(s => s.Email);
                    result = data.OrderBy(s => s.Email);
                    break;
                case "EmailDesc":
                    //result = this.All().OrderByDescending(s => s.Email);
                    result = data.OrderByDescending(s => s.Email);
                    break;
                default:
                    //result = this.All().OrderBy(s => s.客戶名稱);
                    result = data.OrderBy(s => s.客戶名稱);
                    break;
            }

            return result;
        }
    }

	public  interface I客戶資料Repository : IRepository<客戶資料>
	{

	}
}