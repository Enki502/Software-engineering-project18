using System;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            SessionController Controller = new SessionController();
            Controller.Initialise();

            Console.ReadKey();
        }
    }
        
    class SessionController
    {
        public SessionController()
        {
            
        }
        public void Initialise()
        {
            string UserTitle ="";
            Menu(UserTitle);
            OMDbInterface OMDbInterface = new OMDbInterface();
            JObject FilmData = OMDbInterface.GetDataRecords(UserTitle);


        }

        public void Menu(string UserTitle)
        {
            Console.WriteLine("Enter movie title");
            UserTitle = Console.ReadLine();
        }

        public void DisplayFilmInfo(JObject FilmData)
        {
            foreach (JProperty property in FilmData.Properties())
            {
                Console.WriteLine(property.Name + " - " + property.Value);
            }
        }
    }

    class OMDbInterface
    {
        public OMDbInterface()
        {

        }

        public JObject GetDataRecords(string Title)
        {
            return JObject.Parse(GET("http://www.omdbapi.com/?t=" + Title + "&apikey=c5f5153e"));
        }

        string GET(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            WebResponse response = request.GetResponse();
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, System.Text.Encoding.UTF8);
                return reader.ReadToEnd();
            }


            //try
            //{
            //    WebResponse response = request.GetResponse();
            //    using (Stream responseStream = response.GetResponseStream())
            //    {
            //        StreamReader reader = new StreamReader(responseStream, System.Text.Encoding.UTF8);
            //        return reader.ReadToEnd();
            //    }
            //}
            //catch (WebException ex)
            //{
            //    WebResponse errorResponse = ex.Response;
            //    using (Stream responseStream = errorResponse.GetResponseStream())
            //    {
            //        StreamReader reader = new StreamReader(responseStream, System.Text.Encoding.GetEncoding("utf-8"));
            //        String errorText = reader.ReadToEnd();
            //        // log errorText
            //    }
            //    throw;
        }
    }

    class DisplayFilmProperties
    {
        public DisplayFilmProperties()
        {
        }

    }



}
