// Infrastructure/Repositories/ProductRepository.cs
using Microsoft.EntityFrameworkCore;
using ECommerce.Domain.Entities;
using ECommerce.Application.Interfaces;
using ECommerce.Infrastructure.Persistence;

namespace ECommerce.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Product?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        return await _context.Products.FindAsync([id], ct);
    }

    public async Task<IEnumerable<Product>> GetAllAsync(CancellationToken ct = default)
    {
        return await _context.Products
            .AsNoTracking()
            .OrderBy(p => p.Name)
            .ToListAsync(ct);
    }

    public async Task<IEnumerable<Product>> SearchByNameAsync(string term, CancellationToken ct = default)
    {
        return await _context.Products
            .AsNoTracking()
            .Where(p => p.Name.Contains(term))
            .ToListAsync(ct);
    }

    public async Task<bool> ExistsAsync(Guid id, CancellationToken ct = default)
    {
        return await _context.Products.AnyAsync(p => p.Id == id, ct);
    }

    public async Task AddAsync(Product product, CancellationToken ct = default)
    {
        await _context.Products.AddAsync(product, ct);
        await _context.SaveChangesAsync(ct);
    }

    public async Task UpdateAsync(Product product, CancellationToken ct = default)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync(ct);
    }

    public async Task DeleteAsync(Guid id, CancellationToken ct = default)
    {
        var product = await _context.Products.FindAsync([id], ct);
        if (product != null)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync(ct);
        }
    }
}