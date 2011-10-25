using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Atos.Web.Mobile.Trends.Models
{
    public class User
    {
        public int Id { get; set; }
        public char Gender { get; set; }
        public string Region { get; set; }
        public string Browser { get; set; }
        public string BrowserVersion { get; set; }
        public string Platform { get; set; }
        public string IPAddress { get; set; }
        public int AnswerId { get; set; }
    }
}