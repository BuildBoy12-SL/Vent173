// -----------------------------------------------------------------------
// <copyright file="Vent.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Vent173.Commands
{
    using System;
    using CommandSystem;
    using Exiled.API.Features;
    using RemoteAdmin;
    using Vent173.Components;

    /// <summary>
    /// Command to initialize and deactivate venting for Scp173.
    /// </summary>
    [CommandHandler(typeof(ClientCommandHandler))]
    public class Vent : ICommand
    {
        /// <inheritdoc />
        public string Command { get; } = "vent";

        /// <inheritdoc/>
        public string[] Aliases { get; } = Array.Empty<string>();

        /// <inheritdoc />
        public string Description { get; } = "Initializes a Scp173's ability to vent.";

        /// <inheritdoc />
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player player = Player.Get((sender as PlayerCommandSender)?.ReferenceHub);
            if (player == null)
            {
                response = "This command may only be executed from a client.";
                return false;
            }

            if (!player.GameObject.TryGetComponent(out VentController ventController))
            {
                response = "You must be a Scp173 to execute this command.";
                return false;
            }

            return ventController.ToggleVent(out response);
        }
    }
}