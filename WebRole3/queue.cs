using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebRole1
{
    public class queue
    {
        public int Id { get; set; }
        public bool MessageHandle { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Adult { get; set; }
        public string Student { get; set; }
        public string Infant { get; set; }
        public string Child { get; set; }
       
        public string Price { get; set; }

        public queue()
        {
            Id = Id + 1;
        }
    }
}