namespace StockApp.Tests;

[TestClass]
public sealed class StockServiceTests
{
    private readonly StockService _service = new();

    [TestMethod]
    public void AddStock_IncreasesQuantity()
    {
        var item = new StockItem("Clavier", 5);

        _service.AddStock(item, 3);

        Assert.AreEqual(8, item.Quantity);
    }

    [TestMethod]
    public void RemoveStock_WhenQuantityIsAvailable_DecreasesQuantity()
    {
        var item = new StockItem("Clavier", 5);

        _service.RemoveStock(item, 2);

        Assert.AreEqual(3, item.Quantity);
    }

    [TestMethod]
    [DataRow(0)]
    [DataRow(-1)]
    public void AddStock_WhenQuantityIsNotPositive_ThrowsArgumentOutOfRangeException(int quantity)
    {
        var item = new StockItem("Clavier", 5);

        Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => _service.AddStock(item, quantity));
        Assert.AreEqual(5, item.Quantity);
    }

    [TestMethod]
    [DataRow(0)]
    [DataRow(-1)]
    public void RemoveStock_WhenQuantityIsNotPositive_ThrowsArgumentOutOfRangeException(int quantity)
    {
        var item = new StockItem("Clavier", 5);

        Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => _service.RemoveStock(item, quantity));
        Assert.AreEqual(5, item.Quantity);
    }

    [TestMethod]
    public void RemoveStock_WhenQuantityExceedsAvailable_ThrowsAndLeavesQuantityUnchanged()
    {
        var item = new StockItem("Clavier", 5);

        Assert.ThrowsExactly<InvalidOperationException>(() => _service.RemoveStock(item, 6));

        Assert.AreEqual(5, item.Quantity);
    }

    [TestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void StockItem_WhenNameIsEmpty_ThrowsArgumentException(string name)
    {
        Assert.ThrowsExactly<ArgumentException>(() => new StockItem(name));
    }

    [TestMethod]
    public void StockItem_WhenInitialQuantityIsNegative_ThrowsArgumentOutOfRangeException()
    {
        Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => new StockItem("Clavier", -1));
    }
}
