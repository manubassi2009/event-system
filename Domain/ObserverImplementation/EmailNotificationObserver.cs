using Domain.ClaimModel;
using Domain.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ObserverImplementation;

public class EmailNotificationObserver : IClaimObserver
{
    public void OnStatusChanged(Claim claim, string oldStatus, string newStatus)
    {
        Console.WriteLine($"[EMAIL] Claim '{claim.Id}' status changed from '{oldStatus}' to '{newStatus}'.");
    }

    public void OnFileAdded(Claim claim, string fileName)
    {
        Console.WriteLine($"[EMAIL] File '{fileName}' added to Claim '{claim.Id}'.");
    }
}

