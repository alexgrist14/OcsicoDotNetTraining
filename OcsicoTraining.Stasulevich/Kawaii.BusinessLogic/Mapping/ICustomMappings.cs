using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace Kawaii.BusinessLogic.Mapping
{
    public interface ICustomMappings
    {
        void CreateMappings(IMapperConfigurationExpression configuration);
    }
}
