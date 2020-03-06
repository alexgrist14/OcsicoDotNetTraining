using System;
using System.Collections.Generic;
using System.Text;

namespace Kawaii.Domain.Contracts
{
    public interface IEntityModel<T>
    {
        T Id { get; set; }
    }
}
