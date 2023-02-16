using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using System;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Reflection;

namespace ValheimFasterRaft
{
    [BepInPlugin("plootopia.ValheimFasterRaft", "Valheim Faster Raft", "1.0.0")]
    [BepInProcess("valheim.exe")]
    public class ValheimFasterRaft : BaseUnityPlugin
    {
        private readonly Harmony harmony = new Harmony("plootopia.ValheimFasterRaft");

        void Awake()
        {
            harmony.PatchAll();
        }

        [HarmonyPatch(typeof(Ship), "Start")]
        class Ship_Start_patch
        {
            static void Prefix(Ship __instance)
            {
                Debug.Log(__instance);

            }
        }


        [HarmonyPatch(typeof(Ship), nameof(Ship.Rudder))]
        class Rudder_Patch
        {
            static void Prefix()
            {
                Debug.Log("rudder");


            }
        }


        [HarmonyPatch(typeof(Ship), nameof(Ship.Forward))]
        class Forward_patch
        {
            static void Prefix(Ship __instance)
            {
                //This controls how fast the 'steering wheel bar' (the yellow bar) turns
                __instance.m_rudderSpeed = 3.5f;

                //this is the paddling speed
                __instance.m_backwardForce = 10f;
                //__instance.m_force = 1000f;

                //these appear to be how much you slide when you turn
                __instance.m_stearForce = 1.5f;
                __instance.m_dampingSideway = 5f;
                Debug.Log("forward: " + __instance.ToString());
                Debug.Log("rudder speed: " + __instance.m_rudderSpeed);
                Debug.Log("rudder object: " + __instance.m_rudderObject);
                Debug.Log("backward force: " + __instance.m_backwardForce);
                Debug.Log("force: " + __instance.m_force);
                Debug.Log("stear force: " + __instance.m_stearForce);
                Debug.Log("stear force offset: " + __instance.m_stearForceOffset);
                Debug.Log("type: " + __instance.GetType());

            }
        }
    }
}