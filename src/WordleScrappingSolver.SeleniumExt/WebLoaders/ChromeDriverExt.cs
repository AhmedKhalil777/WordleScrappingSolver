using OpenQA.Selenium.Chrome;

using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WordleScrappingSolver.SeleniumExt.WebLoaders
{
    public static class ChromeDriverExt
    {

        public static async Task<ChromeDriver> GetChromeDriver(Dictionary<string,string> configs)
        {
            
            await DownloadAndExtract(configs);
            return new ChromeDriver("./");
        }


        private static async Task DownloadAndExtract(Dictionary<string, string> configs)
        {
            if (File.Exists("./chromedriver.exe"))
            {
                return;
            }
            var httpClient = new HttpClient();
            var fileInfo = new FileInfo($"chromedriver_win32.zip");
            var downloaded = false;
            if (File.Exists("./chromedriver_win32.zip"))
            {
                downloaded = true;
            }
            if (!downloaded && configs!= null)
            {
                var response = await httpClient.GetAsync(configs["ChromeLink"]);
                response.EnsureSuccessStatusCode();
                await using var ms = await response.Content.ReadAsStreamAsync();
                await using var fs = File.Create(fileInfo.FullName);
                ms.Seek(0, SeekOrigin.Begin);
                ms.CopyTo(fs);
                downloaded = true;
            }

            if(downloaded)
            {
                string zipPath = @"./chromedriver_win32.zip";
                string extractPath = @"./";
                ZipFile.ExtractToDirectory(zipPath, extractPath);
            }

        }
    }
}
