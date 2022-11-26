using CollisionEventsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;

namespace CollisionEventsAPI
{
    public static class Utilities
    {
        public static List<CollisionEventModel> FakeData()
        {
            List<CollisionEventModel> data = new List<CollisionEventModel>();
            data.Add(new CollisionEventModel() { 
                message_id="1",
                chaser_object_id="1",
                collision_date=new DateTime(2022,01,01),
                collision_event_id="1",
                operator_id="123",
                probability_of_collision=0.1,
                satellite_id= "1999-123"

            });
            data.Add(new CollisionEventModel()
            {
                message_id = "2",
                chaser_object_id = "2",
                collision_date = new DateTime(2022, 01, 01),
                collision_event_id = "2",
                operator_id = "123",
                probability_of_collision = 0.5,
                satellite_id = "1999-1232"

            });
            data.Add(new CollisionEventModel()
            {
                message_id = "3",
                chaser_object_id = "3",
                collision_date = new DateTime(2022, 01, 01),
                collision_event_id = "3",
                operator_id = "456",
                probability_of_collision = 0.5,
                satellite_id = "2000-123"

            });

            return data;
        }

        public static string GetHeader(HttpRequestHeaders headers, string key)
        {
            string token=null;
            if (headers.Contains(key))
            {
                token = headers.GetValues(key).First();
            }
            return token;


        }
    }
}