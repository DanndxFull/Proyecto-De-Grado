//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Inputs/PushObjecstAsset.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PushObjecstAsset : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PushObjecstAsset()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PushObjecstAsset"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""b100940a-e970-4727-8155-93d11d671dca"",
            ""actions"": [
                {
                    ""name"": ""PushLeft"",
                    ""type"": ""Button"",
                    ""id"": ""579d8e57-58dd-4408-a226-52b844fd31c0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""PushRight"",
                    ""type"": ""Button"",
                    ""id"": ""c60fc12e-e2c2-43b0-9bd0-f4d3adc7d19d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b274dbe8-7cd6-40b7-b65c-668b7e2462ad"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PushLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""73068cf2-dff7-4db9-a1a7-5295e97da590"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PushRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_PushLeft = m_Player.FindAction("PushLeft", throwIfNotFound: true);
        m_Player_PushRight = m_Player.FindAction("PushRight", throwIfNotFound: true);
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
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_PushLeft;
    private readonly InputAction m_Player_PushRight;
    public struct PlayerActions
    {
        private @PushObjecstAsset m_Wrapper;
        public PlayerActions(@PushObjecstAsset wrapper) { m_Wrapper = wrapper; }
        public InputAction @PushLeft => m_Wrapper.m_Player_PushLeft;
        public InputAction @PushRight => m_Wrapper.m_Player_PushRight;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @PushLeft.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPushLeft;
                @PushLeft.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPushLeft;
                @PushLeft.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPushLeft;
                @PushRight.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPushRight;
                @PushRight.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPushRight;
                @PushRight.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPushRight;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @PushLeft.started += instance.OnPushLeft;
                @PushLeft.performed += instance.OnPushLeft;
                @PushLeft.canceled += instance.OnPushLeft;
                @PushRight.started += instance.OnPushRight;
                @PushRight.performed += instance.OnPushRight;
                @PushRight.canceled += instance.OnPushRight;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnPushLeft(InputAction.CallbackContext context);
        void OnPushRight(InputAction.CallbackContext context);
    }
}
