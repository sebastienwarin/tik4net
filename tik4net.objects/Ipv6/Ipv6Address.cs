namespace tik4net.Objects.Ipv6
{
    /// <summary>
    /// /ip/address: IPv6 uses 16 bytes addresses compared to 4 byte addresses in IPv4. IPv6 address syntax and types are described in RFC 4291.
    /// </summary>
    [TikEntity("/ipv6/address", IncludeDetails = true)]
    public class Ipv6Address
    {
        /// <summary>
        /// Row .id property.
        /// </summary>
        [TikProperty(".id", IsReadOnly = true, IsMandatory = true)]
        public string Id { get; private set; }

        /// <summary>
        /// Ipv6 address. 
        /// </summary>
        [TikProperty("address", IsMandatory = true)]
        public string Address { get; set; }

        /// <summary>
        /// Whether to enable stateless address configuration. The prefix of that address is automatically advertised to hosts using ICMPv6 protocol. The option is set by default for addresses with prefix length 64.
        /// </summary>
        [TikProperty("advertise")]
        public bool Advertise { get; set; }

        /// <summary>
        /// Descriptive name of an item
        /// </summary>
        [TikProperty("comment")]
        public string Comment { get; set; }

        /// <summary>
        /// Whether address is disabled or not. By default it is disabled
        /// </summary>
        [TikProperty("disabled")]
        public bool Disabled { get; set; }

        /// <summary>
        /// Whether to calculate EUI-64 address and use it as last 64 bits of the IPv6 address
        /// </summary>
        [TikProperty("eui-64")]
        public bool Eui64 { get; set; }

        /// <summary>
        /// Name of the pool from which prefix will be taken to construct IPv6 address taking last part of the address from address property
        /// </summary>
        [TikProperty("from-pool")]
        public string FromPool { get; set; }

        /// <summary>
        /// If set indicates that address is anycast address and Duplicate Address Detection should not be performed.
        /// </summary>
        [TikProperty("no-dad")]
        public bool NoDAD  { get; set; }

        /// <summary>
        /// Name of an interface on which Ipv6 address is set.
        /// </summary>
        [TikProperty("interface", IsMandatory = true)]
        public string Interface { get; set; }

        /// <summary>
        /// Actual interface on which address is set up. 
        /// </summary>
        [TikProperty("actual-interface", IsReadOnly = true)]
        public string ActualInterface { get; private set; }

        /// <summary>
        /// Whether address is dynamically created
        /// </summary>
        [TikProperty("dynamic", IsReadOnly = true)]
        public bool Dynamic { get; set; }
        
        /// <summary>
        /// Whether address is global 
        /// </summary>
        [TikProperty("global ", IsReadOnly = true)]
        public bool Global { get; set; }

        /// <summary>
        /// Whether address is invalid.
        /// </summary>
        [TikProperty("invalid", IsReadOnly = true)]
        public bool Invalid { get; set; }
        
        /// <summary>
        /// Whether address is link local
        /// </summary>
        [TikProperty("link-local", IsReadOnly = true)]
        public bool LinkLocal { get; set; }
    }
}
