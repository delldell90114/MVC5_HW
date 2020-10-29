using System;
using System.Linq;
using System.Collections.Generic;

namespace MVC_HW_01.Models
{
	public  class 客戶銀行資訊Repository : EFRepository<客戶銀行資訊>, I客戶銀行資訊Repository
	{
        public override IQueryable<客戶銀行資訊> All()
        {
            return base.All().Where(p => p.is_delete == false);
        }

        public 客戶銀行資訊 Get客戶銀行資訊(int id)
        {
            return base.All().FirstOrDefault(p => p.Id == id);
        }

        public override void Delete(客戶銀行資訊 entity)
        {
            // -> 可用以下code跳過驗證
            this.UnitOfWork.Context.Configuration.ValidateOnSaveEnabled = false;
            entity.is_delete = true;
        }
    }

	public  interface I客戶銀行資訊Repository : IRepository<客戶銀行資訊>
	{

	}
}