using System;
using FiorelloBackend.Data;
using FiorelloBackend.Models;
using FiorelloBackend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FiorelloBackend.Services
{
    public class ArchiveService : IArchiveService
    {
        private readonly AppDbContext _context;

        public ArchiveService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<CategoryArchive>> GetCategoryArchive()
        {
            return await _context.CategoryArchives.ToListAsync();
        }
    }
}

