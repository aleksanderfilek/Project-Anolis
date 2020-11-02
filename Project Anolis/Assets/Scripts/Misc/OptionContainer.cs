using System.Collections;
using System.Collections.Generic;
using Interaction.Editor;
using UnityEngine;

public class OptionContainer : MonoBehaviour
{
    public Placeable option;
    private BuildMenu _managerMenu;

    public void AssignManager(BuildMenu menu)
    {
        _managerMenu = menu;
    }
    
    public void OnSelection()
    {
        Debug.Log(option.description);
        _managerMenu.CurrentSelection = option;
    }
}
