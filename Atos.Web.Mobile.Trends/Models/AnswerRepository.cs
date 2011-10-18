using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Atos.Web.Mobile.Trends.Models
{ 
    public class AnswerRepository : IAnswerRepository
    {
        AtosWebMobileTrendsContext context = new AtosWebMobileTrendsContext();

        public IQueryable<Answer> All
        {
            get { return context.Answers; }
        }

        public IQueryable<Answer> AllIncluding(params Expression<Func<Answer, object>>[] includeProperties)
        {
            IQueryable<Answer> query = context.Answers;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Answer Find(int id)
        {
            return context.Answers.Find(id);
        }

        public void InsertOrUpdate(Answer answer)
        {
            if (answer.Id == default(int)) {
                // New entity
                context.Answers.Add(answer);
            } else {
                // Existing entity
                context.Entry(answer).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var answer = context.Answers.Find(id);
            context.Answers.Remove(answer);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }

    public interface IAnswerRepository
    {
        IQueryable<Answer> All { get; }
        IQueryable<Answer> AllIncluding(params Expression<Func<Answer, object>>[] includeProperties);
        Answer Find(int id);
        void InsertOrUpdate(Answer answer);
        void Delete(int id);
        void Save();
    }
}