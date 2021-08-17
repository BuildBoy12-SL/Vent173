// -----------------------------------------------------------------------
// <copyright file="Config.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Vent173
{
    using Exiled.API.Interfaces;

    /// <inheritdoc />
    public class Config : IConfig
    {
        /// <inheritdoc />
        public bool IsEnabled { get; set; } = true;

        public bool CanVentOnSurface { get; set; } = false;

        public bool CanVentThroughLocks { get; set; } = false;

        public float InitialDelay { get; set; } = 30f;

        public float VentDuration { get; set; } = 10f;

        public float Cooldown { get; set; } = 30f;

        public float KillCooldown { get; set; } = 1.5f;
    }
}