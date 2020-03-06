using Microsoft.AspNetCore.Components;
using System;

namespace MiP.Blazor.Teleport
{
    public interface ITeleporter
    {
        void Beam(string toTarget, RenderFragment fragment);

        RenderFragment Materialize(string atTarget);

        void Unset(string name);

        event Action<string> TeleportFinished;
    }
}
