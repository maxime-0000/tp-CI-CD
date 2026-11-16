namespace StockApp;

/// <summary>Applies stock receipts and issues to stock items.</summary>
public sealed class StockService
{
    public void AddStock(StockItem item, int quantity)
    {
        ArgumentNullException.ThrowIfNull(item);
        ValidatePositiveQuantity(quantity);

        item.ChangeQuantity(checked(item.Quantity + quantity));
    }

    public void RemoveStock(StockItem item, int quantity)
    {
        ArgumentNullException.ThrowIfNull(item);
        ValidatePositiveQuantity(quantity);

        if (quantity > item.Quantity)
        {
            throw new InvalidOperationException(
                $"Cannot remove {quantity} units from '{item.Name}': only {item.Quantity} available.");
        }

        item.ChangeQuantity(item.Quantity - quantity);
    }

    private static void ValidatePositiveQuantity(int quantity)
    {
        if (quantity <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity must be greater than zero.");
        }
    }
}
