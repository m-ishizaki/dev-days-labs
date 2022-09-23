using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

using DevDaysSpeakers.Shared.Models;

using Newtonsoft.Json;

namespace DevDaysSpeakers.Services
{
    public static class AzureService
    {
        const string getSpeakersFunctionUrl = "https://devdaysspeakers-functions.azurewebsites.net/api/GetSpeakersFunction";

        static readonly Lazy<HttpClient> clientHolder = new Lazy<HttpClient>();
        static readonly Lazy<JsonSerializer> serializer = new Lazy<JsonSerializer>();

        static HttpClient Client => clientHolder.Value;
        static JsonSerializer Serializer => serializer.Value;

        public static Task<List<Speaker>> GetSpeakers() => GetObjectFromAPI<List<Speaker>>(getSpeakersFunctionUrl);

        //static async Task<T> GetObjectFromAPI<T>(string apiUrl)
        //{
        //    using (var stream = await Client.GetStreamAsync(apiUrl))
        //    using (var streamReader = new StreamReader(stream))
        //    using (var json = new JsonTextReader(streamReader))
        //    {
        //        return Serializer.Deserialize<T>(json);
        //    }
        //}
        const string speakersJson = "[{\"Name\":\"Kim Noel\", \"Description\":\"Kim is a co-organizer for Montreal Mobile .NET Developers\", \"Website\":\"https://www.linkedin.com/in/kimcodes/\", \"Title\":\"Community Engineer\", \"Avatar\":\"https://pbs.twimg.com/profile_images/1450506410404552709/T8TRq11u_400x400.jpg\"},{\"Name\":\"Martijn van Dijk\",\"Description\":\"Martijn is a Xamarin consultant at Xablu, Xamarin MVP, contributor of MvvmCross, and creator of several Xamarin plugins.\",\"Website\":\"https://www.xablu.com/\",\"Title\":\"Xamarin Consultant\",\"Avatar\":\"https://pbs.twimg.com/profile_images/1570003529783283712/Y_WgVMAQ_400x400.jpg\"},{ \"Name\":\"Michael Stonis\",\"Description\":\"Michael Stonis is a partner at Eight-Bot, a software consultancy in Chicago, where he focuses on mobile and integration solutions for enterprises using .NET. He loves mobile technology and how it has opened up our world in new and interesting ways that seemed like an impossibility just a few years ago. Outside of work, you will probably find him spending time with his family, brewing beer, or playing pinball.\",\"Website\":\"https://www.eightbot.com/\",\"Title\":\"President\",\"Avatar\":\"https://pbs.twimg.com/profile_images/1561829647020695552/i-iQc2NJ_400x400.jpg\"},{ \"Name\":\"Kasey Uhlenhuth\",\"Description\":\"Kasey Uhlenhuth is a program manager on the .NET Managed Languages team at Microsoft. She is currently working on modernizing the C# developer experience, but has also worked on C# scripting and the REPL. Before joining Microsoft, Kasey studied computer science and played varsity lacrosse at Harvard University. In her free time she can be found creating art, reading, or playing volleyball and ultimate frisbee.\",\"Website\":\"https://microsoft.com/\",\"Title\":\"Program Manager, .NET Managed Languages\",\"Avatar\":\"https://pbs.twimg.com/profile_images/1144225055821484034/AG94uGBE_400x400.jpg\"},{ \"Name\":\"Santosh Hari\",\"Description\":\"Santosh is an Azure MVP, Azure Consultant at NewSignature, President of Orlando Dot Net User Group and organizer of Orlando Code Camp.\",\"Website\":\"http://santoshhari.wordpress.com/\",\"Title\":\"Azure Consultant\",\"Avatar\":\"https://pbs.twimg.com/profile_images/1515077650557149195/ZoR5WdFD_400x400.jpg\"},{ \"Name\":\"Ana Betts\",\"Description\":\"Ana is a developer at Slack who works on the Windows and Linux application. Previously she was at GitHub where she built the GitHub Desktop application on Windows, as well as the popular Xamarin libraries ReactiveUI, ModernHttpClient, and Akavache.\",\"Website\":\"https://slack.com/\",\"Title\":\"Engineer\",\"Avatar\":\"https://pbs.twimg.com/profile_images/1489102828924817410/V5m0095-_400x400.jpg\"}]";
        static async Task<T> GetObjectFromAPI<T>(string apiUrl)
        {
            return JsonConvert.DeserializeObject<T>(speakersJson);
        }

    }
}