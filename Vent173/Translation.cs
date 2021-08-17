// -----------------------------------------------------------------------
// <copyright file="Translation.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Vent173
{
    using Exiled.API.Features;
    using Exiled.API.Interfaces;

    /// <inheritdoc />
    public class Translation : ITranslation
    {
        /// <summary>
        /// Gets or sets the broadcast to be sent to the Scp173 when they spawn.
        /// </summary>
        public Broadcast Spawn { get; set; } = new Broadcast("<size=80><color=#0020ed><b>Vent</b></color></size>\n<i><size=30>In this server, you can go invisible for a few seconds by typing '.vent' into your console.\nYou cannot attack in this mode, but you can phase through doors by interacting with them.</size></i>", 15);

        /// <summary>
        /// Gets or sets the broadcast to be sent to the Scp173 when they activate the vent ability.
        /// </summary>
        public Broadcast Activation { get; set; } = new Broadcast("<i>You have activated your vent ability!</i>", 3);

        /// <summary>
        /// Gets or sets the broadcast to be sent to the Scp173 when the vent ability expires.
        /// </summary>
        public Broadcast Ending { get; set; } = new Broadcast("<i>Your ability has worn off.</i>", 3);

        /// <summary>
        /// Gets or sets the broadcast to be sent to the Scp173 when the vent ability's cooldown expires.
        /// </summary>
        public Broadcast Ready { get; set; } = new Broadcast("<i>Your vent ability is ready!</i>", 3);

        /// <summary>
        /// Gets or sets the response to be sent to the Scp173 when they attempt to vent while still on cooldown.
        /// </summary>
        public string OnCooldown { get; set; } = "<i>Your vent ability will be usable in <b>%seconds</b> seconds.</i>";

        /// <summary>
        /// Gets or sets the response to be sent to the Scp173 when they attempt to vent on the surface while <see cref="Config.CanVentOnSurface"/> is disabled.
        /// </summary>
        public string CannotVentOnSurface { get; set; } = "<color=red>You cannot use your vent ability on the surface.</color>";
    }
}