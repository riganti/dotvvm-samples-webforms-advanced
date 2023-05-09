using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotVVM.Samples
{
    public static class Extensions
    {
        public static int GetIntQuery(this HttpContext context, string parameterName)
        {
            if (int.TryParse(GetQuery(context, parameterName), out var value))
            {
                return value;
            }
            return 0;
        }

        public static bool GetBoolQuery(this HttpContext context, string parameterName)
        {
            if (bool.TryParse(GetQuery(context, parameterName), out var value))
            {
                return value;
            }
            return false;
        }

        public static string GetQuery(this HttpContext context, string parameterName)
        {
            return context.Request.Params.GetValues(parameterName)?[0];
        }
    }
}