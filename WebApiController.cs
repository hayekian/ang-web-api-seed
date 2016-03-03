using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using HLib;
using System.Text;
namespace SampleAngular
{
    public class TestClass {

        public string Name;
        public int Age;


    }

    public class WebApiController : ApiController
    {



     
        [HttpGet]
        // GET api/<controller>
        public IEnumerable<string> Get()
        {

            return new string[] { "value1", "value2" };
        }


        //[Route("api/GetValues")]
        //[HttpGet]
        //public HttpResponseMessage Get()
        //{
        //    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "value");

        //    var mediaType = new MediaTypeHeaderValue("application/json");


        //    response.Content = n
        //    response.Content.Headers.Add("Content-type", "text/json");
        //    response.Headers.CacheControl = new CacheControlHeaderValue()
        //    {
        //        MaxAge = TimeSpan.FromMinutes(20)
        //    };
        //    return response;
        //}


        //        Cache-Control:no-cache
        //Content-Length:19
        //Content-Type:application/json; charset=utf-8
        //Date:Wed, 02 Mar 2016 22:49:54 GMT
        //Expires:-1
        //Pragma:no-cache

        // GET api/<controller>/5
        public TestClass Get(int id)
        {
            TestClass c = new TestClass();
        
            return c;
        }


        //[Route("api/GetValues")]
        [HttpPost]
        public string Post(TestClass t)
        {
            var IsAdmin = System.Web.Security.Roles.IsUserInRole("admin");
            return t.ToJSON();
          

        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }

    public class PersonsController : ApiController
    {



        //[Route("api/GetValues")]
        //[HttpGet]
        //// GET api/<controller>
        //public IEnumerable<string> Get()
        //{

        //    return new string[] { "value1", "value2" };
        //}


        //[Route("api/GetValues")]
        //[HttpGet]
        //public HttpResponseMessage Get()
        //{
        //    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "value");

        //    var mediaType = new MediaTypeHeaderValue("application/json");


        //    response.Content = n
        //    response.Content.Headers.Add("Content-type", "text/json");
        //    response.Headers.CacheControl = new CacheControlHeaderValue()
        //    {
        //        MaxAge = TimeSpan.FromMinutes(20)
        //    };
        //    return response;
        //}


        //        Cache-Control:no-cache
        //Content-Length:19
        //Content-Type:application/json; charset=utf-8
        //Date:Wed, 02 Mar 2016 22:49:54 GMT
        //Expires:-1
        //Pragma:no-cache

        // GET api/<controller>/5
        public TestClass Get(int id)
        {
            TestClass c = new TestClass();
         
            return c;
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {

        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }

}