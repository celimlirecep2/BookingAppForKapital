using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MyProject.Core.Abstract;
using MyProject.Core.Models;
using MyProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Core.Repository
{
    public class GenericRepository<T> : IGenericRepositoy<T> where T : class
    {
        private readonly MyProjectDbContext _context;
        private readonly IMapper _mapper;

        public GenericRepository(MyProjectDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<TResult> AddAsync<TSource, TResult>(TSource source)
        {
            var entity = _mapper.Map<T>(source);
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<TResult>(entity);
        }

      

        public  async Task DeleteAsync(int id)
        {
            var entity = await GetAsync(id);
            if (entity is null)
                throw new ArgumentNullException(nameof(DeleteAsync));
            
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Exist(int id)
        {
            var entity = await GetAsync(id);
            return entity != null;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

       

        public async Task<List<TResult>> GetAllAsync<TResult>()
        {
            return await _context.Set<T>()
                .ProjectTo<TResult>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<T> GetAsync(int? id)
        {
            if (id == null)
            {
                return null;
            }
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<TResult> GetAsync<TResult>(int? id)
        {
            var result = await _context.Set<T>().FindAsync(id);
            if (result is null)
                throw new ArgumentNullException(nameof(GetAsync));
            return _mapper.Map<TResult>(result);
        }
        public async Task<T> GetLastAsync(Expression<Func<T, int>> filter)
        {
            return await _context.Set<T>().OrderBy(filter).LastAsync();
        }


        public async Task UpdateAsync(T entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync<TSource>(int id, TSource source)
        {
            var entity = await GetAsync(id);
            if (entity == null)
                throw new ArgumentNullException(nameof(UpdateAsync));
            _mapper.Map(source, entity);
            _context.Update(entity);
            await _context.SaveChangesAsync();

        }
    }
}
