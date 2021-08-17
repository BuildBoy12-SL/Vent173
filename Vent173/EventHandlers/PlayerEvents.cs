// -----------------------------------------------------------------------
// <copyright file="PlayerEvents.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Vent173.EventHandlers
{
    using Exiled.Events.EventArgs;
    using Vent173.Components;

    /// <summary>
    /// Manages all event handles subscribed from <see cref="Exiled.Events.Handlers.Player"/>.
    /// </summary>
    public class PlayerEvents
    {
        private readonly Plugin plugin;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerEvents"/> class.
        /// </summary>
        /// <param name="plugin">An instance of the <see cref="Plugin"/> class.</param>
        public PlayerEvents(Plugin plugin) => this.plugin = plugin;

        /// <summary>
        /// Subscribes to all required events.
        /// </summary>
        public void SubscribeAll()
        {
            Exiled.Events.Handlers.Player.ChangedRole += OnChangedRole;
        }

        /// <summary>
        /// Unsubscribes from all required events.
        /// </summary>
        public void UnsubscribeAll()
        {
            Exiled.Events.Handlers.Player.ChangedRole -= OnChangedRole;
        }

        private void OnChangedRole(ChangedRoleEventArgs ev)
        {
            if (ev.Player.GameObject.TryGetComponent(out VentController ventController))
                ventController.Destroy();

            if (ev.Player.Role == RoleType.Scp173)
                ev.Player.GameObject.AddComponent<VentController>();
        }
    }
}