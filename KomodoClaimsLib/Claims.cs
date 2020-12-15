using System;

namespace KomodoClaimsLib
{
    public enum ClaimType
    {
        Car = 1,
        Home,
        Theft
    }


    public class Claims
    {
        public int ClaimId { get; set; }
        public bool IsValid { get; set; }
        public DateTime DateOfClaim { get; set; }
        public DateTime DateOfIncident { get; set; }
        public double ClaimAmount { get; set; }
        public string Description { get; set; }
        public ClaimType ClaimType { get; set; }

        public Claims()
        {

        }

        public Claims(int claimID, bool isValid, DateTime dateOfClaim, DateTime dateOfIncident, double claimAmount, string description)
        {
            ClaimId = claimID;
            IsValid = isValid;
            DateOfClaim = dateOfClaim;
            DateOfIncident = dateOfIncident;
            ClaimAmount = claimAmount;
            Description = description;
        }
    }
}
