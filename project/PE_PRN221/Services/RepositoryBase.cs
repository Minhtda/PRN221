﻿using Microsoft.EntityFrameworkCore;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
	public class RepositoryBase<T> where T : class
	{
		private readonly ITDepartContext _dbContext;
		private readonly DbSet<T> _dbSet;
		public RepositoryBase(ITDepartContext dBContext)
		{
			_dbContext = dBContext;
			_dbSet = _dbContext.Set<T>();
		}
		public IQueryable<T> GetAll()
		{
			return _dbSet;
		}
		public void Add(T item)
		{
			_dbSet.Add(item);
			_dbContext.SaveChanges();
		}
		public void Delete(T item)
		{
			_dbSet.Remove(item);
			_dbContext.SaveChanges();
		}
		public void Update(T item)
		{
			var tracker = _dbContext.Attach(item);
			tracker.State = EntityState.Modified;
			_dbContext.SaveChanges();
		}
		public T GetById(object id)
		{
			return _dbSet.Find(id);
		}
	}
}

