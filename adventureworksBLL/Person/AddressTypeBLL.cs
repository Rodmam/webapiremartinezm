using adventureworksEntities;
using adventureworksDOL;
using adventureworksEntities.Runtime;
using System.Collections.Generic;

namespace adventureworksBLL.Person
{
    public class AddressTypeBLL
    {
        public static List<AddressType>Get(int id)
        {
            return AddressTypeDOL.Get(id);
        }

        public static Results Post(AddressType addresstype)
        {
            return AddressTypeDOL.Insert(addresstype);
        }

        public static Results Put(AddressType addresstype)
        {
            return AddressTypeDOL.Insert(addresstype);
        }

        public static Results Delete(int id)
        {
            return AddressTypeDOL.Delete(id);
        }

    }
}
