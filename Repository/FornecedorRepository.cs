using Microsoft.EntityFrameworkCore;
using ProdutosWeb.Data;
using ProdutosWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProdutosWeb.Repository
{
    public class FornecedorRepository
    {
        private readonly ApplicationDbContext _context;

        public FornecedorRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<Fornecedor> ObterFornecedorEndereco(Guid id)
        {
            return await _context.Fornecedores.AsNoTracking()
                .Include(c => c.Endereco)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid id)
        {
            return await _context.Fornecedores.AsNoTracking()
                .Include(c => c.Produtos)
                .Include(c => c.Endereco)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Fornecedor>> Procurar(
            Expression<Func<Fornecedor, bool>> predicado)
        {
            return await _context.Fornecedores.AsNoTracking()
                .Where(predicado).ToListAsync();
        }

        public virtual async Task<Fornecedor> ObterPorId(Guid id)
        {
            return await _context.Fornecedores.FindAsync(id);
        }

        public async Task<List<Fornecedor>> ObterTodos()
        {
            return await _context.Fornecedores.ToListAsync();
        }

        public async Task Adicionar(Fornecedor entity)
        {
            _context.Fornecedores.Add(entity);
            await SaveChanges();
        }

        public async Task Atualizar(Fornecedor entity)
        {
            _context.Fornecedores.Update(entity);
            await SaveChanges();
        }

        public async Task Remover(Guid id)
        {
            _context.Fornecedores.Remove(new Fornecedor { Id = id });
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }


    }
}
