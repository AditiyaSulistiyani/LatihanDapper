using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LatihanDapper.Entity
{
    internal class Supplier
    {
        public int SupplierId { get; set; }
        public string? CompanyName { get; set; }
        public string? ContactName { get; set; }
        public string? ContactTitle { get; set; }
/*        public string? Phone { get; set; }
        public string? Fax { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
        public string? HomePage { get; set; }*/

        public override string ToString()
        {
            /* return $"Supplier Id : {SupplierId} \nCompany Name : {CompanyName} \nContact Title : {ContactTitle}" +
                 $"\nPhone : {Phone} \nFax : {Fax} \nAddress : {Address}\nCity : {City}\nRegion : {Region}\nPostal Code : {PostalCode} \n" +
                 $"Country : {Country}\nHome Page : {HomePage}\n";*/
            return $"Supplier Id : {SupplierId} \nCompany Name : {CompanyName} \nContact Title : {ContactTitle}";
        }
    }
}
