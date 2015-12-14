/*
    Copyright © 2015 David Musgrove.
    Licensed under the terms of the MIT License.
*/

using System.Net;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Ipify.Tests
{
    [TestFixture]
    public class IpifyTestsAsync
    {
        [Test]
        public async Task GetAddress_ReturnsStringContainingAnIPAddressAsync()
        {
            string ip = await Ipify.GetPublicAddressAsync();
            IPAddress ipAddress;
            Assert.IsTrue(IPAddress.TryParse(ip, out ipAddress));
        }

        [Test]
        public async Task GetAddress_ReturnsStringContainingAnIPAddressUsingHttpsAsync()
        {
            string ip = await Ipify.GetPublicAddressAsync(true);
            IPAddress ipAddress;
            Assert.IsTrue(IPAddress.TryParse(ip, out ipAddress));
        }

        [Test]
        public async Task GetIPAddress_ReturnsIPAddressInstanceAsync()
        {
            IPAddress ipAddress = await Ipify.GetPublicIPAddressAsync();
            Assert.IsNotNull(ipAddress);
            Assert.AreNotEqual(IPAddress.None, ipAddress);
        }

        [Test]
        public async Task GetIPAddress_ReturnsIPAddressInstanceUsingHttpsAsync()
        {
            IPAddress ipAddress = await Ipify.GetPublicIPAddressAsync(true);
            Assert.IsNotNull(ipAddress);
            Assert.AreNotEqual(IPAddress.None, ipAddress);
        }
    }
}
