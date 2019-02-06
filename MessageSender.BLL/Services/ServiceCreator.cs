using MessageSender.BLL.Interfaces;
using MessageSender.DAL.Repositories;

namespace MessageSender.BLL.Services
{
	public class ServiceCreator : IServiceCreator
	{
		public IUserService CreateUserService(string connection)
		{
			return new UserService(new IdentityUnitOfWork(connection));
		}
	}
}
