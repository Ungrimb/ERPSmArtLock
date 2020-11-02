using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSmArtLock.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Pwd { get; set; }
        public string Photo { get; set; }
        public string Address { get; set; }
        public string Passport { get; set; }
        public string PassportImage { get; set; }
        public string DinNie { get; set; }
        public string FrontImage { get; set; }
        public string BackImage { get; set; }
        public string CardPhoto { get; set; }
        public string RandomCode { get; set; }
        public int CodeVerify { get; set; }
        public DateTime Dob { get; set; }
        public int Gender { get; set; }
        public string HouseNo { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Postcode { get; set; }
        public string Nationality { get; set; }
        public string CityOfBirth { get; set; }
        public string CountryOfBirth { get; set; }
        public string CountryTaxLiability { get; set; }
        public string AdditionalInfo { get; set; }
        public int AccountStatus { get; set; }
        public int IsDeleted { get; set; }
        public int DeviceType { get; set; }
        public string DeviceToken { get; set; }
        public int IsFingerprintEnabled { get; set; }
        public int IsFaceEnabled { get; set; }
        public string VerificationCode { get; set; }
        public string ImeiNo { get; set; }
        public int ProfileStatus { get; set; }
        public int EmailStatus { get; set; }
        public string MobileOtp { get; set; }
        public int IsMobileVerified { get; set; }
        public string Role { get; set; }
    }
}
