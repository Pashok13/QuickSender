using MessageSender.DAL.Context;
using MessageSender.DAL.Entities;
using MessageSender.DAL.Interfaces;

namespace MessageSender.DAL.Repositories
{
	public class ClientManager : IClientManager
	{
		public ApplicationContext Database { get; set; }
		public ClientManager(ApplicationContext db)
		{
			Database = db;
		}

		public void Create(ClientProfile item)
		{
			Database.ClientProfiles.Add(item);
			Database.SaveChanges();
		}

		public void Dispose()
		{
			Database.Dispose();
		}
	}
}