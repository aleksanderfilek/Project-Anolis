using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class PlayMenuManager : MonoBehaviour
    {
        public void Play_Click()
        {
            SceneManager.LoadScene(1);
        }
    }    
}

