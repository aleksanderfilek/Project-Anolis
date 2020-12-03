// GENERATED AUTOMATICALLY FROM 'Assets/Actions/EditorControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @EditorControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @EditorControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""EditorControls"",
    ""maps"": [
        {
            ""name"": ""PlanetaryMode"",
            ""id"": ""fee0cbba-fd1b-44a3-b8fe-d225fbeb0142"",
            ""actions"": [
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Value"",
                    ""id"": ""b208584b-2241-4eeb-a124-49175d20dd68"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Zoom"",
                    ""type"": ""Value"",
                    ""id"": ""aae8273e-af8a-4927-80ba-1ea987827d1b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WSAD"",
                    ""id"": ""a745ff3b-b7f1-4868-b17b-30f133251af7"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""bbf9700b-8398-4dce-a340-4409844d6c9e"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""21752f18-688e-4a33-96d1-993a0b866771"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""5a9ddcc1-1483-42ce-88a2-ddd2cf2af305"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""ae94b3de-bae2-4c0f-a5c3-81e84cfa606f"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrows"",
                    ""id"": ""73184929-cb56-481b-b118-e284d5bf6ab1"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""9fc8c949-80f7-401e-a95b-3e4f06b40e23"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""ed87441e-dd19-476f-814b-54c649e3eb8e"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""75f555f0-d866-4fc1-aeeb-cce88f1dee4f"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""3de2019b-85b9-45c3-aa5a-467e3b36c6bc"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""01ef413f-07d1-4719-8851-c86b1a23cc3f"",
                    ""path"": ""<Mouse>/scroll"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Zoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""InterplanetaryMode"",
            ""id"": ""618f3dbd-803e-4154-a4dd-ad003596cb91"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""fa866e2e-4c2c-4717-bcbd-62a1d7e75336"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Zoom"",
                    ""type"": ""Value"",
                    ""id"": ""49022bc6-e3bd-4520-86a3-aae41a07f333"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""FocusPlanet"",
                    ""type"": ""Button"",
                    ""id"": ""502aa6fd-107a-41c7-8cf5-21ca472ae970"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""MultiTap""
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WSAD"",
                    ""id"": ""6117200c-8ff1-4f58-bc88-09d41337ec55"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""ee47b86d-a37e-4021-8ac6-ecb2cc539fc0"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""49c3f8bf-7767-4c17-b823-b0bf51b1166b"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""49b34103-ed43-4563-a6f5-458815f5f2d4"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""1f881d90-dbf8-46d3-a07d-cd880d7f9a4b"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrows"",
                    ""id"": ""f149e956-daac-4086-b27f-68446bde84f9"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""583a98f4-a5ee-454b-9496-e31547dfca71"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""21cd4d8e-71dc-4fb0-8014-ebf54289cd8b"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""ed33fafd-0f7b-4a5e-bbed-62ece3b06b18"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""6a91cd9b-a5d3-42e9-b435-3facebeaa84e"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""947b7088-7b05-4bfb-aa98-9dde14895133"",
                    ""path"": ""<Mouse>/scroll"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Zoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ac1f7aae-17f3-42ef-a6d4-9ab29ae51bc0"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FocusPlanet"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Utilities"",
            ""id"": ""c9a21217-697a-451d-98c6-fcb77f173758"",
            ""actions"": [
                {
                    ""name"": ""CastRay"",
                    ""type"": ""Value"",
                    ""id"": ""9ffcd75b-8ba0-4553-a04b-906b1602c2c9"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""3438385b-688e-4124-8ba9-c5cea9d28bd6"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CastRay"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlanetaryMode
        m_PlanetaryMode = asset.FindActionMap("PlanetaryMode", throwIfNotFound: true);
        m_PlanetaryMode_Rotate = m_PlanetaryMode.FindAction("Rotate", throwIfNotFound: true);
        m_PlanetaryMode_Zoom = m_PlanetaryMode.FindAction("Zoom", throwIfNotFound: true);
        // InterplanetaryMode
        m_InterplanetaryMode = asset.FindActionMap("InterplanetaryMode", throwIfNotFound: true);
        m_InterplanetaryMode_Move = m_InterplanetaryMode.FindAction("Move", throwIfNotFound: true);
        m_InterplanetaryMode_Zoom = m_InterplanetaryMode.FindAction("Zoom", throwIfNotFound: true);
        m_InterplanetaryMode_FocusPlanet = m_InterplanetaryMode.FindAction("FocusPlanet", throwIfNotFound: true);
        // Utilities
        m_Utilities = asset.FindActionMap("Utilities", throwIfNotFound: true);
        m_Utilities_CastRay = m_Utilities.FindAction("CastRay", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // PlanetaryMode
    private readonly InputActionMap m_PlanetaryMode;
    private IPlanetaryModeActions m_PlanetaryModeActionsCallbackInterface;
    private readonly InputAction m_PlanetaryMode_Rotate;
    private readonly InputAction m_PlanetaryMode_Zoom;
    public struct PlanetaryModeActions
    {
        private @EditorControls m_Wrapper;
        public PlanetaryModeActions(@EditorControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Rotate => m_Wrapper.m_PlanetaryMode_Rotate;
        public InputAction @Zoom => m_Wrapper.m_PlanetaryMode_Zoom;
        public InputActionMap Get() { return m_Wrapper.m_PlanetaryMode; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlanetaryModeActions set) { return set.Get(); }
        public void SetCallbacks(IPlanetaryModeActions instance)
        {
            if (m_Wrapper.m_PlanetaryModeActionsCallbackInterface != null)
            {
                @Rotate.started -= m_Wrapper.m_PlanetaryModeActionsCallbackInterface.OnRotate;
                @Rotate.performed -= m_Wrapper.m_PlanetaryModeActionsCallbackInterface.OnRotate;
                @Rotate.canceled -= m_Wrapper.m_PlanetaryModeActionsCallbackInterface.OnRotate;
                @Zoom.started -= m_Wrapper.m_PlanetaryModeActionsCallbackInterface.OnZoom;
                @Zoom.performed -= m_Wrapper.m_PlanetaryModeActionsCallbackInterface.OnZoom;
                @Zoom.canceled -= m_Wrapper.m_PlanetaryModeActionsCallbackInterface.OnZoom;
            }
            m_Wrapper.m_PlanetaryModeActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Rotate.started += instance.OnRotate;
                @Rotate.performed += instance.OnRotate;
                @Rotate.canceled += instance.OnRotate;
                @Zoom.started += instance.OnZoom;
                @Zoom.performed += instance.OnZoom;
                @Zoom.canceled += instance.OnZoom;
            }
        }
    }
    public PlanetaryModeActions @PlanetaryMode => new PlanetaryModeActions(this);

    // InterplanetaryMode
    private readonly InputActionMap m_InterplanetaryMode;
    private IInterplanetaryModeActions m_InterplanetaryModeActionsCallbackInterface;
    private readonly InputAction m_InterplanetaryMode_Move;
    private readonly InputAction m_InterplanetaryMode_Zoom;
    private readonly InputAction m_InterplanetaryMode_FocusPlanet;
    public struct InterplanetaryModeActions
    {
        private @EditorControls m_Wrapper;
        public InterplanetaryModeActions(@EditorControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_InterplanetaryMode_Move;
        public InputAction @Zoom => m_Wrapper.m_InterplanetaryMode_Zoom;
        public InputAction @FocusPlanet => m_Wrapper.m_InterplanetaryMode_FocusPlanet;
        public InputActionMap Get() { return m_Wrapper.m_InterplanetaryMode; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InterplanetaryModeActions set) { return set.Get(); }
        public void SetCallbacks(IInterplanetaryModeActions instance)
        {
            if (m_Wrapper.m_InterplanetaryModeActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_InterplanetaryModeActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_InterplanetaryModeActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_InterplanetaryModeActionsCallbackInterface.OnMove;
                @Zoom.started -= m_Wrapper.m_InterplanetaryModeActionsCallbackInterface.OnZoom;
                @Zoom.performed -= m_Wrapper.m_InterplanetaryModeActionsCallbackInterface.OnZoom;
                @Zoom.canceled -= m_Wrapper.m_InterplanetaryModeActionsCallbackInterface.OnZoom;
                @FocusPlanet.started -= m_Wrapper.m_InterplanetaryModeActionsCallbackInterface.OnFocusPlanet;
                @FocusPlanet.performed -= m_Wrapper.m_InterplanetaryModeActionsCallbackInterface.OnFocusPlanet;
                @FocusPlanet.canceled -= m_Wrapper.m_InterplanetaryModeActionsCallbackInterface.OnFocusPlanet;
            }
            m_Wrapper.m_InterplanetaryModeActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Zoom.started += instance.OnZoom;
                @Zoom.performed += instance.OnZoom;
                @Zoom.canceled += instance.OnZoom;
                @FocusPlanet.started += instance.OnFocusPlanet;
                @FocusPlanet.performed += instance.OnFocusPlanet;
                @FocusPlanet.canceled += instance.OnFocusPlanet;
            }
        }
    }
    public InterplanetaryModeActions @InterplanetaryMode => new InterplanetaryModeActions(this);

    // Utilities
    private readonly InputActionMap m_Utilities;
    private IUtilitiesActions m_UtilitiesActionsCallbackInterface;
    private readonly InputAction m_Utilities_CastRay;
    public struct UtilitiesActions
    {
        private @EditorControls m_Wrapper;
        public UtilitiesActions(@EditorControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @CastRay => m_Wrapper.m_Utilities_CastRay;
        public InputActionMap Get() { return m_Wrapper.m_Utilities; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UtilitiesActions set) { return set.Get(); }
        public void SetCallbacks(IUtilitiesActions instance)
        {
            if (m_Wrapper.m_UtilitiesActionsCallbackInterface != null)
            {
                @CastRay.started -= m_Wrapper.m_UtilitiesActionsCallbackInterface.OnCastRay;
                @CastRay.performed -= m_Wrapper.m_UtilitiesActionsCallbackInterface.OnCastRay;
                @CastRay.canceled -= m_Wrapper.m_UtilitiesActionsCallbackInterface.OnCastRay;
            }
            m_Wrapper.m_UtilitiesActionsCallbackInterface = instance;
            if (instance != null)
            {
                @CastRay.started += instance.OnCastRay;
                @CastRay.performed += instance.OnCastRay;
                @CastRay.canceled += instance.OnCastRay;
            }
        }
    }
    public UtilitiesActions @Utilities => new UtilitiesActions(this);
    public interface IPlanetaryModeActions
    {
        void OnRotate(InputAction.CallbackContext context);
        void OnZoom(InputAction.CallbackContext context);
    }
    public interface IInterplanetaryModeActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnZoom(InputAction.CallbackContext context);
        void OnFocusPlanet(InputAction.CallbackContext context);
    }
    public interface IUtilitiesActions
    {
        void OnCastRay(InputAction.CallbackContext context);
    }
}
