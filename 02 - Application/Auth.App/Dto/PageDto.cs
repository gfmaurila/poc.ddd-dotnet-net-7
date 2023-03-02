﻿namespace Auth.App.Dto;

public class PageDto
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }
    public int TotalPages { get; set; }
    public object Filter { get; set; }
    public dynamic Results { get; set; }
}

