using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace dotnet_unpkg
{
    public static class Download
    {
        private static readonly HttpClient Client = new HttpClient
        {
            BaseAddress = new Uri("https://unpkg.com")
        };
        private static readonly string BaseDirectory = Path.Combine("wwwroot", "lib");
        
        public static async Task DistFile(string package, string path)
        {
            var target = TargetFile(path);
            using (var response = await Client.GetAsync(path))
            {
                if (response.IsSuccessStatusCode)
                {
                    var file = Path.GetFileName(target);
                    var directory = Path.Combine(BaseDirectory, package, Path.GetDirectoryName(target));

                    if (!Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }

                    using (var fileStream = File.Create(Path.Combine(directory, file)))
                    {
                        await response.Content.CopyToAsync(fileStream);
                    }

                    Console.WriteLine($"{Path.Combine(package, target)}... OK");
                }
                else
                {
                    Console.WriteLine($"{Path.Combine(package, target)}... failed ({(int)response.StatusCode}");
                }
            }
        }

        private static string TargetFile(string path) => path.Contains("/dist/")
            ? string.Join(Path.DirectorySeparatorChar,
                path.Split(new[] {'/'}, StringSplitOptions.RemoveEmptyEntries)
                    .SkipWhile(s => !s.Equals("dist", StringComparison.OrdinalIgnoreCase))
                    .Skip(1))
            : string.Join(Path.DirectorySeparatorChar,
                path.Split(new[] {'/'}, StringSplitOptions.RemoveEmptyEntries)
                    .Skip(1));
    }
}