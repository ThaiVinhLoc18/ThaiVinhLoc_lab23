﻿using System.Web;
using System.Web.Mvc;

namespace WebBook_lab23
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
