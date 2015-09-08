﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tik4net
{
    /// <summary>
    /// Named parameter used by <see cref="ITikCommand"/>.
    /// </summary>
    public interface ITikCommandParameter
    {
        /// <summary>
        /// Parameter name
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Parameter value (formated to string as expected by <see cref="ITikConnection"/>).
        /// </summary>
        string Value { get; set; }
    }
}