// -----------------------------------------------------------------------
// <copyright file="ServerEvents.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Vent173.EventHandlers
{
    using Exiled.API.Features;
    using MEC;
    using Vent173.Components;

    /// <summary>
    /// Manages all event handles subscribed from <see cref="Exiled.Events.Handlers.Server"/>.
    /// </summary>
    public class ServerEvents
    {
        private readonly Plugin plugin;
        private CoroutineHandle delayCoroutine;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServerEvents"/> class.
        /// </summary>
        /// <param name="plugin">An instance of the <see cref="Plugin"/> class.</param>
        public ServerEvents(Plugin plugin) => this.plugin = plugin;

        /// <summary>
        /// Subscribes to all required events.
        /// </summary>
        public void SubscribeAll()
        {
            Exiled.Events.Handlers.Server.RestartingRound += OnRestartingRound;
            Exiled.Events.Handlers.Server.RoundStarted += OnRoundStarted;
        }

        /// <summary>
        /// Unsubscribes from all required events.
        /// </summary>
        public void UnsubscribeAll()
        {
            Exiled.Events.Handlers.Server.RestartingRound -= OnRestartingRound;
            Exiled.Events.Handlers.Server.RoundStarted -= OnRoundStarted;
        }

        private void OnRestartingRound()
        {
            Timing.KillCoroutines(delayCoroutine);
            VentController.InitialDelay = true;
        }

        private void OnRoundStarted()
        {
            if (plugin.Config.InitialDelay == 0)
            {
                VentController.InitialDelay = false;
                return;
            }

            delayCoroutine = Timing.CallDelayed(plugin.Config.InitialDelay, () =>
            {
                VentController.InitialDelay = false;
                foreach (Player player in Player.Get(RoleType.Scp173))
                    player.Broadcast(plugin.Translation.Ready, true);
            });
        }
    }
}