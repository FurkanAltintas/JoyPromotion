namespace JoyPromotion.Shared.Utils.Results.Abstract
{
    public interface IDataResult<out T> : IResult
    {
        T Data { get; }
    }
}
