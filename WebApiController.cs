using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using HLib;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

using Amazon.Polly;
using Amazon.Polly.Model;
using System.IO;

namespace SampleAngular
{
    public class TestClass {

        public string Name;
        public int Age;


    }


    public class HApiController : ApiController
    {

        public HttpResponseMessage GetFileResponse(string filename, byte[] data, string contentType)
        {
            var result = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ByteArrayContent(data)
            };
            result.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
            {
                FileName = filename
            };
            result.Content.Headers.ContentType = new MediaTypeHeaderValue(contentType);

            return result;
        }

        public JObject GetPostedJSON()
        {
            try
            {
                return JObject.Parse(this.GetPostedString());
            }
            catch (Exception ex)
            {

                return new JObject();

            }
        }

        public string GetPostedString()
        {
            return this.Request.Content.ReadAsStringAsync().Result;
        }

        [Route("api/WriteObject")]
        [HttpPost]
        [Authorize]
        private void WriteObject()
        {
            JObject APP = this.GetPostedJSON();
            string key = APP["key"].ToString();
            string obj = APP["obj"].ToString();
            DB.Database.Save(key, obj);
        }
        [Route("api/ReadObject")]
        [HttpPost]
        [Authorize]
        private string ReadObject()
        {
            JObject APP = this.GetPostedJSON();
            string key = APP["key"].ToString();
            return DB.Database.Load(key);
        }



        public Dictionary<string, object> CreateFrameworkObjResponse(int status, string message, object data)
        {
            Dictionary<string, object> res = new Dictionary<string, object>();
            res["STATUS"] = status;
            res["MSG"] = message;
            res["DATA"] = data;

            return res;


        }



    }



    public class WebApiController : HApiController
    {

        JObject web_response = new JObject();
        public static List<Voice> voices = null;

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

        [Route("api/test")]
        [HttpGet]
        public string test()
        {
            return "hello";


        }

        //[Route("api/testaws")]
        //[HttpGet]
        //public string testaws()
        //{
        //    using (var client = new AmazonS3Client(Amazon.RegionEndpoint.USEast1))
        //    {
        //        Console.WriteLine("Listing objects stored in a bucket");

        //        GetObjectListWithAllVersions(client);
        //    }

        //    return web_response.ToString();

        //}


        [Route("api/GetVoices")]
        [HttpGet]
        public object GetVoices()
        {
           
           
            try
            {

                AmazonPollyClient client = new AmazonPollyClient(Amazon.RegionEndpoint.USEast1);

                // Create describe voices request.
                DescribeVoicesRequest describeVoicesRequest = new DescribeVoicesRequest();
                // Synchronously ask Amazon Polly to describe available TTS voices.
                DescribeVoicesResponse describeVoicesResult = client.DescribeVoices(describeVoicesRequest);
                voices = describeVoicesResult.Voices;
                return voices;

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "ok";

        }


        [Route("api/text-to-speech")]
        [HttpPost]
        public object textToSpeech()
        {
            var APP = this.GetPostedJSON();
            string filename = "";
            try
            {
               
                AmazonPollyClient client = new AmazonPollyClient(Amazon.RegionEndpoint.USEast1);

                var voiceId = voices.SingleOrDefault(v => v.Id.Value == APP["VoiceId"].ToStringOrBlank());


                // Create speech synthesis request.
                SynthesizeSpeechRequest synthesizeSpeechPresignRequest = new SynthesizeSpeechRequest();
                // Text
                synthesizeSpeechPresignRequest.TextType = TextType.Ssml;
                synthesizeSpeechPresignRequest.Text = APP["text"].ToStringOrBlank();
                // Select voice for synthesis.
                synthesizeSpeechPresignRequest.VoiceId = voiceId.Id;
                // Set format to MP3.
                synthesizeSpeechPresignRequest.OutputFormat = OutputFormat.Mp3;
                // Get the presigned URL for synthesized speech audio stream.

               
                filename = "output.mp3";
                var path_audio = System.Web.Hosting.HostingEnvironment.MapPath("/") + filename;

                var presignedSynthesizeSpeechUrl = client.SynthesizeSpeechAsync(synthesizeSpeechPresignRequest).GetAwaiter().GetResult();

                FileStream wFile = new FileStream(path_audio, FileMode.Create);
                presignedSynthesizeSpeechUrl.AudioStream.CopyTo(wFile);
                wFile.Close();
                return CreateFrameworkObjResponse(0, null,
                    "data:audio/mp3;base64," + System.Convert.ToBase64String(File.ReadAllBytes(path_audio)));
            }
            catch (Exception ex)
            {
                return CreateFrameworkObjResponse(-1, ex.Message,null);
            }
          

        }

        //private void GetObjectListWithAllVersions(AmazonS3Client client)
        //{
        //    try
        //    {
        //        ListVersionsRequest request = new ListVersionsRequest()
        //        {
        //            BucketName = "hayekian-animalaid",
        //            // You can optionally specify key name prefix in the request
        //            // if you want list of object versions of a specific object.

        //            // For this example we limit response to return list of 2 versions.
        //            MaxKeys = 2
        //        };
        //        do
        //        {
        //            ListVersionsResponse response = client.ListVersions(request);
        //            // Process response.
        //            foreach (S3ObjectVersion entry in response.Versions)
        //            {
        //                web_response[entry.Key] = entry.Size;
        //                Console.WriteLine("key = {0} size = {1}",
        //                    entry.Key, entry.Size);
        //            }

        //            // If response is truncated, set the marker to get the next 
        //            // set of keys.
        //            if (response.IsTruncated)
        //            {
        //                request.KeyMarker = response.NextKeyMarker;
        //                request.VersionIdMarker = response.NextVersionIdMarker;
        //            }
        //            else
        //            {
        //                request = null;
        //            }
        //        } while (request != null);

        //    }
        //    catch (Exception ex) {
        //        Console.Write("error");
        //    }
           
        //}


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