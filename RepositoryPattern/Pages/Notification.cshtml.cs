using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using RepositoryPattern.Hubs;
using RepositoryPattern.Repository.Interface;

namespace RepositoryPattern.Pages
{
    public class NotificationModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private IHubContext<NotificationHub> context
        {
            get;
            set;
        }

        public NotificationModel(IHubContext<NotificationHub> hub, IUnitOfWork unitOfWork)
        {
            this.context = hub;
            this._unitOfWork = unitOfWork;
        }

        [BindProperty]
        public Notification Notification { get; set; }

        [Authorize(Policy = "RequireAdministratorRolead")]
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            var result = _unitOfWork.NotificationLogUserRepository.Get(x => x.ReceiverUserId == "1").FirstOrDefault();
            //.Where(r => !r.IsRead)
            //.ToList().Take(6)
            //.Select(s => new
            //{
            //    s.ID,
            //    s.NotificationLog.NotificationTitle,
            //    s.NotificationLog.NotificationText,
            //    s.NotificationLog.NotificationUrl,
            //    s.IsRead,
            //    CreatedDateTime = DateTime.Now
            //}).OrderByDescending(x => x.CreatedDateTime);

            var notification = _unitOfWork.NotificationLogRepository.Get(x => x.ID == result.NotificationLogId).FirstOrDefault();
            List<string> groups = new List<string>() { "Ganesh" };
            await context.Clients.Groups(groups).SendAsync("ReceiveMessage", "Ganesh", notification);
            return null;
        }
    }
}