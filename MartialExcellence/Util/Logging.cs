﻿using System.Collections.Generic;
using static UnityModManagerNet.UnityModManager.ModEntry;

namespace MartialExcellence.Util
{
    // With the exception of a mod specific variable, this class in entirely created by Github user WittleWolfie
    internal static class Logging
    {
        private const string BaseChannel = "ME";

        private static readonly Dictionary<string, ModLogger> Loggers = new();

        internal static ModLogger GetLogger(string channel)
        {
            if (Loggers.ContainsKey(channel))
            {
                return Loggers[channel];
            }
            var logger = new ModLogger($"{BaseChannel}+{channel}");
            Loggers[channel] = logger;
            return logger;
        }
    }
}