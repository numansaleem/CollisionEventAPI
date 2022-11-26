using CollisionEventsAPI.Controllers;
using CollisionEventsAPI.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Http;

namespace UnitTestCollisionEvents
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAddEvent()
        {

            HttpRequestMessage request = new HttpRequestMessage();
            HttpControllerContext controllerContext = new HttpControllerContext();
            controllerContext.Request = request;
            HttpActionContext context = new HttpActionContext();
            context.ControllerContext = controllerContext;
            HttpAuthenticationContext m = new HttpAuthenticationContext(context, null);
            HttpRequestHeaders headers = request.Headers;;
            headers.Add("operator_id","123");

            var controller = new EventsController();
            controller.Request = request;
            controller.Request.SetConfiguration(new HttpConfiguration());


            //var controller = new EventsController();
            var model = new CollisionEventModel()
            {
                message_id = "1312312",
                chaser_object_id = "1",
                collision_date = new DateTime(2022, 12, 12),
                collision_event_id = "1",
                operator_id = "123",
                probability_of_collision = 0.1,
                satellite_id = "1999-123"

            };
            var result = controller.AddEvent(model);
            
            Assert.AreEqual(System.Net.HttpStatusCode.OK, result.StatusCode);
        }

        [TestMethod]
        public void TestCancelEvent()
        {

            HttpRequestMessage request = new HttpRequestMessage();
            HttpControllerContext controllerContext = new HttpControllerContext();
            controllerContext.Request = request;
            HttpActionContext context = new HttpActionContext();
            context.ControllerContext = controllerContext;
            HttpAuthenticationContext m = new HttpAuthenticationContext(context, null);
            HttpRequestHeaders headers = request.Headers; ;
            headers.Add("operator_id", "123");

            var controller = new EventsController();
            controller.Request = request;
            controller.Request.SetConfiguration(new HttpConfiguration());


            //var controller = new EventsController();
            var model = new CollisionEventModel()
            {
                message_id = "1",
                collision_date = new DateTime(2022,12, 12),
                operator_id = "123",

            };
            var result = controller.AddEvent(model);

            Assert.AreEqual(System.Net.HttpStatusCode.OK, result.StatusCode);
        }
    }
}
