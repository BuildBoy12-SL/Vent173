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

    public class Translation : ITranslation
    {
        public Broadcast Spawn { get; set; } = new Broadcast("<size=80><color=#0020ed><b>Vent</b></color></size>\n<i><size=30>In this server, you can go invisible for a few seconds by typing '.vent' into your console.\nYou cannot attack in this mode, but you can phase through doors by interacting with them.</size></i>", 15);

        public Broadcast Activation { get; set; } = new Broadcast("<i>You have activated your vent ability!</i>", 3);

        public Broadcast Ending { get; set; } = new Broadcast("<i>Your ability has worn off.</i>", 3);

        public Broadcast Ready { get; set; } = new Broadcast("<i>Your vent ability is ready!</i>", 3);

        public string OnCooldown { get; set; } = "<i>Your vent ability will be usable in <b>%seconds</b> seconds.</i>";

        public string CannotVentOnSurface { get; set; } = "<color=red>You cannot use your vent ability on the surface.</color>";
    }
}