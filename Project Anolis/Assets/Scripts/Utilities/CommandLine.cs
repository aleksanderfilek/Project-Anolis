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
            
            private Dictionary<string, Action> _commands;

            private string[] _cmd;
            private void Start()
            {
                _commandLine = transform.GetChild(0).gameObject;
                _commandLine.SetActive(false);

                _commandField = _commandLine.GetComponent<InputField>();
                
                _commandField.onEndEdit.AddListener(delegate { ProcessCommand();  });

                _commands["slomo"] = new Action(Slomo);
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
            }

            private void ProcessCommand()
            {
                _cmd = _commandField.text.ToLower().Split(',').Select(str => str.Trim()).ToArray();

                var cmd = _cmd[0];
                _commands[cmd]();
                
                _commandField.text = "";
                _commandField.ActivateInputField();
            }

            private static void Slomo()
            {
                //tutaj zwalniamy czas
            }
        }
        #endif
}
