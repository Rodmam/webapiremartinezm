using adventureworksBLL.Person;
using adventureworksEntities;
using adventureworksEntities.Runtime;
using System.Collections.Generic;
using System.Web.Http;

namespace adventureworksAPI.Controllers
{
    public class AddressTypeController : ApiController
    {
        // GET: api/AddressType
        public IEnumerable<AddressType> Get(int id)
        {
            return AddressTypeBLL.Get(id);
        }

        // POST: api/AddressType
        public Results Post([FromBody]AddressType addresstype)
        {
            return AddressTypeBLL.Post(addresstype);
        }

        // PUT: api/AddressType/5
        public Results Put([FromBody]AddressType addresstype)
        {
            return AddressTypeBLL.Put(addresstype);
        }

        // DELETE: api/AddressType/5
        public Results Delete(int id)
        {
            return AddressTypeBLL.Delete(id);
        }
    }
}
