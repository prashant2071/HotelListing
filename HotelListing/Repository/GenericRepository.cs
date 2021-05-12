using HotelListing.Data;
using HotelListing.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HotelListing.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DatabaseContext _context;
        private readonly DbSet<T> _db;

        public GenericRepository(DatabaseContext context)
        {
            _context = context;
            _db = _context.Set<T>();
        }
        public async Task Delete(int id)
        {
            var del = await _db.FindAsync(id);
            _db.Remove(del);
        }

        public void DeleteRange(IEnumerable<T> entites)
        {
           _db.RemoveRange(entites);
        }

        public async Task<T> Get(Expression<Func<T, bool>> expression, List<string> includes = null)
        {
            IQueryable<T> query = _db;
            if (includes != null)
            {
                foreach (var includeProperty in includes)
                {
                    query = query.Include(includeProperty);
                }
            }
            //AsNoTracking Data retrive garney bela track gardoina//linq bata return gareko value track nagarney
            //Expression<Func<T, bool>> expression this allows us to put in lamda expression
            //For GetMethod we need return 
            return await query.AsNoTracking().FirstOrDefaultAsync(expression);
            
        }

        public async Task<IList<T>> GetAll(Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<string> includes = null)
        {
            IQueryable<T> query = _db;
            //epxression xa ki noi xa vane teshko adhar ma query
            if (expression != null)
            {
                query = query.Where(expression);
            }

            if (includes != null)
            {
                foreach (var includeProperty in includes)
                {
                    query = query.Include(includeProperty);
                }
            }
            //OrderBy is on the basis on Ascending order
            if (orderBy != null)
            {
                query =orderBy(query);
            }
 

            return await query.AsNoTracking().ToListAsync();
        }

        public async Task Insert(T entity)
        {
           await _db.AddAsync(entity);
        }

        public async Task InsertRange(IEnumerable<T> entities)
        {
            await _db.AddRangeAsync(entities);
        }

        public void Update(T entity)
        {
            _db.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
