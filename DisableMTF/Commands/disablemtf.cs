using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandSystem;
using Exiled.Permissions.Extensions;

namespace DisableMTF.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    class disablemtf : ICommand
    {
        public string Command { get; } = "disablemtf";
        public string[] Aliases { get; } = new string[] { "dismtf" };
        public string Description { get; } = "You can disable mtf spawn, and retyping the command, you can reactivate it";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if(!sender.CheckPermission("disablemtf.dismtf"))
            {
                response = "You can't do that, because you haven't the disablemtf.dismtf permission";
                return false;
            } else
            {
                if (Plugin.CanMTFSpawn == true)
                {
                    response = "MTF Spawning disabled";
                    Plugin.CanMTFSpawn = false;
                    return true;
                }
                else
                {
                    response = "MTF Spawning enabled";
                    Plugin.CanMTFSpawn = true;
                    return true;
                }
            }
        }
    }
}
