namespace Auth.Infrastruture.CrossCutting.Handle;

public interface INotificationHandle
{
    bool IsNotification();
    List<Notification> GetNotification();
    void Handle(Notification notification);
}
