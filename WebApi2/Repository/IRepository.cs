using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi2_DAL;

namespace WebApi2.Repository
{
    public interface IRepository
    {
        IQueryable<SimpleTable> GetSimpleValues();
        void SaveSimpleValues(SimpleTable[] values);
        void RemoveRowsFromSimpleTable();
    }
}