using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace hackShanghaiMP
{
    public class CognitiveService
    {
        //计算机视觉Key
        static string post_url = "https://eastus2.api.cognitive.microsoft.com/face/v1.0";
        static string auth_key = "7d4007bbda084c91b3121a28409aca81";
        public static float ComputerVisionService(string PicUrl)
        {
            string recivedMessage = "";
            var request = WebRequest.Create(post_url);
            string data = "{ \"url\": \"" + PicUrl + "\"}";
            request.Headers["Ocp-Apim-Subscription-Key"] = auth_key;
            request.ContentType = "application/json";
            request.Method = "POST";
            using (var requestStream = request.GetRequestStream())
            {
                var writer = new StreamWriter(requestStream);
                writer.Write(data);
                writer.Flush();

            }
            using (var resp = request.GetResponse())
            {
                using (var responseStream = resp.GetResponseStream())
                {
                    var reader = new StreamReader(responseStream);
                    var result = reader.ReadToEnd();
                    recivedMessage = result.ToString();
                }
            }
            ComputerVisionResult responseObject;
            responseObject = Newtonsoft.Json.JsonConvert.DeserializeObject<ComputerVisionResult>(recivedMessage);
            return responseObject.scores.happiness();
        }
    }


    public class ComputerVisionResult
    {
        public Facerectangle faceRectangle { get; set; }
        public Scores scores { get; set; }
    }

    public class Facerectangle
    {
        public int left { get; set; }
        public int top { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Scores
    {
        public float anger { get; set; }
        public float contempt { get; set; }
        public float disgust { get; set; }
        public float fear { get; set; }
        public float happiness { get; set; }
        public float neutral { get; set; }
        public float sadness { get; set; }
        public float surprise { get; set; }
    }


  

}