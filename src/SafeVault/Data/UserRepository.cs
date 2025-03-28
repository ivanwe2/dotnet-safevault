using Microsoft.EntityFrameworkCore;
using SafeVault.Models;

namespace SafeVault.src.SafeVault.Data;

public class UserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<User?> GetUserByIdAsync(int userId)
    {
        return await _context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.UserID == userId);
    }
}