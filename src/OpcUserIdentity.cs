using Opc.Ua;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace OpcPublisher_CDS
{    
    // Add by Kevin Kao for handle UA Server UserIdentity
    class UserIDinUAServer
    {
        public string UAEndPointUrl;
        public string UserId;
        public string UserPassword;

        public UserIDinUAServer(string endPointUrl, string userId, string userPassword)
        {
            UAEndPointUrl = endPointUrl;
            UserId = userId;
            UserPassword = userPassword;
        }
    }
    public class OpcUserIdentity
    {
        static List<UserIDinUAServer> userIdentityList = new List<UserIDinUAServer>();
        public static void AddIdentity(string endpointUrl, string userId, string userPassword)
        {
            foreach (var userIdentity in userIdentityList)
            {
                if (userIdentity.UAEndPointUrl == endpointUrl)
                {
                    userIdentity.UserId = userId;
                    userIdentity.UserPassword = userPassword;
                    return;
                }
            }
            userIdentityList.Add(new UserIDinUAServer(endpointUrl, userId, userPassword));            
        }
        public static UserIdentity GetUserIdentity(string endpointUrl)
        {
            foreach (var userIdentity in userIdentityList)
            {
                if (userIdentity.UAEndPointUrl == endpointUrl)
                    return new UserIdentity(userIdentity.UserId, userIdentity.UserPassword);
            }

            return null;            
        }
    }
}
