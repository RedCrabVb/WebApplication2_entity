using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication2_entity.Data;
using WebApplication2_entity.Service;

namespace WebApplication2_entity.Controllers
{
    public class ValuesController : ApiController
    {
        private IClass1Service _class1Service;
        private AppDbContext _appDbContext;
        public ValuesController(IClass1Service class1Service, AppDbContext appDbContext)
        {
            _class1Service = class1Service;
            _appDbContext = appDbContext;
        }

        [HttpGet]
        [Route("test_table")]
        public IEnumerable<CSharpCornerArticle> GetTestTable()
        {
            return _appDbContext.Articles.ToList();
        }        
        
        [HttpPost]
        [Route("test_table")]
        public void PostTestTable(CSharpCornerArticle article)
        {
            _appDbContext.Articles.Add(article);
        }

        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2", "value" + _class1Service.Add5(9) };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
