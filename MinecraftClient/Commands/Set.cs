﻿using System.Collections.Generic;

namespace MinecraftClient.Commands
{
    public class Set : Command
    {
        public override string CmdName { get { return "set"; } }
        public override string CmdUsage { get { return "set varname=value"; } }
        public override string CmdDesc { get { return Translations.cmd_set_desc; } }

        public override string Run(McClient handler, string command, Dictionary<string, object>? localVars)
        {
            if (HasArg(command))
            {
                string[] temp = GetArg(command).Split('=');
                if (temp.Length > 1)
                {
                    if (Settings.Config.AppVar.SetVar(temp[0], GetArg(command).Substring(temp[0].Length + 1)))
                        return ""; //Success
                    else 
                        return Translations.cmd_set_format;
                }
                else
                    return GetCmdDescTranslated();
            }
            else
                return GetCmdDescTranslated();
        }
    }
}
