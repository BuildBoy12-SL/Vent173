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

        /// <summary>
        /// Gets or sets a value indicating whether Scp173 can vent on the surface zone.
        /// </summary>
        public bool CanVentOnSurface { get; set; } = false;

        /// <summary>
        /// Gets or sets a value indicating whether Scp173 can vent through locked doors.
        /// </summary>
        public bool CanVentThroughLocks { get; set; } = false;

        /// <summary>
        /// Gets or sets the set cooldown for the vent ability when the round starts.
        /// </summary>
        public float InitialDelay { get; set; } = 30f;

        /// <summary>
        /// Gets or sets the duration of the vent ability.
        /// </summary>
        public float VentDuration { get; set; } = 10f;

        /// <summary>
        /// Gets or sets the amount of cooldown time between abilities.
        /// </summary>
        public float Cooldown { get; set; } = 30f;

        /// <summary>
        /// Gets or sets the amount of seconds after exiting the vent ability before Scp173 can attack.
        /// </summary>
        public float KillCooldown { get; set; } = 1.5f;
    }
}