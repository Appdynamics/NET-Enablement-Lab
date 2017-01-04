using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontEnd
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            const string providerKey = "_provider";

            bool mobile = false;
            int authType = 0;

            if (!string.IsNullOrEmpty(Request.Headers[providerKey]))
            {
                switch (Request.Headers[providerKey])
                {
                    case "1": // iOS
                        mobile = true;
                        authType = 1;
                        break;

                    case "2": // Android
                        mobile = true;
                        authType = 2;
                        break;

                    case "3": // Windows phone
                        mobile = true;
                        authType = 3;
                        break;

                    default: // Web
                        break;

                }

                new UserAccessService.UserAccessServiceClient().Authenticate(new Guid().ToString(), mobile, authType);
            }
        }
    }
}