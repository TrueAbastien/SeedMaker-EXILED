using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Exiled.API.Interfaces;

namespace SeedMaker
{
    public sealed class Config : IConfig
    {
        /// <inheritdoc/>
        [Description("Indicates whether the plugin is enabled or not")]
        public bool IsEnabled { get; set; } = true;
    }
}
