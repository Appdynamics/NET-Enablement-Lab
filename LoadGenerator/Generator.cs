using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace LoadGenerator
{
    

    public class Generator
    {
        private string url;
        private List<string> users;
        private List<string> patterns;
        private string loginUrl;
        private List<string> loginHeaders;


        public Generator(string url, string[] users, string[] patterns, string loginUrl, string[] loginHeaders)
        {
            this.url = url;

            this.users = new List<string>(users);
            this.users.Shuffle();

            this.patterns = new List<string>(patterns);
            this.patterns.Shuffle();

            this.loginUrl = loginUrl;
            this.loginHeaders = new List<string>(loginHeaders);
            this.loginHeaders.Shuffle();
        }

        public void Run()
        {
            Task.Run(async() => 
            {
                while(true)
                {
                    foreach(var user in users)
                    {
                        // Login with random provider

                        string login = string.Format(loginUrl, url);

                        var request = new HttpRequestMessage()
                        {
                            RequestUri = new Uri(login),
                            Method = HttpMethod.Get,
                        };

                        if (new Random().NextDouble() > 0.33)
                        {
                            string provider = loginHeaders[new Random().Next(loginHeaders.Count)];
                            if (!string.IsNullOrEmpty(provider))
                                request.Headers.Add("_provider", provider);
                        }

                        request.Headers.Add("_userId", user);

                        try
                        {
                            var c = new HttpClient();
                            var response = await c.SendAsync(request);
                            string content = await response.Content.ReadAsStringAsync();
                        }
                        catch { }

                        // Generate requests to all paterns for the user

                        foreach (var pattern in patterns)
                        {
                            string t = string.Format(pattern, url, user, Guid.NewGuid());
                            Console.WriteLine(t);

                            try
                            {
                                var c1 = new HttpClient();
                                await c1.GetStringAsync(t);
                            }
                            catch 
                            { }
                        }
                    }
                }
            });
        }
    }
}
