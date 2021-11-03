//===================================================
// Date         : 03 Nov 2021
// Author       : I Gusti Kade Sugiantara
// Description  : Extentions method
//===================================================
// Revision History:
// Name             Date            Description
//
//===================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using API.Helpers.Params;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace API.Helpers.Pagination
{
    public static class Extentions
    {
        public static void AddApplicationError(this HttpResponse response, string message)
        {
            response.Headers.Add("Application-Error", message);
            response.Headers.Add("Access-Control-Expose-Headers", "Application-Error");
            response.Headers.Add("Access-Control-Allow-Origin", "*");
        }

        public static void AddPagination(this HttpResponse response, int currentPage, int pageSize, int totalItems, int totalPages)
        {
            var paginationHeader = new PageHeader(currentPage, pageSize, totalItems, totalPages);
            var camelCaseFormatter = new JsonSerializerSettings();
            camelCaseFormatter.ContractResolver = new CamelCasePropertyNamesContractResolver();
            response.Headers.Add("Pagination",
                JsonConvert.SerializeObject(paginationHeader, camelCaseFormatter));
            response.Headers.Add("Access-Control-Expose-Headers", "Pagination");
        }

        public static IQueryable<T> ApplyOrdering<T>(this IQueryable<T> query, BaseParam baseParam, Dictionary<string, Expression<Func<T, object>>> columnsMap)
        {
            if (String.IsNullOrWhiteSpace(baseParam.OrderBy) || !columnsMap.ContainsKey(baseParam.OrderBy))
            {
                return query;
            }

            if (baseParam.IsDescending)
            {
                return query.OrderByDescending(columnsMap[baseParam.OrderBy]);
            }
            else
            {
                return query.OrderBy(columnsMap[baseParam.OrderBy]);
            }
        }
    }
}