using System.Net;
using System.Text.RegularExpressions;

namespace EmailChecker
{
    public static class EmailValidator
    {
        private static readonly Regex EmailRegex = new(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled);

        public static bool IsValidSyntax(string email)
        {
            return EmailRegex.IsMatch(email);
        }

        public static bool DomainExists(string email)
        {
            try
            {
                var domain = email.Split('@')[1];
                var entries = Dns.GetHostEntry(domain);
                return entries.AddressList.Length > 0;
            }
            catch
            {
                return false;
            }
        }

        public static bool HasMXRecord(string email)
        {
            try
            {
                var domain = email.Split('@')[1];
                var process = new System.Diagnostics.Process
                {
                    StartInfo = new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = "nslookup",
                        Arguments = $"-type=MX {domain}",
                        RedirectStandardOutput = true,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    }
                };

                process.Start();
                string output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();

                return output.Contains("mail exchanger");
            }
            catch
            {
                return false;
            }
        }

        public static bool IsDisposable(string email, HashSet<string> disposableDomains)
        {
            try
            {
                var domain = email.Split('@')[1].ToLower();
                return disposableDomains.Contains(domain);
            }
            catch
            {
                return false;
            }
        }
    }
}
