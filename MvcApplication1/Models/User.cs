using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class User
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string ColorName { get; set; }
        public Color UserColor { get; set; }
    }
}