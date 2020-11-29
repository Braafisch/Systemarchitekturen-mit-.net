using System;
using System.Text.RegularExpressions;

namespace aufgabe5
{
    public class URL
    {
        public string Url { get; private set; }
        public string Scheme { get; private set; }
        public string Host { get; private set; }
        public string Path { get; private set; }
        public URL(string url)
        {
            var pattern = @"(?'scheme'[a-z][a-z0-9+.\-]*?):(\/\/(?'host'[\w.\-\[\]:]*?)(\/|$)|\/)(?'path'.*)";
            var match = Regex.Match(url, pattern);
            if(match.Success && match.Groups["scheme"].Length > 0)
            {
                Url = url;
                Scheme = match.Groups["scheme"].ToString();
                Host = match.Groups["host"].ToString();
                Path = match.Groups["path"].ToString();
            }
            else
            {
                throw new FormatException("Invalid URL format: " + url);
            }
        }
        public override string ToString()
        {
            return Url ?? string.Empty;
        }
        static void Main(string[] args)
        {
            foreach (var arg in args)
            {
                var url = new URL(arg);
                Console.WriteLine("Url: {0}\nprotocol: {1}\nAuthority: {2}\nPath: {3}", url.Url, url.Scheme, url.Host, url.Path);
            }
        }
    }
}
