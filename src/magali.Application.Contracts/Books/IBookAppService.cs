﻿using magali.Authors;
using magali.Books.CustomFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace magali.Books
{
    public interface IBookAppService : ICrudAppService<
            BookDto,
            Guid,
            BookFilters,
            CreateUpdateBookDto
        >
    {
    }
}
