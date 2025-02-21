using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
public class Pagination<T>
{
    public List<T> Items { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalRecords { get; set; }

    public Pagination(List<T> items, int pageNumber, int pageSize, int totalRecords)
    {
        Items = items;
        PageNumber = pageNumber;
        PageSize = pageSize;
        TotalRecords = totalRecords;
    }
}

public static class PaginationExtensions
{
    public async static Task<Pagination<T>> ToPagedAsync<T>(this IQueryable<T> query, int pageNumber, int pageSize)
    {
        var totalRecords = await query.CountAsync();
        var items = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

        return new Pagination<T>(items, pageNumber, pageSize, totalRecords);
    }
}