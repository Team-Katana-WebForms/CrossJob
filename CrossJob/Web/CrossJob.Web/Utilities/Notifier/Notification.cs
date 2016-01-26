namespace CrossJob.Utilities.Notifier
{
    using Enums;

    public class Notification
    {
        public string Text { get; set; }

        public NotificationType Type { get; set; }

        public bool AutoHide { get; set; }
    }
}