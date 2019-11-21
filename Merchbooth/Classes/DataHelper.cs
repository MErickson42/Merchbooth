using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Merchbooth.Classes;

namespace Merchbooth.Classes
{
    public class DataHelper
    {
        /// <summary>
        /// Get Current user lggin (from Session) or a BLANK/Non Initialiazed one...
        /// </summary>
        /// <returns></returns>
        public static UserDetails GetUserFromSession()
        {
            UserDetails ud = new UserDetails();
            UserDetails udBLANK = new UserDetails();

            if (HttpContext.Current.Session["UserDetails"] != null)
            {
                ud = HttpContext.Current.Session["UserDetails"] as UserDetails;

                if (!ud.isValidUser)
                {
                    ud = null;
                    ud = udBLANK;
                }
            }

            return ud;
        }

        public static bool IsLoggedIn()
        {
            bool loggedIn = false;

            if (HttpContext.Current.Session["UserDetails"] != null)
            {
                UserDetails ud = HttpContext.Current.Session["UserDetails"] as UserDetails;

                if (ud.isValidUser)
                {
                    loggedIn = true;
                }
            }

            return loggedIn;
        }

        /// <summary>
        /// MRB 03-29-17 - Checks current Logged in user (if ONE) to see if they are a SysAdmin.
        /// Also avaialable from the userdetails object itself.
        /// </summary>
        public static bool IsSystemAdmin()
        {
            bool IsAdmin = false;

            if (HttpContext.Current.Session["UserDetails"] != null)
            {
                UserDetails ud = HttpContext.Current.Session["UserDetails"] as UserDetails;

                if (ud.IsSystemAdmin)
                {
                    IsAdmin = true;
                }
            }

            return IsAdmin;
        }

        public static bool ValidateUser(string Username, string Password)
        {
            SiteDCDataContext _siteContext = new SiteDCDataContext();
            bool validUser = false;

            var queryUsers = from u in _siteContext.TBands
                             where u.strEmail== Username && u.strPassword== Password
                             select u;

            if (queryUsers.Count() > 0)
            {
                foreach (TBand user in queryUsers)
                {
                    UpdateUserDetailsSession(user.intBandID);

                    validUser = true;
                }
            }


            return validUser;
        }

        public static bool UpdateUserDetailsSession(int UserKey)
        {
            UserDetails ud = GetUserDetails(UserKey);

            HttpContext.Current.Session.Clear();

            HttpContext.Current.Session.Add("UserDetails", ud);

            return true;
        }

        public static UserDetails GetUserDetails(int UserKey)
        {
            UserDetails ud = new UserDetails();
            SiteDCDataContext _siteContext = new SiteDCDataContext();

            var queryUsers = from u in _siteContext.TBands
                             orderby u.strBandName
                             where u.intBandID == UserKey
                             select u;

            foreach (TBand user in queryUsers)
            {
                ud.UserKey = user.intBandID;
                ud.isValidUser = true;
                ud.Username = user.strEmail;
                ud.Name = user.strBandName;
             
                
            }

            return ud;
        }



        //copied these for customer ben_11_21
        public static bool ValidateCustomer(string Username, string Password)
        {
            SiteDCDataContext _siteContext = new SiteDCDataContext();
            bool validUser = false;

            var queryUsers = from u in _siteContext.TCustomers
                             where u.strEmail == Username && u.strPassword == Password
                             select u;

            if (queryUsers.Count() > 0)
            {
                foreach (TCustomer user in queryUsers)
                {
                    UpdateUserDetailsSession(user.intCustomerID);

                    validUser = true;
                }
            }


            return validUser;
        }


        public static UserDetails GetCustomerDetails(int UserKey)
        {
            UserDetails ud = new UserDetails();
            SiteDCDataContext _siteContext = new SiteDCDataContext();

            var queryUsers = from u in _siteContext.TCustomers
                             orderby u.strLastName
                             where u.intCustomerID == UserKey
                             select u;

            foreach (TCustomer user in queryUsers)
            {
                ud.UserKey = user.intCustomerID;
                ud.isValidUser = true;
                ud.Username = user.strEmail;
                ud.Name = user.strLastName + user.strLastName;


            }

            return ud;
        }
    }
}