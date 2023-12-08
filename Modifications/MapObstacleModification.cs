using SoulstoneCheats.Core.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.AI.Navigation;
using UnityEngine;

namespace SoulstoneCheats.Modifications
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

            GameObject mapRoot = UnityEngine.GameObject.FindObjectsOfType<GameObject>().Where(go => go.name.StartsWith("Scenario_") && go.transform.parent == null).First();
            if (mapRoot != null)
            {
                Plugin.Log.LogInfo("Found map root " + mapRoot.name);
                HashSet<string> whitelist = new() {
                    "Navegation_Colliders", "Desert_", // Desert map
                    "Bones", "Dragon_Bones", "Rubbles", "Wall_Rocks", "Stalagmite", // Cavern map
                    "New_Colliders_PolyShape"
                };
                HashSet<string> blacklist = new() {
                    "Desert_Hills", // Desert map, outer border
                    "Wall" // Cavern map outer wall
                };
                DeleteChildrenRecursively(mapRoot, whitelist, blacklist);
                /*
                var navmeshes = GameObject.FindObjectsOfType<NavMeshSurface>();
                foreach (var navmesh in navmeshes)
                {
                    Plugin.Log.LogInfo($"{navmesh.name} update NavMesh");
                    Action<AsyncOperation> value = a => Plugin.Log.LogInfo("Done " + a);
                    navmesh.UpdateNavMesh(navmesh.m_NavMeshData).add_completed(value);
                }*/

            }
            else
            {
                Plugin.Log.LogError("Failed to clear map, could not find root object. Maybe a new map was added that uses a different format.");
            }
        }

        private static void DeleteChildrenRecursively(GameObject root, HashSet<string> whitelistPrefixes, HashSet<string> blacklistPrefixes)
        {
            for (var i = 0; i < root.transform.childCount; i++)
            {
                Transform child = root.transform.GetChild(i);
                if (MatchesPrefix(child.name, whitelistPrefixes) && !blacklistPrefixes.Contains(child.name))
                {
                    Plugin.Log.LogInfo("Deleting Object " + child.name);
                    UnityEngine.GameObject.Destroy(child.gameObject);
                }
                else
                {
                    DeleteChildrenRecursively(child.gameObject, whitelistPrefixes, blacklistPrefixes);
                }
            }
        }

        private static bool MatchesPrefix(string name, HashSet<string> prefixes)
        {
            return prefixes.Any(p => name.StartsWith(p, true, null));
        }

    }
}
