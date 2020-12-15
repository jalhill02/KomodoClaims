using System;
using System.Collections.Generic;
using System.Text;

namespace KomodoClaimsLib
{
    class KomodoClaimsRepository
    {
        private Queue<Claims> _queueOfClaims = new Queue<Claims>();

        // Create
        public void AddToQueue(Claims claims)
        {
            _queueOfClaims.Enqueue(claims);

        }

        // Read
        public Queue<Claims> GetClaims()
        {
            return _queueOfClaims;
        }

        // Update
        public bool UpdateClaimsInQueue(int oldClaimid, Claims newClaims)
        {
            Claims oldClaim = GetClaimBId(oldClaimid);
            
            if (oldClaim!=null)
            {
                //now we need to update...
                newClaims.ClaimId = oldClaim.ClaimId;
                oldClaim.Description = newClaims.Description;
                oldClaim.DateOfIncident = newClaims.DateOfIncident;
                oldClaim.DateOfClaim = newClaims.DateOfClaim;
                oldClaim.IsValid = newClaims.IsValid;
                oldClaim.ClaimAmount = newClaims.ClaimAmount;
                oldClaim.ClaimType = newClaims.ClaimType;

                return true;
            }
            return false;
        }


        // Delete
        public bool RemoveClaimFromQueue()
        {
            if (_queueOfClaims.Count > 0)
            {
                _queueOfClaims.Dequeue();
                return true;
            }
            return false;
        }

        // Helper Method
        public Claims GetClaimBId(int claimId)
        {
            foreach (var claim  in _queueOfClaims)
            {
                if (claim.ClaimId == claimId)
                {
                    return claim;
                }
            }
            return null;
        }

        public Claims SeeNextInQueue()
        {
            Claims claims = _queueOfClaims.Peek();
            return claims;
        }

        public bool IsValidCalculaiton(DateTime DateOfIncident, DateTime DateOfClaim)
        {
            var answer = DateOfClaim - DateOfIncident;
            Console.WriteLine($"answer ={answer}");
            if (answer.Days <= 30 && answer.Days > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
}
