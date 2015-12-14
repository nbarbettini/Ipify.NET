/*
    Copyright © 2015 David Musgrove.
    Licensed under the terms of the MIT License.
*/

using System.Net;
using System.Threading.Tasks;

namespace Ipify
{
    public static partial class Ipify
    {
        /// <summary>
        /// Resolves the public IP address and returns it as a string.
        /// </summary>
        /// <param name="useHttps">
        /// Specifies whether to use HTTPS to talk to ipify.org (defaults to
        /// <b>false</b> if omitted).
        /// </param>
        /// <returns>
        /// A string containing the IP address, or an empty string if an error is
        /// encountered.
        /// </returns>
        public static Task<string> GetPublicAddressAsync(bool useHttps = false)
        {
            var endpoint = useHttps ? "https://api.ipify.org" : "http://api.ipify.org";
            WebClient client = new WebClient();
            try
            {
                return client.DownloadStringTaskAsync(endpoint);
            }
            catch
            {
                return Task.FromResult(string.Empty);
            }
        }

        /// <summary>
        /// Resolves the public IP address and returns it as an instance of
        /// <see cref="IPAddress" />.
        /// </summary>
        /// <param name="useHttps">
        /// Specifies whether to use HTTPS to talk to ipify.org (defaults to
        /// <b>false</b> if omitted).
        /// </param>
        /// <returns>
        /// An instance of <see cref="IPAddress" />. If an error occurs, then
        /// <see cref="IPAddress.None" /> is returned.
        /// encountered.
        /// </returns>
        public static async Task<IPAddress> GetPublicIPAddressAsync(bool useHttps = false)
        {
            string address = await GetPublicAddressAsync(useHttps).ConfigureAwait(false);
            IPAddress ipAddress;
            if (!IPAddress.TryParse(address, out ipAddress))
            {
                return IPAddress.None;
            }
            return ipAddress;
        }
    }
}
