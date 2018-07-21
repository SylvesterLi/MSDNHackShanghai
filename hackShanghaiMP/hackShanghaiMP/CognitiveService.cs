using RestSharp;
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
        //static string post_url = "https://eastus2.api.cognitive.microsoft.com/face/v1.0/detect?returnFaceId=true&returnFaceLandmarks=false&returnFaceAttributes=age,gender,headPose,smile,facialHair,glasses,emotion,hair,makeup,occlusion,accessories,blur,exposure,noise";
        //static string auth_key = "7d4007bbda084c91b3121a28409aca81";
        public static int ComputerVisionService(string PicUrl)
        {
            var client = new RestClient("https://eastus2.api.cognitive.microsoft.com/face/v1.0/detect?returnFaceId=true&returnFaceLandmarks=false&returnFaceAttributes=age,gender,headPose,smile,facialHair,glasses,emotion,hair,makeup,occlusion,accessories,blur,exposure,noise");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Postman-Token", "e0c4f46e-c25d-4e4b-9c98-8e54b3b0d076");
            request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("Ocp-Apim-Subscription-Key", "7d4007bbda084c91b3121a28409aca81");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("undefined", "{\n\t\"url\":\"" + PicUrl + "\"\n}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            ComputerVisionResult responseObject;
            responseObject = Newtonsoft.Json.JsonConvert.DeserializeObject<ComputerVisionResult>(response.Content);
            return responseObject.Property1[0].faceAttributes.emotion.happiness;
        }
        public static string BotService(string userWords)
        {
            string botAnswerJson = null;
            string post_url = "https://luckbotforcompt.azurewebsites.net/qnamaker/knowledgebases/c9946ee5-254c-4047-b4f4-e31cbf6ba990/generateAnswer";


            var request = WebRequest.Create(post_url);
            string data = "{ \"question\": \"" + userWords + "\"}";
            request.Headers["Authorization"] = "EndpointKey 11b886e0-1f74-4064-907a-0be7f331400d";
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
                    botAnswerJson = result.ToString();
                }
            }
            BotAnsers responseObject;
            responseObject = Newtonsoft.Json.JsonConvert.DeserializeObject<BotAnsers>(botAnswerJson);
            return responseObject.answers[0].answer;


        }
    }

    #region BotService机器人问答类
    public class BotAnsers
    {
        public BotServiceAnswer[] answers { get; set; }
    }

    public class BotServiceAnswer
    {
        public string[] questions { get; set; }
        public string answer { get; set; }
        public float score { get; set; }
        public int id { get; set; }
        public string source { get; set; }
        public object[] metadata { get; set; }
    }
    #endregion


    #region ss


    public class ComputerVisionResult
    {
        public Class1[] Property1 { get; set; }
    }

    public class Class1
    {
        public string faceId { get; set; }
        public Facerectangle faceRectangle { get; set; }
        public Faceattributes faceAttributes { get; set; }
    }

    public class Facerectangle
    {
        public int top { get; set; }
        public int left { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Faceattributes
    {
        public int smile { get; set; }
        public Headpose headPose { get; set; }
        public string gender { get; set; }
        public int age { get; set; }
        public Facialhair facialHair { get; set; }
        public string glasses { get; set; }
        public Emotion emotion { get; set; }
        public Blur blur { get; set; }
        public Exposure exposure { get; set; }
        public Noise noise { get; set; }
        public Makeup makeup { get; set; }
        public Accessory[] accessories { get; set; }
        public Occlusion occlusion { get; set; }
        public Hair hair { get; set; }
    }

    public class Headpose
    {
        public int pitch { get; set; }
        public float roll { get; set; }
        public float yaw { get; set; }
    }

    public class Facialhair
    {
        public int moustache { get; set; }
        public int beard { get; set; }
        public int sideburns { get; set; }
    }

    public class Emotion
    {
        public int anger { get; set; }
        public int contempt { get; set; }
        public int disgust { get; set; }
        public int fear { get; set; }
        public int happiness { get; set; }
        public int neutral { get; set; }
        public int sadness { get; set; }
        public int surprise { get; set; }
    }

    public class Blur
    {
        public string blurLevel { get; set; }
        public float value { get; set; }
    }

    public class Exposure
    {
        public string exposureLevel { get; set; }
        public float value { get; set; }
    }

    public class Noise
    {
        public string noiseLevel { get; set; }
        public int value { get; set; }
    }

    public class Makeup
    {
        public bool eyeMakeup { get; set; }
        public bool lipMakeup { get; set; }
    }

    public class Occlusion
    {
        public bool foreheadOccluded { get; set; }
        public bool eyeOccluded { get; set; }
        public bool mouthOccluded { get; set; }
    }

    public class Hair
    {
        public float bald { get; set; }
        public bool invisible { get; set; }
        public Haircolor[] hairColor { get; set; }
    }

    public class Haircolor
    {
        public string color { get; set; }
        public float confidence { get; set; }
    }

    public class Accessory
    {
        public string type { get; set; }
        public float confidence { get; set; }
    }


    #endregion

}