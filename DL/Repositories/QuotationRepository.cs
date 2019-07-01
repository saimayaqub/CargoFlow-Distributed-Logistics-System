using DL.Infrastructure;
using DL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DL.Repositories
{
    public class QuotationRepository : RepositoryBase<Quotation>, IQuotationRepository
    {
        public QuotationRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
            
        }
        public override void Add(Quotation q)
        {
            this.DataContext.Quotation.Add(q);
            this.DataContext.SaveChanges();
        }
        public void Edit(Quotation p)
        {
            this.DataContext.Entry(p).State = EntityState.Modified;
            this.DataContext.SaveChanges();
        }

        public Quotation FindById(int Id)
        {
            var result = (from q in this.DataContext.Quotation where q.QuotationId == Id select q).FirstOrDefault();
            return result;
        }

        public IEnumerable<Quotation> GetQuotations()
        {
            return this.DataContext.Quotation;
        }
        public void Remove(int Id)
        {
            Quotation p = this.DataContext.Quotation.Find(Id);
            this.DataContext.Quotation.Remove(p);
            this.DataContext.SaveChanges();
        }

    }
    public interface IQuotationRepository : IRepository<Quotation>
    {
    }
}