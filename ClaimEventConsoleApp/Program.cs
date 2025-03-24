using Domain.ObserverImplementation;
using Domain.Service;

class Program
{
    static void Main(string[] args)
    {
        var claimService = new ClaimService();

        // Register Observers
        var emailObserver = new EmailNotificationObserver();
        var auditObserver = new AuditLogObserver();
        var smsObserver = new SmsNotificationObserver();

        claimService.RegisterObserver(emailObserver);
        claimService.RegisterObserver(auditObserver);
        claimService.RegisterObserver(smsObserver);

        // Create a claim
        var claim = claimService.CreateClaim("Water Damage", "Water leak in the bathroom.");

        // Change status
        claimService.ChangeClaimStatus(claim.Id, "In Progress");
        claimService.ChangeClaimStatus(claim.Id, "Urgent");

        // Add file
        claimService.AddFileToClaim(claim.Id, "leakage_photo.jpg");

        // Unregister SMS observer
        claimService.RemoveObserver(smsObserver);

        // Status change after removing SMS observer
        claimService.ChangeClaimStatus(claim.Id, "Resolved");
    }
}
