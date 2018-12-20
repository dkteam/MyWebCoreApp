using Microsoft.AspNetCore.Identity;
using MyWebCoreApp.Data.Enums;
using MyWebCoreApp.Data.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebCoreApp.Data.Entities
{
    [Table("AppUsers")]
    public class AppUser : IdentityUser<Guid>, IDateTracking, ISwitchable
    {
        public AppUser()
        {
        }

        public AppUser(Guid id, string fullName, string userName,
            string email, string phoneNumber, string avatar, Status status)
        {
            Id = id;
            FullName = fullName;
            UserName = userName;
            Email = email;
            PhoneNumber = phoneNumber;
            Avatar = avatar;
            Status = status;
        }

        [StringLength(255)]
        [Required]
        public string FullName { get; set; }

        public DateTime? BirthDay { get; set; }

        public decimal Balance { get; set; }

        [StringLength(255)]
        public string Avatar { get; set; }

        public Status Status { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}