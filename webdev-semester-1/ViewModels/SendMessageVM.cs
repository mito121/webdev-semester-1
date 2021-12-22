using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using webdev_semester_1.Models;

namespace webdev_semester_1.ViewModels
{
    public class SendMessageVM
    {
        public int SenderUserId { get; set; }

        [Display(Name = "Modtager")]
        public int RecieverUserId { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Besked")]
        public string Message { get; set; }
    }
}
