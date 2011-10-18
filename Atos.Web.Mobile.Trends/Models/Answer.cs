using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Atos.Web.Mobile.Trends.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Answer
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string Description { get; set; }
        public int? NumberOfChosenAsAnswer { get; set; }
        public Question Question { get; set; }
        
    }
}