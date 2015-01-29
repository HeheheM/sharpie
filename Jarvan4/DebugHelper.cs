﻿using System;
using System.Collections.Generic;
using LeagueSharp;

namespace Jarvan4
{
    class DebugHelper
    {
        //Teddybears to DZ191
        public static Dictionary<String, String> DebugDictionary = new Dictionary<string, string>();
        private static float _lastPrint;

        public static void OnLoad()
        {
            Drawing.OnDraw += Drawing_OnDraw;
        }

        static void Drawing_OnDraw(EventArgs args)
        {
            if (!JMenu.Config.Item("Debug").GetValue<bool>())
                return;
            var counter = 1;
            foreach (var entry in DebugDictionary)
            {
                Drawing.DrawText(25f, 10f + (20f * counter), System.Drawing.Color.White, entry.Key + ": " + entry.Value);
                counter++;
            }
        }

        public static void AddEntry(String key, String value)
        {
            if (DebugDictionary.ContainsKey(key))
            {
                DebugDictionary[key] = value;
            }
            else
            {
                DebugDictionary.Add(key, value);
            }
        }

        public static void PrintDebug(String message)
        {
            if (!JMenu.Config.Item("Debug").GetValue<bool>())
                return;
            if (Environment.TickCount - _lastPrint > 150)
            {
                _lastPrint = Environment.TickCount;
                Game.PrintChat("<font='#FF0000'>[DZAIO]</font><font color='#FFFFFF'>" + message + "</font>");
            }
        }
    }
}
