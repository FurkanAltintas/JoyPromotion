using AutoMapper;
using JoyPromotion.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoyPromotion.Business.Extensions.ConverterData
{
    public class DataConvert<T> : IDataConvert<T> where T : class, IDto, new()
    {
        private readonly IMapper _mapper;

        public DataConvert(IMapper mapper)
        {
            _mapper = mapper;
        }

        public object Convert(T data)
        {
            return _mapper.Map<object>(data);
        }
    }
}
