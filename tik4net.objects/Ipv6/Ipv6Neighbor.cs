namespace tik4net.Objects.Ip
{
    /// <summary>
    /// /ipv6/neighbor: List of all discovered nodes by IPv6 neighbor discovery protocol (neighbor cache).
    /// </summary>
    [TikEntity("/ipv6/neighbor", IncludeDetails = true)]
    public class Ipv6Neighbor
    {
        /// <summary>
        /// Row .id property.
        /// </summary>
        [TikProperty(".id", IsReadOnly = true, IsMandatory = true)]
        public string Id { get; private set; }

        /// <summary>
        /// Link-local address of the node.
        /// </summary>
        [TikProperty("address", IsReadOnly = true, IsMandatory = true)]
        public string Address { get; private set; }

        /// <summary>
        /// Descriptive name of an item
        /// </summary>
        [TikProperty("comment")]
        public string Comment { get; set; }

        /// <summary>
        /// Interface on which node was detected.
        /// </summary>
        [TikProperty("interface", IsMandatory = true)]
        public string Interface { get; set; }

        /// <summary>
        /// Mac address of discovered node.
        /// </summary>
        [TikProperty("mac-address", IsReadOnly = true)]
        public string MacAddress { get; set; }

        /// <summary>
        /// Whether discovered node is router
        /// </summary>
        [TikProperty("router", IsReadOnly = true)]
        public bool Router { get; set; }

        /// <summary>
        /// Whether discovered node is router
        /// </summary>
        [TikProperty("status", IsReadOnly = true)]
        public string Status { get; set; }
    }
}
