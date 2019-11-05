using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class StandardAndLoyaltyOffers
    {
        private string[] offerTypes = new[] {"No Offer", "Buy 1 Get 1 Free"};
        private string[] loyaltyTypes = new[] { "No Offer", "50% Off"}; 

        public string getOfferName(int offerInt)
        {
            string standardOffer;
            if (offerInt > offerTypes.Length || offerInt < 0)
            {
                //If reward type cannot be found, return "No Offer"
                standardOffer = offerTypes[0];
            }
            else
            {
                //Get plaintext name for standard offer type
                standardOffer = offerTypes[offerInt];
            }
            return standardOffer;
        }

        public string getLoyaltyName(int loyaltyInt)
        {
            string loyaltyOffer;
            if (loyaltyInt > loyaltyTypes.Length || loyaltyInt < 0)
            {
                //If reward type cannot be found, return "No Offer"
                loyaltyOffer = loyaltyTypes[0];
            }
            else
            {
                //Get plaintext name for loyalty offer type
                loyaltyOffer = loyaltyTypes[loyaltyInt];
            }
            return loyaltyOffer;
        }

        public string[] getAllOfferNames()
        {
            //Return the list of all standard offer type names
            string[] allOfferNames = offerTypes;
            return allOfferNames;
        }

        public string[] getAllLoyaltyNames()
        {
            //Return the list of all loyalty offer type names
            string[] allLoyaltyNames = loyaltyTypes;
            return allLoyaltyNames;
        }
    }
}
