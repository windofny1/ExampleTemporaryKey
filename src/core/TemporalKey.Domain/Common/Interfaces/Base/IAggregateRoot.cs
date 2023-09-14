using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemporalKey.Domain.Common.Interfaces.Base
{
    public interface IAggregateRoot<TId>:IEntity<TId>
        where TId : notnull
    { 
    }
}
