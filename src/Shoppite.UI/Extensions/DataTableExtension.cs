using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using NinjaNye.SearchExtensions;

namespace Shoppite.UI.Extensions
{
    public static class DataTableExtension
    {
        //public static ResponseData<T> DataTable<T>(IQueryable<T> dataset, HttpContext httpContext, params Expression<Func<T, string>>[] stringProperties) where T : class
        //{
        //    ResponseData<T> responseData = new ResponseData<T>();
        //    try
        //    {
        //        var draw = httpContext.Request.Form["draw"].FirstOrDefault();
        //        // Skiping number of Rows count  
        //        var start = httpContext.Request.Form["start"].FirstOrDefault();
        //        // Paging Length 10,20  
        //        var length = httpContext.Request.Form["length"].FirstOrDefault();
        //        // Sort Column Name  
        //        var sortColumn = httpContext.Request.Form["columns[" + httpContext.Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
        //        // Sort Column Direction ( asc ,desc)  
        //        var sortColumnDirection = httpContext.Request.Form["order[0][dir]"].FirstOrDefault();
        //        // Search Value from (Search box)  
        //        var searchValue = httpContext.Request.Form["search[value]"].FirstOrDefault();

        //        //Paging Size (10,20,50,100)  
        //        int pageSize = length != null ? Convert.ToInt32(length) : 0;
        //        int skip = start != null ? Convert.ToInt32(start) : 0;
        //        int recordsTotal = 0;


        //        //Sorting  
        //        if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
        //        {
        //            dataset = dataset.OrderBy(sortColumn + " " + sortColumnDirection);
        //        }
        //        //Search  
        //        if (!string.IsNullOrEmpty(searchValue))
        //        {

        //            dataset = dataset.Search(stringProperties).Containing(searchValue);
        //        }

        //        //total number of rows count   
        //        recordsTotal = dataset.Count();
        //        //Paging   
        //        var data = dataset.Skip(skip).Take(pageSize).ToList();
        //        responseData.draw = draw;
        //        responseData.recordsFiltered = recordsTotal;
        //        responseData.recordsTotal = recordsTotal;
        //        responseData.data = data;
        //        //Returning Json Data  
        //        return responseData;

        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}
    }
}
