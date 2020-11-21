using System;
using UnityEngine;

//todo think about if this is needed, maybe better idea would be to init everything separately in corresponding objects
public class Init : MonoBehaviour
{
    private void Start()
    {
        GameState.Get.ChangeModeToInterplanetary();
    }
}