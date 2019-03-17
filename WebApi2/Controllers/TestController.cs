using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using WebApi2_DAL;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebApi2.Repository;

namespace WebApi2.Controllers
{
    public class TestController : ApiController
    {
        IRepository _db = null;

        // DI контейнер выберет нужную реализацию
        public TestController(IRepository rep)
        {
            _db = rep;
        }

        //HttpGet метод с или без фильтрации данных. Фильтрация работает через строку запроса (нпример ...../api/test/GetTestValues?code=2&value=Two)
        [HttpGet]
        public JsonResult<IQueryable<SimpleTable>> GetTestValues([FromUri] SimpleTable simple)
        {
            IQueryable<SimpleTable> tValues= _db.GetSimpleValues();          
            if (simple.Code!= 0)
            {
                tValues = tValues.Where(s => simple.Code == s.Code);
            }
            if (!string.IsNullOrEmpty(simple.Value))
            {
                tValues = tValues.Where(s => simple.Value == s.Value);
            }
            //var dict = new Dictionary<int, string>();
            //dict.Union(tValues.Select(t => new KeyValuePair<int, string>(t.Code,t.Value)));         
            return Json(tValues);
        }

        //HttpPost метод, принимающие json данные через тело запроса
        [HttpPost]
        public IHttpActionResult SaveTestValues([FromBody] Dictionary<int,string> values)
        {
            var data = values.OrderBy(k => k.Key).Select(p => new SimpleTable { Code = p.Key, Value = p.Value }).ToArray();
            try
            {
                _db.RemoveRowsFromSimpleTable();
                _db.SaveSimpleValues(data);
                return Ok("Данные успешно сохранены");
            }
            catch (Exception ex)
            {
                return BadRequest("Произошла ошибка!");
            }
           
        }

        // PUT api/<controller>/5
        //[HttpPut]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        // DELETE api/<controller>/5
        //public void Delete(int id)
        //{
        //}
    }
}