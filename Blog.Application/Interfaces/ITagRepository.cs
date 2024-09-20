using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Domain.Entities;

namespace Blog.Application.Interfaces;

public interface ITagRepository
{
    Task<IList<Tag>> GetAllAsync();
    Task<Tag?> GetById(int id);
    Task<IEnumerable<Tag>> GetByVacantIdAsync(int vacantId);
    Task<Tag?> AddAsync(Tag tag);
    Task<bool> RemoveAsync(int id);
}
