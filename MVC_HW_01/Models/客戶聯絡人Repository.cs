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

        public bool IsEmailDuplicated(string email)
        {
            if (base.All().Where(p => p.Email == email).Count() == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }

	public  interface I客戶聯絡人Repository : IRepository<客戶聯絡人>
	{

	}
}