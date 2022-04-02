using JoyPromotion.Shared.Utils.Results.ComplexTypes;

namespace JoyPromotion.Shared.Entities
{
    public abstract class DtoGetBase
    {
        public virtual ResultStatus ResultStatus { get; set; }
        public virtual string Message { get; set; }
    }
}
