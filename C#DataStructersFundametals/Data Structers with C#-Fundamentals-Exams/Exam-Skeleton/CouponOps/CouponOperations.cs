namespace CouponOps
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CouponOps.Models;
    using Interfaces;

    public class CouponOperations : ICouponOperations
    {
        private Dictionary<string,Website>websiteByName = new Dictionary<string,Website>();
        private Dictionary<string,Coupon>couponByCode=new Dictionary<string,Coupon>();
        public void AddCoupon(Website website, Coupon coupon)
        {

            if (!this.websiteByName.ContainsKey(website.Domain))
            {
                throw new ArgumentException();

            }
           
               websiteByName[website.Domain].Coupons.Add(coupon);
               couponByCode.Add(coupon.Code, coupon);
               coupon.Website = website;
              
            

            
            
        }

        public bool Exist(Website website)
        {
            if(this.websiteByName.ContainsKey(website.Domain))
            {
                return true;
            }
            return false;
        }

        public bool Exist(Coupon coupon)
        {
            if (this.couponByCode.ContainsKey(coupon.Code))
            {
                return true;
            }
            return false; 
        }

        public IEnumerable<Coupon> GetCouponsForWebsite(Website website)
        {
            if(!this.websiteByName.ContainsKey((website.Domain)))
            {
                throw new ArgumentException();

            }
            return this.websiteByName[website.Domain].Coupons;    
        }
        


        public IEnumerable<Coupon>
            GetCouponsOrderedByValidityDescAndDiscountPercentageDesc()
            => this.couponByCode.Values.OrderByDescending(c => c.Validity)
            .ThenByDescending(c => c.DiscountPercentage);
       

        public IEnumerable<Website> GetSites() => this.websiteByName.Values;


        public IEnumerable<Website> GetWebsitesOrderedByUserCountAndCouponsCountDesc()
            => this.websiteByName.Values.OrderBy(u => u.UsersCount)
            .ThenByDescending(u => u.Coupons.Count);
       
        public void RegisterSite(Website website)
        {
            if (this.websiteByName.ContainsKey(website.Domain))
            {
                throw new ArgumentException();

            }
            this.websiteByName.Add(website.Domain, website);
        }

        public Coupon RemoveCoupon(string code)
        {
            if (!this.couponByCode.ContainsKey(code))
            {
                throw new ArgumentException();

            }
            Coupon coupon = this.couponByCode[code];
            this.couponByCode.Remove(code);
            Website site = this.websiteByName[coupon.Website.Domain];
            site.Coupons.Remove(coupon);
            return coupon;
            
        }

        public Website RemoveWebsite(string domain)
        {
           if(!this.websiteByName.ContainsKey(domain))
           {
                throw new ArgumentException();
           }
           Website website = this.websiteByName[domain];
           this.websiteByName.Remove(domain);
           website.Coupons.Clear();
           return website;
          
        }

        public void UseCoupon(Website website, Coupon coupon)
        {
            if (!this.websiteByName.ContainsKey(website.Domain))
            {
                throw new ArgumentException();
            }
            if (!this.websiteByName[website.Domain].Coupons.Contains(coupon))
            {
                throw new ArgumentException();
            }
            this.websiteByName[website.Domain].Coupons.Remove(coupon);
            this.couponByCode.Remove(coupon.Code);

        }
        
    }
}
