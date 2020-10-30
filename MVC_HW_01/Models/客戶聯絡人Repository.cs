using System;
using System.Linq;
using System.Collections.Generic;

namespace MVC_HW_01.Models
{
	public  class 客戶聯絡人Repository : EFRepository<客戶聯絡人>, I客戶聯絡人Repository
	{
        public override IQueryable<客戶聯絡人> All()
        {
            return base.All().Where(p => p.is_delete == false);
        }

        public 客戶聯絡人 Get客戶聯絡人(int id)
        {
            return base.All().FirstOrDefault(p => p.Id == id);
        }

        public override void Delete(客戶聯絡人 entity)
        {
            this.UnitOfWork.Context.Configuration.ValidateOnSaveEnabled = false;
            entity.is_delete = true;
        }

        public bool IsEmailDuplicated(int id, string email)
        {
            if (base.All().Where(p => p.Id != id && p.Email == email).Count() == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //public IOrderedQueryable<客戶聯絡人> QueryByTitle(string title)
        //{
        //    return this.All().Where(p => p.職稱 == title);
        //}

        public IOrderedQueryable<客戶聯絡人> QueryByCustomize(string sortOrder, string title)
        {
            IQueryable<客戶聯絡人> data = this.All();
            if (title != null && title != "")
            {
                data = this.All().Where(p => p.職稱 == title);

            }
            IOrderedQueryable<客戶聯絡人> result = this.All().OrderBy(s => s.客戶Id);
            switch (sortOrder)
            {
                case "TitleSort":
                    //result = this.All().OrderBy(s => s.職稱);
                    result = data.OrderBy(s => s.職稱);
                    break;
                case "TitleDesc":
                    //result = this.All().OrderByDescending(s => s.職稱);
                    result = data.OrderByDescending(s => s.職稱);
                    break;
                case "NameSort":
                    //result = this.All().OrderBy(s => s.姓名);
                    result = data.OrderBy(s => s.姓名);
                    break;
                case "NameDesc":
                    //result = this.All().OrderByDescending(s => s.姓名);
                    result = data.OrderByDescending(s => s.姓名);
                    break;
                case "EmailSort":
                    //result = this.All().OrderBy(s => s.Email);
                    result = data.OrderBy(s => s.Email);
                    break;
                case "EmailDesc":
                    //result = this.All().OrderByDescending(s => s.Email);
                    result = data.OrderByDescending(s => s.Email);
                    break;
                case "CellphoneSort":
                    //result = this.All().OrderBy(s => s.手機);
                    result = data.OrderBy(s => s.手機);
                    break;
                case "CellphoneDesc":
                    //result = this.All().OrderByDescending(s => s.手機);
                    result = data.OrderByDescending(s => s.手機);
                    break;
                case "PhoneSort":
                    //result = this.All().OrderBy(s => s.電話);
                    result = data.OrderBy(s => s.電話);
                    break;
                case "PhoneDesc":
                    //result = this.All().OrderByDescending(s => s.電話);
                    result = data.OrderByDescending(s => s.電話);
                    break;
                case "CustomerNameSort":
                    //result = this.All().OrderBy(s => s.客戶資料.客戶名稱);
                    result = data.OrderBy(s => s.客戶資料.客戶名稱);
                    break;
                case "CustomerNameDesc":
                    //result = this.All().OrderByDescending(s => s.客戶資料.客戶名稱);
                    result = data.OrderByDescending(s => s.客戶資料.客戶名稱);
                    break;
                default:
                    //result = this.All().OrderBy(s => s.客戶Id);
                    result = data.OrderBy(s => s.客戶Id);
                    break;
            }

            return result;
        }
    }

	public  interface I客戶聯絡人Repository : IRepository<客戶聯絡人>
	{

	}
}