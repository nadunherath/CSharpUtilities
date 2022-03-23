using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpUtilities
{
    public static class CookiesManager
    {
        //public static void SetCookie(string key, string value, int days = 2000)
        //{
        //    var context = System.Web.HttpContext.Current;
        //    context.Response.SetCookie(new HttpCookie(key, value) { Expires = days == 0 ? default(DateTime) : DateTime.UtcNow + TimeSpan.FromDays(days) });
        //}

        //public static string GetCookie(string key)
        //{
        //    var context = System.Web.HttpContext.Current;
        //    var cookie = context.Request.Cookies[key];
        //    if (cookie == null)
        //        return null;
        //    return cookie.Value;
        //}

        //public static void DeleteCookie(string key)
        //{
        //    var context = System.Web.HttpContext.Current;
        //    var cookie = context.Response.Cookies[key];
        //    if (cookie != null)
        //        cookie.Value = "";
        //}
    }
}
