using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalabatG02.Core;
using TalabatG02.Core.Entities;
using TalabatG02.Core.Entities.Order_Aggregation;
using TalabatG02.Core.Repositories;
using TalabatG02.Core.Services;
using TalabatG02.Core.Specifications.Order_Specification;

namespace TalabatG02.Service
{
    public class OrderService : IOrderService
    {
        private readonly IBasketRepository basketRepository;
        private readonly IUnitOfWork unitOfWork;

        public OrderService(IBasketRepository basketRepository,IUnitOfWork unitOfWork)
        {
            this.basketRepository = basketRepository;
            this.unitOfWork = unitOfWork;
        }
        public async Task<Order?> CreateOrderAsync(string bayerEmail, string basketId, Address shippingAddress, int DeliveryMethodId)
        {
            //1.Get Basket From Basket Repo

            var basket = await basketRepository.GetBasketAsync(basketId);

            //2.Get Selected Item at Basket From ProductRepo
            var orderItems = new List<OrderItem>();

            if(basket?.Items?.Count > 0)
            {
                foreach(var item in basket.Items)
                {
                    var product = await unitOfWork.Repository<Product>().GetByIdAsync(item.Id);
                    var productItemOrdered = new ProductOrderItem(product.Id, product.Name, product.PictureUrl);
                    var orderItem = new OrderItem(productItemOrdered, product.Price, item.Quantity);

                    orderItems.Add(orderItem);  
                }
            }

            //3. Calculate SubTotal
            var subTotal = orderItems.Sum(item => item.Price * item.Quantity);

            //4.Get Delivert Method From DM Repository
            var deliveryMethod = await unitOfWork.Repository<DeliveryMethod>().GetByIdAsync(DeliveryMethodId);

            //5.Create Order
            var spec = new OrderWithPaymentSpecifications(basket.PaymentIntentId);
            var exsistOrder = await unitOfWork.Repository<Order>().GetByIdWithSpecAsync(spec);

            if(exsistOrder is not null)
            {
                unitOfWork.Repository<Order>().Delete(exsistOrder);
            }

            var Order = new Order(bayerEmail, shippingAddress,basket.PaymentIntentId ,deliveryMethod, orderItems, subTotal);

            //6.Add Order Locally
            await unitOfWork.Repository<Order>().Add(Order);//Local

            //7.Save Order To DataBase (Orders)
            var result  = await unitOfWork.Complete();
            if (result <= 0) return null; 
            return Order;
        }


        public async Task<IReadOnlyList<Order>> GetOrdersForUserAsync(string buyerEmail)
        {
            var spec = new OrderSpecifications(buyerEmail);
            var Orders = await unitOfWork.Repository<Order>().GetAllWithSpecAsync(spec);

            return Orders;
        }


        public async Task<Order> GetOrderByIdForUserAsync(int orderId, string buyerEmail)
        {
            var spec = new OrderSpecifications(orderId, buyerEmail);
            var order = await unitOfWork.Repository<Order>().GetByIdWithSpecAsync(spec);

            return order;
        }

        public async Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodsAsync()
        {
            var deliveryMethods = await unitOfWork.Repository<DeliveryMethod>().GetAllAsync();

            return deliveryMethods;
        }
    }
}
