using BepInEx.Unity.IL2CPP.Utils.Collections;
using ECM2.Common;
using Il2CppSystem.Runtime.Remoting.Messaging;
using SoulstoneTweaks.Core.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.AI.Navigation;
using UnityEngine;

namespace SoulstoneTweaks.Modifications
{
    /// <summary>
    /// Remove all obstacles from the map (except the outer boundaries)
    /// Note: The naming is not consistent throughout maps, so if new maps are added, this will most likely not work.
    /// Note2: The NavMesh doesn't update properly for some reason, so the mobs still act as if there are obstacles.
    /// </summary>
    public class MapObstacleModification
    {

        public static void RemoveMapObstacles()
        {
            if (!PluginConfig.RemoveMapObstacles) return;

            // Find Scenario Root
            // Every Map is structured by having an object like this, e.g. Scenario_Forest, Scenario_Cavern, etc.
            // This contains the map, obstacles, lighting, etc.
            GameObject mapRoot = UnityEngine.GameObject.FindObjectsOfType<GameObject>().Where(go => go.name.StartsWith("Scenario_") && go.transform.parent == null).First();

            if (mapRoot != null)
            {
                Plugin.Log.LogInfo("Found map hierarchy root object" + mapRoot.name);

                // Step 1: Find the 'Ground' BoxCollider to determine the map size
                var ground = FindChildByPredicate(mapRoot, node => node.layer == LayerMask.NameToLayer("Ground") && node.GetComponent<BoxCollider>());
                if (ground == null)
                {
                    Plugin.Log.LogError("Could not find ground collider");
                    return;
                }
                Plugin.Log.LogInfo("Found map ground object " + ground.name);

                var width = 10f;
                var innerBounds = ground.GetComponent<BoxCollider>().bounds;
                innerBounds.extents = new Vector3(innerBounds.extents.x - width, 100, innerBounds.extents.z - width);

                Plugin.Log.LogInfo("Inner Map Bounds: " + innerBounds.extents);

                // Iterate all child nodes, and delete all objects that contain a meshrenderer or collider, and is within the inner bounds
                // inner bounds is the mapsize reduced by some size to ensure the border of the map is not removed
                ProcessNodeHierarchy(mapRoot, node =>
                {
                    if (node.layer == LayerMask.NameToLayer("Ground") || node.name.Contains("Ground"))
                    {
                        return false;
                    } else
                    {
                        var renderer = node.GetComponent<MeshRenderer>();
                        var collider = node.GetComponent<Collider>();
                        var pos = node.transform.position;
                        pos.y = 0;
                        if ((renderer || collider) && innerBounds.Contains(pos))
                        {
                            Plugin.Log.LogInfo($"Delete Map Object {node.name} at {node.transform.position}");
                            GameObject.Destroy(node);
                            return false;
                        }
                    }
                    return true;
                });
            }
            else
            {
                Plugin.Log.LogError("Failed to clear map, could not find root object. Maybe a new map was added that uses a different format.");
            }
        }


        private static void ProcessNodeHierarchy(GameObject root, Func<GameObject, bool> nodeConsumer)
        {
            for (var i = 0; i < root.transform.childCount; i++)
            {
                GameObject child = root.transform.GetChild(i).gameObject;
                if (nodeConsumer.Invoke(child))
                {
                    ProcessNodeHierarchy(child, nodeConsumer);
                }
            }
        }

        private static GameObject FindChildByPredicate(GameObject root, Func<GameObject, bool> predicate)
        {
            for (var i = 0; i < root.transform.childCount; i++)
            {
                GameObject child = root.transform.GetChild(i).gameObject;
                if (predicate.Invoke(child))
                {
                    return child;
                } else
                {
                    GameObject result = FindChildByPredicate(child, predicate);
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            return null;
        }

    }
}
