using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Notifications.Models;
using MediatR;

namespace Application.Teachers.Commands.CreateTeacher
{
    public class TeacherCreated : INotification
    {
        public int TeacherId { get; set; }
        
        public class TeacherCreatedHandler : INotificationHandler<TeacherCreated>
        {
            private readonly INotificationService _notification;

            public TeacherCreatedHandler(INotificationService notification)
            {
                _notification = notification;
            }

            public async Task Handle(TeacherCreated notification, CancellationToken cancellationToken)
            {
                await _notification.SendAsync(new MessageDto());
            }
        }
    }
}