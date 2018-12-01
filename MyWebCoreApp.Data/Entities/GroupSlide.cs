using MyWebCoreApp.Data.Enums;
using MyWebCoreApp.Data.Interfaces;
using MyWebCoreApp.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyWebCoreApp.Data.Entities
{
    [Table("GroupSlides")]
    public class GroupSlide : DomainEntity<int>, ISwitchable
    {
        public GroupSlide()
        {

        }

        public GroupSlide(string name, Status status)
        {
            Name = name;
            Status = status;
        }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        public Status Status { get; set; } 
        
        public virtual ICollection<Slide> Slides { get; set; }
    }
}
