using ShopApp.Entities.Concrete.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp.Entities.Concrete
{
    public class Order
    {
        public Order()
        {
            OrderItems = new List<OrderItem>();
        }
        //stripe
        // iyzico
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public string UserId { get; set; }
        public EnumOrderState OrderState { get; set; }
        public EnumPaymentTypes PaymentTypes { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string OrderNote { get; set; }

        public string PaymentId { get; set; }
        public string PaymentToken { get; set; }
        public string ConversationId { get; set; }

        public List<OrderItem> OrderItems { get; set; }
    }
}
