using System.Data.Entity;

namespace MVC_HW_01.Models
{
	public interface IUnitOfWork
	{
		DbContext Context { get; set; }
		void Commit();
		bool LazyLoadingEnabled { get; set; }
		bool ProxyCreationEnabled { get; set; }
		string ConnectionString { get; set; }
	}
}