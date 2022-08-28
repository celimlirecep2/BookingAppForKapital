using MyProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Core.Abstract
{
    public interface IGenericRepositoy<T> where T : class
    {
        Task<T> GetAsync(int? id);
        Task<T> GetLastAsync(Expression<Func<T,int>> filter);
        Task<TResult> GetAsync<TResult>(int? id);
        Task<List<T>> GetAllAsync();
        Task<List<TResult>> GetAllAsync<TResult>();
        //Task<PagesResult<TResult>> GetAllAsync<TResult>(QueryParameters queryParameters);
        Task<T> AddAsync(T entity);
        Task<TResult> AddAsync<TSource, TResult>(TSource source);
        Task UpdateAsync(T entity);
        Task UpdateAsync<TSource>(int id, TSource source);
        Task DeleteAsync(int id);
        Task<bool> Exist(int id);

    }
}
