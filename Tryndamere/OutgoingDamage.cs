﻿using System;
using System.IO;
using System.Linq;
using LeagueSharp;
using LeagueSharp.Common;


namespace Tryhardamere
{
    internal class OutgoingDamage
    {
        public static int AutosToLethal(Obj_AI_Hero target)
        {
            return (int) Math.Round(target.Health / ObjectManager.Player.GetAutoAttackDamage(target));
        }

        public static float TimeToMeleeKill(Obj_AI_Hero target)
        {
            var aspd = ObjectManager.Player.AttackSpeedMod * 0.67f;
            return (float) Math.Round(AutosToLethal(target) / aspd);
        }

        public static float TimeToReach(Obj_AI_Hero target)
        {
            float moveSpeedDiff;

            if (Math.Abs(ObjectManager.Player.MoveSpeed - target.MoveSpeed) < 0.1f)
            {
                moveSpeedDiff = 0f;
            }
            
            else
            {
                moveSpeedDiff = ObjectManager.Player.MoveSpeed - target.MoveSpeed;
            }

            if (moveSpeedDiff <= 0f)
            {
                return -1f;
            }

            return ObjectManager.Player.Distance(target) / moveSpeedDiff;
        }

        public static bool IsMovingToMe(Obj_AI_Hero target)
        {
            if (target.Path.Count() > 0)
            {
                var targetPath = target.Path[0].To2D();
                if (ObjectManager.Player.Distance(target) > ObjectManager.Player.Distance(targetPath))
                {
                    return true;
                }
            }
            else if (!target.IsMoving)
            {
                return true;
            }
            return false;
        }

    }
}