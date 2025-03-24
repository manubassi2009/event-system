using Domain.ClaimModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Observer;

public interface IClaimObserver
{
    void OnStatusChanged(Claim claim, string oldStatus, string newStatus);
    void OnFileAdded(Claim claim, string fileName);
}
