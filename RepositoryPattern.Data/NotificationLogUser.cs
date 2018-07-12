using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RepositoryPattern.Data
{
    public class NotificationLogUser
    {
        [Required, Key]
        public string ID { get; set; }
        [ForeignKey("NotificationLog")]
        public string NotificationLogId { get; set; }

        [ForeignKey("ReceiverUser")]
        public string ReceiverUserId { get; set; }
        public bool IsRead { get; set; }

        public virtual NotificationLog NotificationLog { get; set; }
        public virtual IdentityUser ReceiverUser { get; set; }
    }
}
