using JoyPromotion.Shared.Utils.Results.ComplexTypes;
using System;

namespace JoyPromotion.Shared.Utils.Results.Abstract
{
    public interface IResult
    {
        ResultStatus ResultStatus { get; }
        string Message { get; }
        Exception Exception { get; }
    }
}
