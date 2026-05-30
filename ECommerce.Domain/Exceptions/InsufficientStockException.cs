//ECommerce.Domain/Exceptions/InsufficientStockException.cs

namespace ECommerce.Domain.Exceptions;

public class InsufficientStockException : Exception
{
    public InsufficientStockException(string productName, int requested, int available)
        : base($"Stock insuficiente para '{productName}'. Solicitado: {requested}, Disponible: {available}")
    {
    }
}