using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Utilities
{
        #if UNITY_EDITOR
        public class CommandLine : MonoBehaviour
        {
            private bool _visible = false;

            private GameObject _commandLine;
            private InputField _commandField;
            
            private readonly Dictionary<string, Func<string[], bool>> _commands = new Dictionary<string, Func<string[], bool>>();

            private void Start()
            {
                _commandLine = transform.GetChild(0).gameObject;
                _commandLine.SetActive(false);

                _commandField = _commandLine.GetComponent<InputField>();
                
                _commands.Add("slomo", Slomo);
                
                
            }

            private void Update()
            {
                if (Input.GetKeyDown(KeyCode.F1))
                {
                    _visible = !_visible;
                    _commandLine.SetActive(_visible);

                    _commandField.text = "";
                    
                    if(_visible == true) _commandField.ActivateInputField();
                    else _commandField.DeactivateInputField();
                }

                if (_visible == true)
                {
                    if (Input.GetKeyDown(KeyCode.Return))
                    {
                        ProcessCommand();
                    }
                }
            }

            private void ProcessCommand()
            {
                var text = _commandField.text.ToLower();
                var args = text.Split(' ').Select(str => str.Trim()).ToArray();

                if (_commands.ContainsKey(args[0]))
                {
                    var result = _commands[args[0]].Invoke(args);
                    if (result == false)
                        Debug.Log("Debugger error: " + text);
                }

                _commandField.text = "";
                _commandField.ActivateInputField();
            }

            private bool Slomo(string[] args)
            {
                if (args.Length < 2)
                    return false;

                var scale = float.Parse(args[1], System.Globalization.CultureInfo.InvariantCulture);
                Time.timeScale = scale;
                
                return true;
            }
        }
        #endif
}
