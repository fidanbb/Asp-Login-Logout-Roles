using System;
using FiorelloBackend.Models;

namespace FiorelloBackend.Services.Interfaces
{
	public interface IArchiveService
	{
		Task<List<CategoryArchive>> GetCategoryArchive();
	}
}

