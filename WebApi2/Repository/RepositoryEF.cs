using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi2_DAL;

namespace WebApi2.Repository
{
    public class RepositoryEF : IRepository
    {
        private TestAPIEntities _db;

        public RepositoryEF()
        {
            _db = new TestAPIEntities();
            _db.Database.Log = s=> System.Diagnostics.Debug.WriteLine(s);
        }

        public IQueryable<SimpleTable> GetSimpleValues()
        {
            return _db.SimpleTable;
        }

        public void RemoveRowsFromSimpleTable()
        {
            _db.Database.ExecuteSqlCommand("TRUNCATE TABLE [SimpleTable]");
        }

        public void SaveSimpleValues(SimpleTable[] values)
        {
            _db.SimpleTable.AddRange(values);
            _db.SaveChanges();
        }
    }
}