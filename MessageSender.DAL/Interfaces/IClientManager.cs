using MessageSender.DAL.Entities;
using System;

namespace MessageSender.DAL.Interfaces
{
	public interface IClientManager : IDisposable
	{
		void Create(ClientProfile item);
	}
}