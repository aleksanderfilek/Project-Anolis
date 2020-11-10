using Interaction.Editor;
using UnityEngine;

public class BuildingOption : MonoBehaviour
{
    public Placeable Placeable { get; set; }
    private BuildMenu _managerMenu;

    public void AssignManager(BuildMenu menu)
    {
        _managerMenu = menu;
    }
    
    public void OnSelection()
    {
        _managerMenu.SetSelectionTo(_managerMenu.CurrentOption == this ? null : this);
    }
}
