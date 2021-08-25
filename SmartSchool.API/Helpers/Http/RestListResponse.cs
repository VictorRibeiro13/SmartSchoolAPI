using Microsoft.EntityFrameworkCore;
using SmartSchool.API.Helpers.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.API.Helpers
{
    public class RestListResponse<T>
    {
        public List<T> Data { get; set; } = new List<T>();
        public Pagination Pagination { get; set; }

        public RestListResponse() { }

        public RestListResponse(List<T> items, int totalCount, int currentPage, int pageSize)
        {
            Pagination = new Pagination() {
                TotalCount = totalCount,
                CurrentPage = currentPage,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize)
            };

            Data.AddRange(items);
        }

        public static async Task<RestListResponse<T>> CreateAsync(
            IQueryable<T> source,
            int pageNumber,
            int pageSize
        )
        {
            int totalCount = await source.CountAsync();
            var items = await source.Skip((pageNumber - 1) * pageSize)
                                    .Take(pageSize)
                                    .ToListAsync();

            return new RestListResponse<T>(items, totalCount, pageNumber, pageSize);
        }
    }
}
