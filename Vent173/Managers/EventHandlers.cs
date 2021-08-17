// -----------------------------------------------------------------------
// <copyright file="EventHandlers.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

using Interactables.Interobjects.DoorUtils;

namespace Vent173.Managers
{
    using Exiled.API.Features;
    using Exiled.Events.EventArgs;
    using Vent173.Components;

    /// <summary>
    /// Handles EXILED events for a given <see cref="VentController"/>.
    /// </summary>
    public class EventHandlers
    {
        private readonly VentController ventController;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventHandlers"/> class.
        /// </summary>
        /// <param name="ventController">An instance of the <see cref="VentController"/> component.</param>
        public EventHandlers(VentController ventController) => this.ventController = ventController;

        /// <summary>
        /// Subscribes to all required events.
        /// </summary>
        public void SubscribeAll()
        {
            Exiled.Events.Handlers.Player.Hurting += OnHurting;
            Exiled.Events.Handlers.Player.InteractingDoor += OnInteractingDoor;
            Exiled.Events.Handlers.Player.TriggeringTesla += OnTriggeringTesla;
        }

        /// <summary>
        /// Unsubscribes from all required events.
        /// </summary>
        public void UnsubscribeAll()
        {
            Exiled.Events.Handlers.Player.Hurting -= OnHurting;
            Exiled.Events.Handlers.Player.InteractingDoor -= OnInteractingDoor;
            Exiled.Events.Handlers.Player.TriggeringTesla -= OnTriggeringTesla;
        }

        private void OnHurting(HurtingEventArgs ev)
        {
            if (MeetsVentRequirements(ev.Target))
                ev.IsAllowed = false;
        }

        private void OnInteractingDoor(InteractingDoorEventArgs ev)
        {
            if (MeetsVentRequirements(ev.Player))
                ev.IsAllowed = false;
        }

        private void OnTriggeringTesla(TriggeringTeslaEventArgs ev)
        {
            if (MeetsVentRequirements(ev.Player))
                ev.IsTriggerable = false;
        }

        private bool MeetsVentRequirements(Player player) => ventController.IsVenting && ventController.Player == player;
    }
}