using HotelListing.Data;
using HotelListing.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;
        private IGenericRepository<Country> _countries;
        private IGenericRepository<Hotel> _hotels;
        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
        }
        //(??=) if country null then
        public IGenericRepository<Country> Countries => _countries??=new GenericRepository<Country>(_context);

        public IGenericRepository<Hotel> Hotels => _hotels??=new GenericRepository<Hotel> (_context);

        public void Dispose()
        {
            //it will dispose the unnessary garbage collection //after the operation is used
            _context.Dispose();
           // GC is for garbage collector
            GC.SuppressFinalize(this);


        }

        public async Task save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
