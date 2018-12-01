using MyWebCoreApp.Infrastructure.SharedKernel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebCoreApp.Data.Entities
{
    [Table("OrderDetails")]
    public class OrderDetail : DomainEntity<int>
    {
        public OrderDetail()
        {
        }

        public OrderDetail(int id, int orderId, int productId, int quantity, decimal price, int colorId, int sizeId)
        {
            Id = id;
            OrderId = orderId;
            ProductId = productId;
            Quantity = quantity;
            Price = price;
            ColorId = colorId;
            SizeId = sizeId;
        }

        public OrderDetail(int orderId, int productId, int quantity, decimal price, int colorId, int sizeId)
        {
            OrderId = orderId;
            ProductId = productId;
            Quantity = quantity;
            Price = price;
            ColorId = colorId;
            SizeId = sizeId;
        }

        public int OrderId { set; get; }

        public int ProductId { set; get; }

        public int Quantity { set; get; }

        public decimal Price { set; get; }

        public int ColorId { get; set; }

        public int SizeId { get; set; }

        [ForeignKey("OrderId")]
        public virtual Order Order { set; get; }

        [ForeignKey("ProductId")]
        public virtual Product Product { set; get; }
    }
}