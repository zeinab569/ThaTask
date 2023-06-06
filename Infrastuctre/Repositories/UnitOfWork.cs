using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastuctre.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ShoppingContext _context;
        private Hashtable _reposatories;

        public UnitOfWork(ShoppingContext Context)
        {
            _context=Context;
        }

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose(); 
        }

        public IGenericRepo<TEntity> Repository<TEntity>() where TEntity : BaseEntity
        {
            if (_reposatories == null)
            {
                _reposatories = new Hashtable();
            }
            var type=typeof(TEntity).Name;
            if (!_reposatories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepo<>);
                var reposatoryInstance=Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)),_context);
                _reposatories.Add(type, reposatoryInstance);    
            }
            return (IGenericRepo<TEntity>) _reposatories[type];
        }
    }
}
