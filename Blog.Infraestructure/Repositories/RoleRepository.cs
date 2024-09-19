using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Application.Interfaces;
using Blog.Infraestructure.Context;
using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infraestructure.Repositories;

public class RoleRepository : Repository, IRoleRepository
{
    public RoleRepository(DatabaseContext context) : base(context)
    {
    }
    public async Task<Role?> AddAsync(Role role)
    {
        await _context.Roles.AddAsync(role);
        await _context.SaveChangesAsync();

        var roleModel = await _context.Roles.FirstOrDefaultAsync(r => r.Name == role.Name);

        return roleModel;
    }

    public async Task<bool> Exists(Role role)
    {
        var roleModel = await _context.Roles.FirstOrDefaultAsync(r => r.Name == role.Name);

        return roleModel != null;
    }

    public async Task<IEnumerable<Role>> GetAllAsync()
    {
        return await _context.Roles.ToListAsync();
    }

    public async Task<Role?> GetByIdAsync(int id)
    {
        return await _context.Roles.FindAsync(id);
    }

    public async Task<bool> RemoveAsync(int id)
    {
        var role = await _context.Roles.FindAsync(id);

        if (role == null)
            return false;
        
        _context.Roles.Remove(role);
        await _context.SaveChangesAsync();
        return true;
    }
}