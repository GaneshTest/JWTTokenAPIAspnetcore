using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RepositoryPattern.Data
{
    public class NotificationLog
    {
        [Required,Key]
        public string ID { get; set; }
        [Required]
        [ForeignKey("SenderUser")]
        public string SenderUserId { get; set; }
        public string NotificationTitle { get; set; }

        [Required]
        public string NotificationText { get; set; }
        public string NotificationUrl { get; set; }

        public virtual IdentityUser SenderUser { get; set; }
    }
}
