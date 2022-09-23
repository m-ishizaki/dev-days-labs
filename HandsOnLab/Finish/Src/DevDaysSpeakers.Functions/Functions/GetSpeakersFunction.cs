using System.Collections.Generic;
using DevDaysSpeakers.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace DevDaysSpeakers.Functions
{
    public static class GetSpeakersFunction
    {
        [FunctionName(nameof(GetSpeakersFunction))]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequest req, ILogger log)
        {
            log.LogInformation("Generating Speakers");

            var speakersList = GenerateSpeakers();

            log.LogInformation("Returning Speaker List");

            return new OkObjectResult(speakersList);
        }

        static List<Speaker> GenerateSpeakers()
        {
            return new List<Speaker>
            {
                new Speaker
                {
                    Name = "Kim Noel",
                    Description = "Kim is a co-organizer for Montreal Mobile .NET Developers",
                    Title = "Community Engineer",
                    Website = "https://www.linkedin.com/in/kimcodes/",
                    Avatar = "https://pbs.twimg.com/profile_images/1450506410404552709/T8TRq11u_400x400.jpg"
                },
                new Speaker
                {
                    Name = "Martijn van Dijk",
                    Description = "Martijn is a Xamarin consultant at Xablu, Xamarin MVP, contributor of MvvmCross, and creator of several Xamarin plugins.",
                    Title = "Xamarin Consultant",
                    Website = "https://www.xablu.com/",
                    Avatar = "https://pbs.twimg.com/profile_images/1570003529783283712/Y_WgVMAQ_400x400.jpg",
                },
                new Speaker
                {
                    Name = "Michael Stonis",
                    Description = "Michael Stonis is a partner at Eight-Bot, a software consultancy in Chicago, where he focuses on mobile and integration solutions for enterprises using .NET. He loves mobile technology and how it has opened up our world in new and interesting ways that seemed like an impossibility just a few years ago. Outside of work, you will probably find him spending time with his family, brewing beer, or playing pinball.",
                    Title = "President",
                    Website = "https://www.eightbot.com/",
                    Avatar = "https://pbs.twimg.com/profile_images/1561829647020695552/i-iQc2NJ_400x400.jpg",
                },
                new Speaker
                {
                    Name = "Kasey Uhlenhuth",
                    Description = "Kasey Uhlenhuth is a program manager on the .NET Managed Languages team at Microsoft. She is currently working on modernizing the C# developer experience, but has also worked on C# scripting and the REPL. Before joining Microsoft, Kasey studied computer science and played varsity lacrosse at Harvard University. In her free time she can be found creating art, reading, or playing volleyball and ultimate frisbee.",
                    Title = "Program Manager, .NET Managed Languages",
                    Website = "https://microsoft.com/",
                    Avatar = "https://pbs.twimg.com/profile_images/1144225055821484034/AG94uGBE_400x400.jpg",
                },
                new Speaker
                {
                    Name = "Santosh Hari",
                    Description = "Santosh is an Azure MVP, Azure Consultant at NewSignature, President of Orlando Dot Net User Group and organizer of Orlando Code Camp.",
                    Title = "Azure Consultant",
                    Website = "http://santoshhari.wordpress.com/",
                    Avatar = "https://pbs.twimg.com/profile_images/1515077650557149195/ZoR5WdFD_400x400.jpg",
                },
                new Speaker
                {
                    Name = "Ana Betts",
                    Description = "Ana is a developer at Slack who works on the Windows and Linux application. Previously she was at GitHub where she built the GitHub Desktop application on Windows, as well as the popular Xamarin libraries ReactiveUI, ModernHttpClient, and Akavache.",
                    Title = "Engineer",
                    Website = "https://slack.com/",
                    Avatar = "https://pbs.twimg.com/profile_images/1489102828924817410/V5m0095-_400x400.jpg",
                },
            };
        }
    }
}
