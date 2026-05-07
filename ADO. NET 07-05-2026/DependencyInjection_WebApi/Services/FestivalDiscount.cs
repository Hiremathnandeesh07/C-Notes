namespace DependencyInjection_WebApi.Services
{
    public class FestivalDiscount 
    {
        public int DiscountAmount(int amount)
        {
            return (int)(amount * 0.5);
        }

    }
}
