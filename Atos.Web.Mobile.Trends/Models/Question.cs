using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Script.Serialization;

namespace Atos.Web.Mobile.Trends.Models
{
    [Serializable]
    public class Question
    {
        public int QuestionId { get; set; }
        public string Description { get; set; }
        [ScriptIgnore]
        public IList<Answer> Answers { get; set; }
    }
}