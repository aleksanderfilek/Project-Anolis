using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Editor.CommandFuntions;
using UnityEngine.InputSystem;

namespace Editor
{
    public class Command_EW : EditorWindow
    {

        private string _command;
        private readonly Dictionary<string, Func<string[], bool>> _commands = new Dictionary<string, Func<string[], bool>>();


        [MenuItem("Window/Ex/CommandLine")]
        public static void ShowWindow()
        {
            EditorWindow.GetWindow(typeof(Command_EW));
        }

        private void OnGUI()
        {
            var e = Event.current;
            
            _command = EditorGUILayout.TextField("Cmd: ", _command);
            
            if(e.keyCode == KeyCode.Return)
                Debug.Log("OK");
        }

        private void GetFunctions()
        {
            _commands.Add("slomo", Slomo.Process);
        }
    }
}
