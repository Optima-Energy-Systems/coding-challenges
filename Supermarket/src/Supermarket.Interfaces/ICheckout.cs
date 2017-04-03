namespace Supermarket.Interfaces
{
    public interface ICheckout
    {
        void Scan(IItem item);
        int GetTotalPrice();
    }
}