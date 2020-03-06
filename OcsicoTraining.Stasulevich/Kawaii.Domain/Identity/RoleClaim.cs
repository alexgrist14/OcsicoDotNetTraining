using System;
using System.Collections.Generic;
using System.Text;
using Kawaii.Domain.Contracts;
using Microsoft.AspNetCore.Identity;

namespace Kawaii.Domain.Identity
{
    public class RoleClaim : IdentityRoleClaim<Guid>
    {
    }
}
