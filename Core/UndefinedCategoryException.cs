using System.Runtime.Serialization;

namespace Core;

[Serializable]
public class UndefinedCategoryException : Exception
{
    public ITrade Trade { get; }
    public UndefinedCategoryException(ITrade trade)
    {
        this.Trade = trade;
    }

    protected UndefinedCategoryException(SerializationInfo info, StreamingContext context, Trade trade) : base(info, context)
    {
        this.Trade = trade;
    }

    public UndefinedCategoryException(string? message, ITrade trade) : base(message)
    {
        this.Trade = trade;
    }

    public UndefinedCategoryException(string? message, Exception? innerException, ITrade trade) : base(message, innerException)
    {
        this.Trade = trade;
    }
}