﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ProductManagement.Books
{
    public interface IBookAppService :
       ICrudAppService< //Defines CRUD methods
           BookDto, //Used to show books
           Guid, //Primary key of the book entity
           PagedAndSortedResultRequestDto, //Used for paging/sorting
           CreateUpdateBookDto> //Used to create/update a book
    {
        Task<ListResultDto<AuthorLookupDto>> GetAuthorLookupAsync();
    }
}
