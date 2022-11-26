using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollisionEventsAPI.Models
{
    public class CollisionEventModel
    {
        public string message_id { get; set; }
        public string collision_event_id { get; set; }
        public string satellite_id { get; set; }
        public string operator_id { get;set; }
        public double probability_of_collision { get;set;}
        public DateTime collision_date { get; set; }    
        public string chaser_object_id { get; set; }
    }
}