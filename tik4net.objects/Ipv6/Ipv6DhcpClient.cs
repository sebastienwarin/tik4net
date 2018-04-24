using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tik4net.Objects.Ip
{
    /// <summary>
    /// ipv6/dhcp client
    /// DHCP-client in RouterOS is capable of being a DHCPv6-client and DHCP-PD client. So it is able to get a prefix from DHCP-PD server as well as DHCPv6 stateful address from DHCPv6 server.
    /// </summary>
    [TikEntity("ipv6/dhcp-client", IncludeDetails = true)]
    public class Ipv6DhcpClient
    {
        /// <summary>
        /// .id: primary key of row
        /// </summary>
        [TikProperty(".id", IsReadOnly = true, IsMandatory = true)]
        public string Id { get; private set; }

        /// <summary>
        /// Whether to add default IPv6 route after client connects.
        /// </summary>
        [TikProperty("add-default-route", DefaultValue = "no")]
        public bool AddDefaultRoute { get; set; }

        /// <summary>
        /// to choose if the DHCPv6 request will ask for the address or the IPv6 prefix, or both.
        /// </summary>
        [TikProperty("request")]
        public string Request { get; set; }

        /// <summary>
        /// Short description of the client
        /// </summary>
        [TikProperty("comment")]
        public string Comment { get; set; }
        
        /// <summary>
        /// disabled: 
        /// </summary>
        [TikProperty("disabled")]
        public bool Disabled { get; set; }

        /// <summary>
        /// Interface on which DHCPv6 client will be running.
        /// </summary>
        [TikProperty("interface")]
        public string Interface { get; set; }

        /// <summary>
        /// Name of the IPv6 pool in which received IPv6 prefix will be added
        /// </summary>
        [TikProperty("pool-name")]
        public string PoolName { get; set; }

        /// <summary>
        /// Run this script on the dhcp-client status change.
        /// </summary>
        [TikProperty("script")]
        public string Script { get; set; }

        /// <summary>
        /// Prefix length parameter that will be set for IPv6 pool in which received IPv6 prefix is added. Prefix length must be greater than the length of received prefix, otherwise prefix-length will be set to received prefix length + 8 bits.
        /// </summary>
        [TikProperty("pool-prefix-length")]
        public string PoolPrefixLength { get; set; }


        /// <summary>
        /// Auto generated DUID that is sent to the server. DUID is generated using one of the MAC addresses available on the router.
        /// </summary>
        [TikProperty("duid", IsReadOnly = true)]
        public string Duid { get; private set; }

        /// <summary>
        /// Shows whether configuration is dynamic.
        /// </summary>
        [TikProperty("dynamic", IsReadOnly = true)]
        public bool Dynamic { get; private set; }

        
        /// <summary>
        /// invalid: Shows whether configuration is invalid.
        /// </summary>
        [TikProperty("invalid", IsReadOnly = true)]
        public bool Invalid { get; private set; }

        /// <summary>
        /// Shows received IPv6 prefix from DHCPv6-PD server
        /// </summary>
        [TikProperty("prefix", IsReadOnly = true)]
        public string RawPrefix { get; private set; }

        /// <summary>
        /// Time when the IPv6 prefix expires (specified by the DHCPv6 server).
        /// </summary>
        [TikProperty("expires-after", IsReadOnly = true)]
        public TimeSpan ExpiresAfter { get; private set; }

        /// <summary>
        /// Shows received IPv6 prefix
        /// </summary>
        public string Prefix => this.RawPrefix.Split(',').FirstOrDefault()?.Trim();

        /// <summary>
        /// Time when the IPv6 prefix expires (specified by the DHCPv6 server).
        /// </summary>
        public TimeSpan PrefixExpiresAfter => TikTimeHelper.FromTikTimeToTimeSpan(this.RawPrefix.Split(',').LastOrDefault()?.Trim());

        /// <summary>
        /// Shows the status of DHCPv6 Client
        /// </summary>
        [TikProperty("status", IsReadOnly = true)]
        public string Status { get; private set; }

        /// <summary>
        /// Shows whether use peer DNS.
        /// </summary>
        [TikProperty("use-peer-dns", IsReadOnly = true)]
        public bool UsPeerDns { get; private set; }
        
        /// <summary>
        /// The DHCP server address
        /// </summary>
        [TikProperty("dhcp-server-v6", IsReadOnly = true)]
        public string DhcpServer { get; private set; }

        /// <summary>
        /// ctor
        /// </summary>
        public Ipv6DhcpClient()
        {
            //AddDefaultRoute = AddDefaultRouteType.Yes;
            //UsePeerDns = true;
            //UsePeerNtp = true;
        }

        /// <summary>
        /// Release current binding and restart DHCPv6 client
        /// </summary>
        public void Release(ITikConnection connection)
        {
            connection.CreateCommandAndParameters("ipv6/dhcp-client/release", 
                TikSpecialProperties.Id, Id).ExecuteNonQuery();
        }

        /// <summary>
        /// Renew current leases. If the renew operation was not successful, client tries to reinitialize lease (i.e. it starts lease request procedure (rebind) as if it had not received an IP address yet)
        /// </summary>
        public void Renew(ITikConnection connection)
        {
            connection.CreateCommandAndParameters("ipv6/dhcp-client/renew",
                TikSpecialProperties.Id, Id).ExecuteNonQuery();
        }
    }
}
