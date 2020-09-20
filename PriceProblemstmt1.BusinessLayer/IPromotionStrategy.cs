namespace PriceProblemstmt1.BusinessLayer
{
    public interface IPromotionStrategy
    {
        string Name { get; }
        double GetPromotionDiscount();
    }
}