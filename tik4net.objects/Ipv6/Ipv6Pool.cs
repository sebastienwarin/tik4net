using System;

namespace tik4net.Objects.Ip
{
    /// <summary>
    /// /ipv6/pool: IPv6 pools are used to define range of IPv6 addresses that is used for DHCPv6 server and Point-to-Point servers
    /// </summary>
    [TikEntity("/ipv6/pool", IncludeDetails = true)]
    public class Ipv6Pool
    {
        /// <summary>
        /// Row .id property.
        /// </summary>
        [TikProperty(".id", IsReadOnly = true, IsMandatory = true)]
        public string Id { get; private set; }

        /// <summary>
        /// Descriptive name of the pool
        /// </summary>
        [TikProperty("name", IsMandatory = true)]
        public string Name { get; set; }

        /// <summary>
        /// Ipv6 address prefix
        /// </summary>
        [TikProperty("prefix", IsMandatory = true)]
        public string Prefix { get; set; }

        /// <summary>
        /// Option represents the prefix size that will be give out to the client.
        /// </summary>
        [TikProperty("prefix-length", IsMandatory = true)]
        public int PrefixLength { get; set; }

        /// <summary>
        /// Whether pool is dynamic.
        /// </summary>
        [TikProperty("dynamic", IsReadOnly = true)]
        public bool Dynamic { get; set; }

        /// <summary>
        ///Expire time is set to dynamic pools added by DHCPv6 client.
        /// </summary>
        [TikProperty("expire-time", IsReadOnly = true)]
        public TimeSpan ExpireTime { get; set; }
    }
}
