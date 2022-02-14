namespace DogSitter.BLL.Services
{
    public interface IOrderService
    {
        void EditOrderStatusByOrderId(int id, int status);
    }
}