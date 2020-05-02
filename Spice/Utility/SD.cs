using Spice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spice.Utility
{
    public class SD
    {
        //for image
        public const string DefaultFoodImage = "default_food.png";
        //for register
        public const string ManagerUser = "Manager";
        public const string KitchenUser = "Kitchen";
        public const string FrontDeskUser = "FrontDesk";
        public const string CustomerEndUser = "Customer";
        //for shopping cart, session name
        public const string ssShoppingCartCount = "ssCartCount";
        //for AddCoupon function
        public const string ssCouponCode = "ssCouponCode";
        //summary post
        public const string StatusSubmitted = "Submitted";
        public const string StatusInProcess = "Being Prepared";
        public const string StatusReady = "Ready for Pickup";
        public const string StatusCompleted = "Completed";
        public const string StatusCancelled = "Cancelled";

        public const string PaymentStatusPending = "Pending";
        public const string PaymentStatusApproved = "Approved";
        public const string PaymentStatusRejected = "Rejected";

        public static string ConvertToRawHtml(string source)
        {
            char[] array = new char[source.Length];
            int arrayIndex = 0;
            bool inside = false;

            for (int i = 0; i < source.Length; i++)
            {
                char let = source[i];
                if (let == '<')
                {
                    inside = true;
                    continue;
                }
                if (let == '>')
                {
                    inside = false;
                    continue;
                }
                if (!inside)
                {
                    array[arrayIndex] = let;
                    arrayIndex++;
                }
            }
            return new string(array, 0, arrayIndex);
        }

        //compute the discounted price
        public static double DiscountedPrice(Coupon couponFromDb, double OriginalOrderTotal)
        {
            if (couponFromDb == null)
            {
                return OriginalOrderTotal;
            }
            else
            {
                //invalid coupon
                if (couponFromDb.MinimumAmount > OriginalOrderTotal)
                {
                    return OriginalOrderTotal;
                }
                else
                {
                    //everything is valid
                    if (Convert.ToInt32(couponFromDb.CouponType) == (int)Coupon.ECouponType.Dollar)
                    {
                        //$10 off $100
                        return Math.Round(OriginalOrderTotal - couponFromDb.Discount, 2);
                    }

                    if (Convert.ToInt32(couponFromDb.CouponType) == (int)Coupon.ECouponType.Percent)
                    {
                        //10% off $100
                        return Math.Round(OriginalOrderTotal - (OriginalOrderTotal - couponFromDb.Discount / 100), 2);
                    }
                }
            }
            return OriginalOrderTotal;
        }
    }
}
