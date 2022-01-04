using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.Events;
using Exiled.Events.EventArgs;
using Exiled.API.Features;
using ServerEvents = Exiled.Events.Handlers.Server;

namespace DisableMTF
{
    public class Plugin : Plugin<Config>
    {
        public static bool CanMTFSpawn;
        public override void OnEnabled()
        {
            CanMTFSpawn = true;
            ServerEvents.RespawningTeam += OnTeamSpawning;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            ServerEvents.RespawningTeam -= OnTeamSpawning;
            base.OnDisabled();
        }

        public void OnTeamSpawning(RespawningTeamEventArgs ev)
        {
            if(ev.NextKnownTeam == Respawning.SpawnableTeamType.NineTailedFox)
            {
                ev.IsAllowed = CanMTFSpawn;
            }
        }
    }
}
