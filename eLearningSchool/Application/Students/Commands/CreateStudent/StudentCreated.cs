using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Notifications.Models;
using MediatR;

namespace Application.Students.Commands.CreateStudent
{
    public class StudentCreated : INotification
    {
        public int StudentId { get; set; }
        
        public class StudentCreatedHandler : INotificationHandler<StudentCreated>
        {
            private readonly INotificationService _notification;

            public StudentCreatedHandler(INotificationService notification)
            {
                _notification = notification;
            }

            public async Task Handle(StudentCreated notification, CancellationToken cancellationToken)
            {
                await _notification.SendAsync(new MessageDto());
            }
        }
    }
}