using A2.Data;
using A2.MVC;
using BepInEx;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WarlordByChance
{
    [BepInPlugin("COM3D2.Lilly.Plugin", "COM3D2.Lilly.Plugin", "21.6.3")]// 버전 규칙 잇음. 반드시 2~4개의 숫자구성으로 해야함. 미준수시 못읽어들임

    public class Class1 : BaseUnityPlugin
    {
        public void Awake()
        {
            Harmony.CreateAndPatchAll(typeof(Class1));
        }

        public void Start()
        {
        }

        // GameModel

        [HarmonyPatch(typeof(GameModel), "UpdateManaValue")]
        [HarmonyPrefix]
        public static void UpdateManaValue(ref int value)
        {
            if (value<0)
            {
                value *= -1;
            }
            value *= 10000;
        }

        /*
        // public void RequestAddMana(float value)
        [HarmonyPatch(typeof(PlayerSpawner), "CurrentHeal", MethodType.Setter)]
        [HarmonyPrefix]
        public static void CurrentHeal(ref float value , float ___maxHeal)
        {
                value = ___maxHeal;            
        }
         */
       
        [HarmonyPatch(typeof(ISpawner), "OnDealDamageFlag")]
        [HarmonyPrefix]
        public static bool OnDealDamageFlag(TypeCharacter type, float damage, int idLane, TypeCharacter ___typeSpawner)
        {
            if (type==TypeCharacter.Player)
            {
                return false;
            }
            return true;
        }

        // public void RequestAddMana(float value)
        [HarmonyPatch(typeof(GameController), "RequestAddMana")]
        [HarmonyPrefix]
        public static void RequestAddMana(ref float value)
        {
                value *= 10000;            
        }
        [HarmonyPatch(typeof(GameController), "RequestAddPow")]
        [HarmonyPrefix]
        public static void RequestAddPow(ref float value)
        {
                value *= 10000;            
        }

        [HarmonyPatch(typeof(GameModel), "AddGem")]
        [HarmonyPrefix]
        public static void AddGem(ref double value)
        {
                value *= 10000;            
        }
        [HarmonyPatch(typeof(GameModel), "AddGold")]
        [HarmonyPrefix]
        public static void AddGold(ref double value)
        {
                value *= 10000;            
        }
        [HarmonyPatch(typeof(GameModel), "AddExp")]
        [HarmonyPrefix]
        public static void AddExp(ref float value)
        {
                value *= 10000;            
        }
        [HarmonyPatch(typeof(GameModel), "AddPow")]
        [HarmonyPrefix]
        public static void AddPow(ref int value)
        {
                value *= 10000;            
        }

        [HarmonyPatch(typeof(GameModel), "RemoveGem")]
        [HarmonyPrefix]
        public static void RemoveGem(ref double value)
        {
                value = 0;            
        }
        [HarmonyPatch(typeof(GameModel), "RemoveGold")]
        [HarmonyPrefix]
        public static void RemoveGold(ref double value)
        {
            value = 0;
        }

        [HarmonyPatch(typeof(GameModel), "RemovePow")]
        [HarmonyPrefix]
        public static void RemovePow(ref int value)
        {
            value = 0;
        }
        [HarmonyPatch(typeof(GameModel), "RemoveStar")]
        [HarmonyPrefix]
        public static  void RemoveStar(ref int value)
        {
            value = 0;
        }

    }
}
