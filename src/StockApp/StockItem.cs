namespace StockApp;

/// <summary>Represents an item and its available quantity.</summary>
public sealed class StockItem
{
    public string Name { get; }

    public int Quantity { get; private set; }

    public StockItem(string name, int quantity = 0)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);

        if (quantity < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity cannot be negative.");
        }

        Name = name;
        Quantity = quantity;
    }

    internal void ChangeQuantity(int quantity) => Quantity = quantity;
}
