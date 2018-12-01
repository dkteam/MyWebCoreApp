using MyWebCoreApp.Data.Enums;
using MyWebCoreApp.Data.Interfaces;
using MyWebCoreApp.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebCoreApp.Data.Entities
{
    [Table("Orders")]
    public class Order : DomainEntity<int>, ISwitchable, IDateTracking
    {
        public Order()
        {
        }

        public Order(string customerName, string customerAddress, string customerMobile, string customerMessage,
            OrderStatus billStatus, PaymentMethod paymentMethod, Status status, Guid customerId)
        {
            CustomerName = customerName;
            CustomerAddress = customerAddress;
            CustomerMobile = customerMobile;
            CustomerMessage = customerMessage;
            BillStatus = billStatus;
            PaymentMethod = paymentMethod;
            Status = status;
            CustomerId = customerId;
        }

        public Order(int id, string customerName, string customerAddress, string customerMobile, string customerMessage,
           OrderStatus billStatus, PaymentMethod paymentMethod, Status status, Guid customerId)
        {
            Id = id;
            CustomerName = customerName;
            CustomerAddress = customerAddress;
            CustomerMobile = customerMobile;
            CustomerMessage = customerMessage;
            BillStatus = billStatus;
            PaymentMethod = paymentMethod;
            Status = status;
            CustomerId = customerId;
        }

        [Required]
        [MaxLength(256)]
        public string CustomerName { set; get; }

        [Required]
        [MaxLength(256)]
        public string CustomerAddress { set; get; }

        [Required]
        [MaxLength(50)]
        public string CustomerMobile { set; get; }

        [Required]
        [MaxLength(256)]
        public string CustomerMessage { set; get; }

        public PaymentMethod PaymentMethod { set; get; }

        public OrderStatus BillStatus { set; get; }

        public DateTime CreatedDate { set; get; }
        public DateTime ModifiedDate { set; get; }

        [DefaultValue(Status.Active)]
        public Status Status { set; get; } = Status.Active;

        public Guid CustomerId { set; get; }

        [ForeignKey("CustomerId")]
        public virtual AppUser User { set; get; }

        public virtual ICollection<OrderDetail> OrderDetails { set; get; }
    }
}