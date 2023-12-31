﻿using LibraryApp.Api.Db.Entities;
using LibraryApp.Shared.Dtos;

namespace LibraryApp.Api.Extensions;

public static class TagExtensions
{
    public static TagOfBookDto ToTagOfBookDto(this Tag tag) => new(tag.TagId, tag.Title);
}