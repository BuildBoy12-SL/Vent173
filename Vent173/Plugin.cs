// -----------------------------------------------------------------------
// <copyright file="Plugin.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Vent173
{
    using System;
    using Exiled.API.Features;
    using Vent173.EventHandlers;

    /// <summary>
    /// The main plugin class.
    /// </summary>
    public class Plugin : Plugin<Config, Translation>
    {
        private static readonly Plugin InstanceValue = new Plugin();

        private Plugin()
        {
        }

        /// <summary>
        /// Gets the only instance of the <see cref="Plugin"/> class.
        /// </summary>
        public static Plugin Instance { get; } = InstanceValue;

        /// <inheritdoc />
        public override string Author { get; } = "Build";

        /// <inheritdoc />
        public override string Name { get; } = "Vent173";

        /// <inheritdoc />
        public override string Prefix { get; } = "vent";

        /// <inheritdoc />
        public override Version RequiredExiledVersion { get; } = new Version(2, 13, 0);

        /// <inheritdoc />
        public override Version Version { get; } = new Version(2, 0, 0);

        /// <summary>
        /// Gets an instance of the <see cref="EventHandlers.PlayerEvents"/> class.
        /// </summary>
        public PlayerEvents PlayerEvents { get; private set; }

        /// <summary>
        /// Gets an instance of the <see cref="EventHandlers.ServerEvents"/> class.
        /// </summary>
        public ServerEvents ServerEvents { get; private set; }

        /// <inheritdoc />
        public override void OnEnabled()
        {
            PlayerEvents = new PlayerEvents(this);
            ServerEvents = new ServerEvents(this);

            PlayerEvents.SubscribeAll();
            ServerEvents.SubscribeAll();
            base.OnEnabled();
        }

        /// <inheritdoc />
        public override void OnDisabled()
        {
            PlayerEvents.UnsubscribeAll();
            ServerEvents.UnsubscribeAll();

            PlayerEvents = null;
            ServerEvents = null;
            base.OnDisabled();
        }
    }
}