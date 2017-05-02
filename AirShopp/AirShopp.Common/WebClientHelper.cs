using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace AirShopp.Common
{
    public class WebClientHelper
    {
        /// <summary>
        /// Set Cookie
        /// </summary>
        /// <param name="cookieName"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expires"></param>
        /// <returns></returns>
        public static HttpCookie SetCookie(string cookieName, string key, string value, DateTime? expires)
        {
            HttpResponse response = System.Web.HttpContext.Current.Response;
            if (response != null)
            {
                HttpCookie cookie = response.Cookies[cookieName];
                if (cookie != null)
                {
                    if (!string.IsNullOrEmpty(key) && cookie.HasKeys)
                        cookie.Values.Set(key, value);
                    else
                        if (!string.IsNullOrEmpty(value))
                            cookie.Value = value;
                    if (expires != null)
                        cookie.Expires = expires.Value;
                    response.SetCookie(cookie);
                }
                return cookie;
            }
            else
            {
                return null;
            }
        }

        /// <summary> 
        /// Get Cookie 
        /// </summary> 
        /// <param name="cookieName"></param> 
        /// <returns></returns> 
        public static HttpCookie GetCookie(string cookieName)
        {
            HttpRequest request = System.Web.HttpContext.Current.Request;
            if (request != null)
                return request.Cookies[cookieName];
            return null;
        }
        /// <summary>
        /// Delete Cookies
        /// </summary>
        /// <param name="cookieName"></param>
        /// <param name="key"></param>
        public static void RemoveCookie(string cookieName, string key)
        {
            HttpResponse response = System.Web.HttpContext.Current.Response;
            if (response != null)
            {
                HttpCookie cookie = response.Cookies[cookieName];
                if (cookie != null)
                {
                    cookie.Expires = DateTime.Now.AddDays(-1);
                    /* Remove just not transfer data from server, not delete
                    if (!string.IsNullOrEmpty(key))
                        cookie.Values.Remove(key);
                    else
                        response.Cookies.Remove(cookieName);
                     * */
                }
            }
        }


        /// <summary>
        /// Get client ip address (ignore proxy)
        /// </summary>
        /// <returns>if failed, return 127.0.0.1</returns>
        public static string GetHostAddress()
        {
            string userHostAddress = HttpContext.Current.Request.UserHostAddress;

            if (string.IsNullOrEmpty(userHostAddress))
            {
                userHostAddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }

            //最后判断获取是否成功，并检查IP地址的格式（检查其格式非常重要）
            if (!string.IsNullOrEmpty(userHostAddress) && IsIP(userHostAddress))
            {
                return userHostAddress;
            }
            return "127.0.0.1";
        }

        /// <summary>
        /// Check ip address format.
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        private static bool IsIP(string ip)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(ip, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");
        }

    }
}
