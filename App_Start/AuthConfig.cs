using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Web.WebPages.OAuth;
using Politico.Models;

namespace Politico
{
    public static class AuthConfig
    {
        public static void RegisterAuth()
        {
            // To let users of this site log in using their accounts from other sites such as Microsoft, Facebook, and Twitter,
            // you must update this site. For more information visit http://go.microsoft.com/fwlink/?LinkID=252166

            //OAuthWebSecurity.RegisterMicrosoftClient(
            //    clientId: "",
            //    clientSecret: "");

            //OAuthWebSecurity.RegisterTwitterClient(
            //    consumerKey: "KcYMu5YzGllcA5tNfSWQ",
            //    consumerSecret: "PGcd4ZlTxd3eAj4CFiFXEyHE3tnONGz2Ihf11KJTSA");

            //OAuthWebSecurity.RegisterFacebookClient(
            //    appId: "420336934736385",
            //    appSecret: "586ce19792ec7ed0fe79300004a99534");

            //OAuthWebSecurity.RegisterGoogleClient();
        }
    }
}
