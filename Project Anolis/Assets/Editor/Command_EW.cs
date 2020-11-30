using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;
using Editor.CommandFuntions;
using UnityEngine.InputSystem;

namespace Editor
{
    public class Command_EW : EditorWindow
    {
        private static string _command;

        private static readonly Dictionary<string, Func<string[], bool>> _commands =
            new Dictionary<string, Func<string[], bool>>();


        [MenuItem("Window/Ex/CommandLine")]
        public static void Init()
        {
            var window = EditorWindow.GetWindow(typeof(Command_EW));
            window.titleContent = new GUIContent("Command line");
            window.Show();
        }

        private void OnGUI()
        {
            var e = Event.current;
            
            

            _command = EditorGUILayout.TextField("Cmd: ", _command);

            if (e.keyCode == KeyCode.Return)
                ProcessCommand();
        }

        private void OnFocus()
        {
            if (_commands.Count == 0)
                GetFunctions();
        }

        private static void GetFunctions()
        {
            _commands.Add("slomo", Slomo.Process);
            _commands.Add("turnui", TurnUI_CF.Process);
        }

        private static void ProcessCommand()
        {
            var text = _command.ToLower();
            var args = text.Split(' ').Select(str => str.Trim()).ToArray();

            if (_commands.ContainsKey(args[0]))
            {
                var result = _commands[args[0]].Invoke(args);

                if (result)
                    Debug.Log("CMD: " + text);
                else
                    Debug.Log("CMD Error: " + text);
            }

            _command = "";
        }
    }
}