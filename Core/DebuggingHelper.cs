using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SoulstoneCheats.Core
{
    // Uncomment this to get some patches useful for debugging, e.g. hooking into Prefab Instantiation
    //[HarmonyPatch]
    internal class DebuggingHelper
    {
        [HarmonyPostfix]
        [HarmonyPatch(typeof(UnityEngine.Object), nameof(UnityEngine.Object.Instantiate), new Type[] { typeof(UnityEngine.Object), typeof(Vector3), typeof(Quaternion) })]
        public static void Instantiate_Postfix1(UnityEngine.Object original, UnityEngine.Object __result)
        {
            Plugin.Log.LogInfo("Instantiate Prefab [1] " + original.name + ", " + __result.name);
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(UnityEngine.Object), nameof(UnityEngine.Object.Instantiate), new Type[] { typeof(UnityEngine.Object), typeof(Vector3), typeof(Quaternion), typeof(Transform) })]
        public static void Instantiate_Postfix2(UnityEngine.Object original, UnityEngine.Object __result)
        {
            Plugin.Log.LogInfo("Instantiate Prefab [2]  " + original.name + ", " + __result.name);
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(UnityEngine.Object), nameof(UnityEngine.Object.Instantiate), new Type[] { typeof(UnityEngine.Object), typeof(Transform) })]
        public static void Instantiate_Postfix3(UnityEngine.Object original, UnityEngine.Object __result)
        {
            Plugin.Log.LogInfo("Instantiate Prefab [3]  " + original.name + ", " + __result.name);
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(UnityEngine.Object), nameof(UnityEngine.Object.Instantiate), new Type[] { typeof(UnityEngine.Object), typeof(Transform), typeof(bool) })]
        public static void Instantiate_Postfix4(UnityEngine.Object original, UnityEngine.Object __result)
        {
            Plugin.Log.LogInfo("Instantiate Prefab [4]  " + original.name + ", " + __result.name);
        }


        [HarmonyPostfix]
        [HarmonyPatch(typeof(UnityEngine.Object), nameof(UnityEngine.Object.Instantiate), new Type[] { typeof(UnityEngine.Object) })]
        public static void Instantiate_Postfix5(UnityEngine.Object original, UnityEngine.Object __result)
        {
            Plugin.Log.LogInfo("Instantiate Prefab [5]  " + original.name + ", " + __result.name);
        }


        public Dictionary<string, GameObject> LoadPrefabs()
        {
            GameObject[] prefabs = Resources.LoadAll<GameObject>("");
            Plugin.Log.LogInfo("Found " + prefabs.Length + " prefabs.");
            Dictionary<string, GameObject> prefabDict = new();
            foreach (var prefab in prefabs)
            {
                Plugin.Log.LogDebug(prefab.tag + ", " + prefab.name);
                prefabDict.Add(prefab.name, prefab);
            }
            return prefabDict;
        }

        public static void LogGameObjectTree(GameObject relativeRoot)
        {
            Plugin.Log.LogInfo(" --- LogGameObjectTree --- ");
            //Scene scene = SceneManager.GetActiveScene();
            //GameObject[] obj = scene.GetRootGameObjects(); // not usable right now due to unstripping error with IL2CPP
            GameObject[] arr = relativeRoot == null ?
                UnityEngine.GameObject.FindObjectsOfType<GameObject>().Where(go => go.transform.root).Distinct().ToArray()
                : new GameObject[] { relativeRoot };

            foreach (var rootObj in arr)
            {
                Plugin.Log.LogInfo(rootObj.name + " - " + rootObj.tag + " - " + rootObj.layer);
                if (rootObj.name.StartsWith("Scenario"))
                {
                    Plugin.Log.LogInfo("Components: " + ComponentsString(rootObj));
                }
                LogObjectChildren(rootObj.transform, "");
            }
            Plugin.Log.LogInfo(" --- END --- ");
        }

        private static void LogObjectChildren(Transform parent, String padding)
        {
            var prefix = padding + "|--- ";
            for (var i = 0; i < parent.childCount; i++)
            {
                Transform child = parent.GetChild(i);
                Plugin.Log.LogInfo(prefix + child.name + " - " + child.tag + " - " + child.gameObject.layer);
                LogObjectChildren(child, padding + "     ");
            }
        }

        private static string ComponentsString(GameObject obj)
        {
            return String.Join(", ", obj.GetComponents<Component>().Select(component => component.GetIl2CppType().Name).ToArray());
        }

        public static void PrintStackTrace()
        {
            Plugin.Log.LogInfo(System.Environment.StackTrace);
        }
    }
}
