using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Utilities
{
    public class AlphaButton : MonoBehaviour
    {
        void Start()
        {
            GetComponent<Image>().alphaHitTestMinimumThreshold = 0.1f;
        }
    }
}
