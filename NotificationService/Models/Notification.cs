using System;
using System.Collections.Generic;

namespace NotificationService.Models;

public partial class Notification
{
    public int Id { get; set; }

    public string Type { get; set; } = null!;

    public string Recipient { get; set; } = null!;

    public string Message { get; set; } = null!;

    public DateTime SentAt { get; set; }
}
