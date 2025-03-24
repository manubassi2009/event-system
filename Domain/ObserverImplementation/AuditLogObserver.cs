using Domain.ClaimModel;
using Domain.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ObserverImplementation;

public class AuditLogObserver : IClaimObserver
{
    public void OnStatusChanged(Claim claim, string oldStatus, string newStatus)
    {
        Console.WriteLine($"[AUDIT] Claim '{claim.Id}' status changed: '{oldStatus}' → '{newStatus}'.");
    }

    public void OnFileAdded(Claim claim, string fileName)
    {
        Console.WriteLine($"[AUDIT] File '{fileName}' added to Claim '{claim.Id}'.");
    }
}

