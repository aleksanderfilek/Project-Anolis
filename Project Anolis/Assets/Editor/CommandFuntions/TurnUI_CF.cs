using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Editor.CommandFuntions
{
    public class TurnUI_CF
    {
        public static bool Process(string[] args)
        {
            if (Application.isPlaying == false)
                return false;

            var canvasGroups = Object.FindObjectsOfType<CanvasGroup>();
            foreach (var cg in canvasGroups)
            {
                cg.alpha = ((int)cg.alpha == 1) ? 0 : 1;
                cg.interactable = !cg.interactable;
            }
            
            return true;
        }
    }
}
