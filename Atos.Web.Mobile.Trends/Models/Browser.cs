using System;
using System.ComponentModel.DataAnnotations;

namespace Atos.Web.Mobile.Trends.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Browser
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
        public string Platform { get; set; }
        public string ClientIP { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}