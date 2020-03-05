using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;

namespace Blazor.Teleport
{
    internal class Teleporter : ITeleporter
    {
        private readonly IDictionary<string, RenderFragment> _fragments = new Dictionary<string, RenderFragment>();

        public event Action<string> TeleportFinished;

        public void Beam(string toTarget, RenderFragment fragment)
        {
            if (string.IsNullOrEmpty(toTarget))
                throw new ArgumentNullException(nameof(toTarget));

            _fragments[toTarget] = fragment;

            TeleportFinished?.Invoke(toTarget);
        }

        public RenderFragment Materialize(string atTarget)
        {
            if (string.IsNullOrEmpty(atTarget))
                throw new ArgumentNullException(nameof(atTarget));

            if (!_fragments.ContainsKey(atTarget))
                return null;

            return _fragments[atTarget];
        }

        public void Unset(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));

            if (_fragments.ContainsKey(name))
                _fragments.Remove(name);

            TeleportFinished?.Invoke(name);

        }
    }
}
