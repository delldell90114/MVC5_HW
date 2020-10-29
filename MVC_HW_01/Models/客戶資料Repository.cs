using System;
using System.Linq;
using System.Collections.Generic;

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
    }

	public  interface I客戶資料Repository : IRepository<客戶資料>
	{

	}
}