using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Exceptions
{
    public sealed class NotFoundException : Exception
    {
        public NotFoundException(string EntityName, Guid id)
            : base($"The { EntityName } with the identifier {id} was not found.")
        {
        }
    }
}
