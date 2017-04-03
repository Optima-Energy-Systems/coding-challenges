namespace Supermarket.Interfaces
{
    public interface IItem
    {
        char SKU { get; set; }
        int UnitPrice { get; set; }
        int? MultiBuyItemsRequired { get; set; }
        int? MultiBuyPrice { get; set; }
    }
}