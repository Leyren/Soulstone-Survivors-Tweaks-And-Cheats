using ECM2.Characters;
using HarmonyLib;
using Il2CppSystem.Collections.Generic;
using SoulstoneCheats.Core.Config;
using SoulstoneCheats.Modifications;
using SoulstoneCheats.Patches;
using SoulstoneCheats.Util;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

namespace SoulstoneCheats.Unity
{
    /// <summary>
    /// Unity Component to be injected. Follows a singleton pattern to ensure lifetime throughout the game.
    /// </summary>
    public class PluginUnityComponent : MonoBehaviour
    {
        public static PluginUnityComponent Instance {get; private set;}

        public void Awake()
        {
            DontDestroyOnLoad(this);
            Instance = this;
        }

        public void Start()
        {
            ApplyGlobalPatches();

        }


        public void Update()
        {
            
        }

        /// <summary>
        /// Applies patches that work on globally present constant data, e.g. Curse modifiers
        /// </summary>
        private void ApplyGlobalPatches()
        {
            CurseModification.ModifyCurseBonuses();
            CurseModification.ModifyCurseLevelStrength();
            SkillTreeCostModification.ModifySkillTreeCosts();
        }
    }
}
