using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MiddleTier
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class UserAccessService : IUserAccess
    {
        public bool Authenticate(string userId, bool mobile, int provider)
        {
            var data = new DataAccess();
            var p = new Dictionary<string, object>();
            p.Add("@userId", userId);
            p.Add("@code", provider);
            data.ExecuteQuery("sp_Authenticate", p);

            return true;
        }

        public bool ValidateAccess(string userName, string userId)
        {
            var data = new DataAccess();
            var p = new Dictionary<string, object>();
            p.Add("@userId", userId);
            p.Add("@code", new Random().Next(7) + 2);
            data.ExecuteQuery("sp_ValidateUserAccess", p);

            return true;
        }
    }
}
