using CollisionEventsAPI.Models;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;

namespace CollisionEventsAPI.Controllers
{
    public class EventsController : ApiController
    {
        List<CollisionEventModel> data = new List<CollisionEventModel>();

        // GET api/values/5
        [HttpGet]
        public HttpResponseMessage CollisionStatus()
        {
            HttpResponseMessage response;
            Result result = new Result();
            try
            {
                var collisionEventsList = Utilities.FakeData();
                var operator_id = Utilities.GetHeader(Request.Headers, "operator_id");
                if (!string.IsNullOrEmpty(operator_id))
                {
                    var eventList = collisionEventsList.Where(p => p.operator_id == operator_id).ToList();
                    response = Request.CreateResponse<List<CollisionEventModel>>(HttpStatusCode.OK, eventList);
                   
                }
                else
                {
                    result.Message = "operator_id cannot be null";
                    result.Status = "Error";
                    response = Request.CreateResponse<Result>(HttpStatusCode.OK, result);
                }
                
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.Status = "Error";
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, result);
            }
            return response;
        }

        // POST api/values
        [HttpPost]
        public HttpResponseMessage AddEvent(CollisionEventModel model)
        {
            HttpResponseMessage response;
            Result result = new Result();
            try
            {                
                var collisionEventsList = Utilities.FakeData();
                var operator_id = Utilities.GetHeader(Request.Headers, "operator_id");
                if (operator_id == model.operator_id)
                {
                    if (collisionEventsList.Where(p => p.message_id == model.message_id).Count() > 0)
                    {
                        result.Message = "Message already exists";
                        result.Status = "Error";
                        
                    }
                    else if (model.probability_of_collision < 0 || model.probability_of_collision > 1)
                    {
                        result.Message = "Collision probability should be in between 0 and 1 ";
                        result.Status = "Error";                        
                    }
                    else if (model.collision_date.Date <= DateTime.Now.Date)
                    {
                        result.Message = "Collision date should be in future";
                        result.Status = "Error";
                    }
                    else
                    {
                        collisionEventsList.Add(model);
                        result.Message = "Event added successfully";
                        result.Status = "Success";
                    }                    
                }
                else
                {
                    result.Message = "Invoking operator_id is different from header operator_id";
                    result.Status = "Error";                    
                }
                response = Request.CreateResponse<Result>(HttpStatusCode.OK, result);

            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.Status = "Error";
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, result);
            }
            return response;
        }

        [HttpPut]
        public HttpResponseMessage CancelEvent(CollisionEventModel model)
        {
            HttpResponseMessage response;
            Result result = new Result();
            try
            {
                var collisionEventsList = Utilities.FakeData();
                var operator_id = Utilities.GetHeader(Request.Headers, "operator_id");
                if (operator_id == model.operator_id)
                {
                    if (collisionEventsList.Where(p => p.message_id == model.message_id).Count()>0)
                    {
                        if (model.collision_date.Date <= DateTime.Now.Date)
                        {
                            result.Message = "Collision date should be in future";
                            result.Status = "Error";
                        }
                        else
                        {
                            result.Message = "Event cancelled successfully";
                            result.Status = "Success";
                        }

                    }
                    else
                    {
                        result.Message = "Message doesnot exists";
                        result.Status = "Error";
                    }
                }
                else
                {
                    result.Message = "Invoking operator_id is different from header operator_id";
                    result.Status = "Error";
                }
                response = Request.CreateResponse<Result>(HttpStatusCode.OK, result);

            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.Status = "Error";
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, result);
            }
            return response;
        }

    }
}
