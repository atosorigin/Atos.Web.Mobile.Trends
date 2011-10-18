using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Atos.Web.Mobile.Trends.Models
{ 
    public class BrowserRepository : IBrowserRepository
    {
        AtosWebMobileTrendsContext context = new AtosWebMobileTrendsContext();

        public IQueryable<Browser> All
        {
            get { return context.Browsers; }
        }

        public IQueryable<Browser> AllIncluding(params Expression<Func<Browser, object>>[] includeProperties)
        {
            IQueryable<Browser> query = context.Browsers;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Browser Find(int id)
        {
            return context.Browsers.Find(id);
        }

        public void InsertOrUpdate(Browser browser)
        {
            if (browser.Id == default(int)) {
                // New entity
                context.Browsers.Add(browser);
            } else {
                // Existing entity
                context.Entry(browser).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var browser = context.Browsers.Find(id);
            context.Browsers.Remove(browser);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }

    public interface IBrowserRepository
    {
        IQueryable<Browser> All { get; }
        IQueryable<Browser> AllIncluding(params Expression<Func<Browser, object>>[] includeProperties);
        Browser Find(int id);
        void InsertOrUpdate(Browser browser);
        void Delete(int id);
        void Save();
    }
}