using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi2_DAL;

namespace WebApi2.Repository
{
    public class TestRepository : IRepository
    {
        List<SimpleTable> _db = null;

        public TestRepository()
        {
            _db = new List<SimpleTable>
            {
                new SimpleTable { Id=1, Code=3, Value="3"},
                new SimpleTable { Id=2, Code=5, Value="5"},
            };
        }

        public IQueryable<SimpleTable> GetSimpleValues()
        {
            return _db.AsQueryable();
        }

        public void RemoveRowsFromSimpleTable()
        {
            _db.Clear();
        }

        public void SaveSimpleValues(SimpleTable[] values)
        {
            _db.AddRange(values);
        }
    }
}