using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace DBA_Simulation_App_AutomationTests
{
    internal class ChromeDriverInstaller
    {
        private const string ChromeExeRegistryPath = "HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\App Paths\\chrome.exe";

        private static readonly HttpClient httpClient = new HttpClient { BaseAddress = new Uri("https://googlechromelabs.github.io/chrome-for-testing/") };

        public async Task Install(string chromeVersion)
        {
            // Instructions from https://chromedriver.chromium.org/downloads/version-selection
            //   First, find out which version of Chrome you are using. Let's say you have Chrome 72.0.3626.81.
            if (string.IsNullOrEmpty(chromeVersion))
            {
                chromeVersion = await GetChromeVersion();
            }

            //   Take the Chrome version number, remove the last part, 
            chromeVersion = chromeVersion.Substring(0, chromeVersion.LastIndexOf('.'));

            //   and append the result to URL "https://chromedriver.storage.googleapis.com/LATEST_RELEASE_". 
            //   For example, with Chrome version 72.0.3626.81, you'd get a URL "https://chromedriver.storage.googleapis.com/LATEST_RELEASE_72.0.3626".
            var chromeDriverVersionResponse = await httpClient.GetAsync($"LATEST_RELEASE_{chromeVersion}");
            if (!chromeDriverVersionResponse.IsSuccessStatusCode)
            {
                if (chromeDriverVersionResponse.StatusCode == HttpStatusCode.NotFound)
                {
                    throw new Exception($"ChromeDriver version not found for Chrome version {chromeVersion}");
                }
                else
                {
                    throw new Exception($"ChromeDriver version request failed with status code: {chromeDriverVersionResponse.StatusCode}, reason phrase: {chromeDriverVersionResponse.ReasonPhrase}");
                }
            }

            var chromeDriverVersion = await chromeDriverVersionResponse.Content.ReadAsStringAsync();

            string zipName;
            string driverName;
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                zipName = "chromedriver-win32.zip";
                driverName = "chromedriver.exe";
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                zipName = "chromedriver_linux64.zip";
                driverName = "chromedriver";
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                zipName = "chromedriver_mac64.zip";
                driverName = "chromedriver";
            }
            else
            {
                throw new PlatformNotSupportedException("Your operating system is not supported.");
            }

            string targetPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            targetPath = Path.Combine(targetPath, driverName);
            //Check if file(chromedriver.exe) is exists on target path 
            if (File.Exists(targetPath))
            {
                //Kill processes for chromedriver
                foreach (var process in Process.GetProcessesByName("chromedriver"))
                    process.Kill();
                File.Delete(targetPath);
            }

            //   Use the URL created in the last step to retrieve a small file containing the version of ChromeDriver to use. For example, the above URL will get your a file containing "72.0.3626.69". (The actual number may change in the future, of course.)
            //   Use the version number retrieved from the previous step to construct the URL to download ChromeDriver. With version 72.0.3626.69, the URL would be "https://chromedriver.storage.googleapis.com/index.html?path=72.0.3626.69/".
            var newHttpClient = new HttpClient { BaseAddress = new Uri("https://edgedl.me.gvt1.com/edgedl/chrome/chrome-for-testing/") };
            var driverZipResponse = await newHttpClient.GetAsync($"{chromeDriverVersion}/win32/{zipName}");
            //var driverZipResponse = await httpClient.GetAsync($"{chromeDriverVersion}/{zipName}");
            if (!driverZipResponse.IsSuccessStatusCode)
            {
                throw new Exception($"ChromeDriver download request failed with status code: {driverZipResponse.StatusCode}, reason phrase: {driverZipResponse.ReasonPhrase}");
            }

            // this reads the zipfile as a stream, opens the archive, 
            // and extracts the chromedriver executable to the targetPath without saving any intermediate files to disk
            using (var zipFileStream = await driverZipResponse.Content.ReadAsStreamAsync())
            using (var zipArchive = new ZipArchive(zipFileStream, ZipArchiveMode.Read))
            using (var chromeDriverWriter = new FileStream(targetPath, FileMode.Create))
            {
                //var entry = zipArchive.GetEntry(driverName);
                var entry = zipArchive.GetEntry($"chromedriver-win32/{driverName}");
                Stream chromeDriverStream = entry.Open();
                await chromeDriverStream.CopyToAsync(chromeDriverWriter);
            }

            // on Linux/macOS, you need to add the executable permission (+x) to allow the execution of the chromedriver
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) || RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                var process = Process.Start(
                    new ProcessStartInfo
                    {
                        FileName = "chmod",
                        // ArgumentList = { "+x", targetPath },
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                    }
                );
                string error = await process.StandardError.ReadToEndAsync();
                process.WaitForExit();
                process.Kill();

                if (!string.IsNullOrEmpty(error))
                {
                    throw new Exception("Failed to make chromedriver executable");
                }
            }
        }

        public async Task<string> GetChromeVersion()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                string chromePath = (string)Registry.GetValue(ChromeExeRegistryPath, null, null);
                if (chromePath == null)
                {
                    throw new Exception("Google Chrome not found in registry");
                }

                var fileVersionInfo = FileVersionInfo.GetVersionInfo(chromePath);
                return fileVersionInfo.FileVersion;
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                try
                {
                    var process = Process.Start(
                       new ProcessStartInfo
                       {
                           FileName = "google-chrome",
                           // ArgumentList = { "--product-version" },
                           UseShellExecute = false,
                           CreateNoWindow = true,
                           RedirectStandardOutput = true,
                           RedirectStandardError = true,
                       }
                   );
                    string output = await process.StandardOutput.ReadToEndAsync();
                    string error = await process.StandardError.ReadToEndAsync();
                    process.WaitForExit();
                    process.Kill();

                    if (!string.IsNullOrEmpty(error))
                    {
                        throw new Exception(error);
                    }

                    return output;
                }
                catch (Exception ex)
                {
                    throw new Exception("An error occurred trying to execute 'google-chrome --product-version'", ex);
                }
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                try
                {
                    var process = Process.Start(
                       new ProcessStartInfo
                       {
                           FileName = "/Applications/Google Chrome.app/Contents/MacOS/Google Chrome",
                           // ArgumentList = { "--version" },
                           UseShellExecute = false,
                           CreateNoWindow = true,
                           RedirectStandardOutput = true,
                           RedirectStandardError = true,
                       }
                   );
                    string output = await process.StandardOutput.ReadToEndAsync();
                    string error = await process.StandardError.ReadToEndAsync();
                    process.WaitForExit();
                    process.Kill();

                    if (!string.IsNullOrEmpty(error))
                    {
                        throw new Exception(error);
                    }

                    output = output.Replace("Google Chrome ", "");
                    return output;
                }
                catch (Exception ex)
                {
                    throw new Exception($"An error occurred trying to execute '/Applications/Google Chrome.app/Contents/MacOS/Google Chrome --version'", ex);
                }
            }
            else
            {
                throw new PlatformNotSupportedException("Your operating system is not supported.");
            }
        }
    }
}
