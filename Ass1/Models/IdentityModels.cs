using System;
using System.Data.Entity;
using System.IO;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Ass1.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }      
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        //public System.Data.Entity.DbSet<Ass1.Models.ApplicationUser> ApplicationUsers { get; set; }
    }
}

namespace Ass1
{
    static class TimeHelper
    {
        public static string getTime(float lat = 0, float lon = 0)
        {
            string url = "http://www.earthtools.org/timezone/" + lat + "/" + lon;

            // http://forums.asp.net/t/1372395.aspx?Get+and+Post+data+using+Web+Service

            XmlDocument responseXML = new XmlDocument();
            WebRequest request = WebRequest.Create(url);
            using (WebResponse response = request.GetResponse())
            {
                StreamReader responseStream = new StreamReader(response.GetResponseStream());
                responseXML.LoadXml(responseStream.ReadToEnd());
                return responseXML.GetElementsByTagName("localtime")[0].InnerText;
            }

        }
    }

}