namespace NTS.WebServices.Controllers
{
    using ApplicationServices.Interfaces.Users;
    using Microsoft.AspNetCore.Mvc;
    using Shared;
    using System.Collections.Generic;

    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UsersController : BaseManagementController<IUser>
    {
        #region Constructors
        public UsersController(IUserManagementService userManagementService) 
            : base(userManagementService) { }
        #endregion

        // GET: api/Users
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var vv = _managementService.GetAll();
            return new string[] { "value1", "value2" };
        }

        // GET: api/Users/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Users
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Users/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
