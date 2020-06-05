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


    public class ProdutoRepository
    {

        private readonly ApplicationDbContext _context;

        public ProdutoRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<Produto> ObterProdutoFornecedor(Guid id)
        {
            return await _context.Produtos.AsNoTracking().Include(f => f.Fornecedor)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Produto>> ObterProdutosFornecedores()
        {
            return await _context.Produtos.AsNoTracking().Include(f => f.Fornecedor)
                .OrderBy(p => p.Nome).ToListAsync();
        }

        public async Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid fornecedorId)
        {
            return await Procurar(p => p.FornecedorId == fornecedorId);
        }

        public async Task<IEnumerable<Produto>> Procurar(
            Expression<Func<Produto, bool>> predicado)
        {
            return await _context.Produtos.AsNoTracking()
                .Where(predicado).ToListAsync();
        }

        public virtual async Task<Produto> ObterPorId(Guid id)
        {
            return await _context.Produtos.FindAsync(id);
        }

        public async Task<List<Produto>> ObterTodos()
        {
            return await _context.Produtos.ToListAsync();
        }

        public async Task Adicionar(Produto entity)
        {
            _context.Produtos.Add(entity);
            await SaveChanges();
        }

        public async Task Atualizar(Produto entity)
        {
            _context.Produtos.Update(entity);
            await SaveChanges();
        }

        public async Task Remover(Guid id)
        {
            _context.Produtos.Remove(new Produto { Id = id });
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }
    }

    }

    