using System;
using System.Collections.Generic;
using System.Text;

namespace Karimaneh.Application.Features.Requests.Specifications
{
    public class RequestGetAllSpec : RequestBaseSpec
    {
        public RequestGetAllSpec(int? limit = null, int? offset = null)
        {
            if (limit is not null && offset is not null)
            {
                ApplyPaging(offset.Value, limit.Value);
            }
        }
    }
}
