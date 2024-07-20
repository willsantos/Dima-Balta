﻿using System.Text.Json.Serialization;

namespace WS.Dima.Core.Responses
{
    public class PagedResponse<TData> : Response<TData>
    {
        [JsonConstructor]
        public PagedResponse(
           TData? data,
           int totalCount,
           int currentPage = ~Configuration.DefaultPageNumber,
           int pageSize = Configuration.DefaultPageSize
        ) : base(data)
        {
            Data = data;
            TotalCount = totalCount;
            CurrentPage = currentPage;
            PageSize = pageSize;
        }

        public PagedResponse(
            TData? data,
            int code = Configuration.DefaultStatusCode,
            string? message = null
            ) : base(data, code, message)
        {
        }

        public int CurrentPage { get; set; } = Configuration.DefaultPageNumber;
        public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
        public int PageSize { get; set; } = Configuration.DefaultPageSize;
        public int TotalCount { get; set; }
    }
}
