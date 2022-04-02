using JoyPromotion.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoyPromotion.Business.Extensions.ConverterData
{
    public interface IDataConvert<T> where T : class, IDto, new()
    {
        object Convert(T data);
    }
}
