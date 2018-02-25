using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecurityAnalysis.Core.RunTime
{
    public static class HttpContextManager
    {
        public static string MapServerPath(string path)
        {
            if (HttpContext.Current == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Server.MapPath(path);
            } 
        }
    }
}