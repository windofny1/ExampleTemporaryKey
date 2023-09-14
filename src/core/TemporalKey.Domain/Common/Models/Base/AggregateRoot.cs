using TemporalKey.Domain.Common.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemporalKey.Domain.Common.Interfaces.Base;

namespace TemporalKey.Domain.Common.Models.Base
{
    public abstract class AggregateRoot<TId> : Entity<TId>
         where TId : notnull
    {
        protected AggregateRoot(TId id) : base(id) { }
    }
}
