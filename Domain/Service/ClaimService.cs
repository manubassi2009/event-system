using Domain.ClaimModel;
using Domain.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service;

public class ClaimService
{
    private readonly List<IClaimObserver> _observers = new();
    private readonly List<Claim> _claims = new();

    public void RegisterObserver(IClaimObserver observer)
    {
        _observers.Add(observer);
    }

    public void RemoveObserver(IClaimObserver observer)
    {
        _observers.Remove(observer);
    }

    private void NotifyStatusChange(Claim claim, string oldStatus, string newStatus)
    {
        foreach (var observer in _observers)
        {
            observer.OnStatusChanged(claim, oldStatus, newStatus);
        }
    }

    private void NotifyFileAdded(Claim claim, string fileName)
    {
        foreach (var observer in _observers)
        {
            observer.OnFileAdded(claim, fileName);
        }
    }

    public Claim CreateClaim(string title, string description)
    {
        var claim = new Claim
        {
            Title = title,
            Description = description,
            Status = "Reported"
        };

        _claims.Add(claim);
        Console.WriteLine($"[INFO] Claim '{claim.Id}' created with status 'Reported'.");
        return claim;
    }

    public void ChangeClaimStatus(string claimId, string newStatus)
    {
        var claim = _claims.FirstOrDefault(c => c.Id == claimId);

        if (claim == null)
        {
            Console.WriteLine($"[ERROR] Claim '{claimId}' not found.");
            return;
        }

        var oldStatus = claim.Status;
        claim.Status = newStatus;

        NotifyStatusChange(claim, oldStatus, newStatus);
    }

    public void AddFileToClaim(string claimId, string fileName)
    {
        var claim = _claims.FirstOrDefault(c => c.Id == claimId);

        if (claim == null)
        {
            Console.WriteLine($"[ERROR] Claim '{claimId}' not found.");
            return;
        }

        claim.AttachedFiles.Add(fileName);

        NotifyFileAdded(claim, fileName);
    }
}

