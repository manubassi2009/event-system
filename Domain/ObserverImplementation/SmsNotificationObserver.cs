using Domain.ClaimModel;
using Domain.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ObserverImplementation;

public class SmsNotificationObserver : IClaimObserver
{
    public void OnStatusChanged(Claim claim, string oldStatus, string newStatus)
    {
        if (newStatus == "Urgent")
        {
            Console.WriteLine($"[SMS] URGENT: Claim '{claim.Id}' requires immediate attention.");
        }
    }

    public void OnFileAdded(Claim claim, string fileName)
    {
        // No SMS for file additions
    }
}

