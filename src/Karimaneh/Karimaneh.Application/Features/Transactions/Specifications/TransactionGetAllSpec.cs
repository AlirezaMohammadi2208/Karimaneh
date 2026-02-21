using System;
using System.Collections.Generic;
using System.Text;

namespace Karimaneh.Application.Features.Transactions.Specifications
{
    public class TransactionGetAllSpec : TransactionBaseSpec
    {
        public TransactionGetAllSpec(int? limit = null, int? offset = null)
        {
            if (limit is not null && offset is not null)
            {
                ApplyPaging(offset.Value, limit.Value);
            }
        }
    }
}
