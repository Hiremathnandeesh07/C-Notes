namespace DependencyInjection_WebApi.Services
{
    public class WeekEndDiscount 
    {
        public int DiscountAmount(int amount)
        {
            return (int)(amount * 0.1);
        }
    }
}
