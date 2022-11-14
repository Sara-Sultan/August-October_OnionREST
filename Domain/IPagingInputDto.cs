using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public interface IPagingInputDto
    {
        int PageNumber { get; set; }
        int PageSize { get; set; }
    }
}
