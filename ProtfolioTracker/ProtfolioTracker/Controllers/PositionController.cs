using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Cors;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ProtfolioTracker.Controllers
{
    [Route("api/[controller]")]
    public class PositionController : Controller
    {
        private readonly IPositionRepository _repo;
        public PositionController(IPositionRepository repo)
        {
            _repo = repo ?? throw new NullReferenceException("IPositionRepository is null");
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<ITransaction> Get()
        {
            //return new string[] { "value1", "value2" };
            return _repo.GetPosition(1);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
