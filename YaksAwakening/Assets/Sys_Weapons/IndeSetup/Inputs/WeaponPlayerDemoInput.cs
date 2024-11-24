//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.11.0
//     from Assets/Sys_Weapons/IndeSetup/WeaponPlayerDemoInput.inputactions
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

public partial class @WeaponPlayerDemoInput: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @WeaponPlayerDemoInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""WeaponPlayerDemoInput"",
    ""maps"": [
        {
            ""name"": ""Demo"",
            ""id"": ""356502ff-3539-4ac9-bb44-7b9124f89f4f"",
            ""actions"": [
                {
                    ""name"": ""UseLeft"",
                    ""type"": ""Button"",
                    ""id"": ""b5b65ec7-7eb2-44da-90a1-f49931ab4315"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""UseRight"",
                    ""type"": ""Button"",
                    ""id"": ""7c4f33c0-fe97-49e0-8520-6a87dc6fe2d6"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""da7fc831-8738-4394-8aae-681e4d75d831"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UseLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""71a9e8a9-a434-4c0a-b969-5fd9136a9524"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UseRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Demo
        m_Demo = asset.FindActionMap("Demo", throwIfNotFound: true);
        m_Demo_UseLeft = m_Demo.FindAction("UseLeft", throwIfNotFound: true);
        m_Demo_UseRight = m_Demo.FindAction("UseRight", throwIfNotFound: true);
    }

    ~@WeaponPlayerDemoInput()
    {
        UnityEngine.Debug.Assert(!m_Demo.enabled, "This will cause a leak and performance issues, WeaponPlayerDemoInput.Demo.Disable() has not been called.");
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

    // Demo
    private readonly InputActionMap m_Demo;
    private List<IDemoActions> m_DemoActionsCallbackInterfaces = new List<IDemoActions>();
    private readonly InputAction m_Demo_UseLeft;
    private readonly InputAction m_Demo_UseRight;
    public struct DemoActions
    {
        private @WeaponPlayerDemoInput m_Wrapper;
        public DemoActions(@WeaponPlayerDemoInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @UseLeft => m_Wrapper.m_Demo_UseLeft;
        public InputAction @UseRight => m_Wrapper.m_Demo_UseRight;
        public InputActionMap Get() { return m_Wrapper.m_Demo; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DemoActions set) { return set.Get(); }
        public void AddCallbacks(IDemoActions instance)
        {
            if (instance == null || m_Wrapper.m_DemoActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_DemoActionsCallbackInterfaces.Add(instance);
            @UseLeft.started += instance.OnUseLeft;
            @UseLeft.performed += instance.OnUseLeft;
            @UseLeft.canceled += instance.OnUseLeft;
            @UseRight.started += instance.OnUseRight;
            @UseRight.performed += instance.OnUseRight;
            @UseRight.canceled += instance.OnUseRight;
        }

        private void UnregisterCallbacks(IDemoActions instance)
        {
            @UseLeft.started -= instance.OnUseLeft;
            @UseLeft.performed -= instance.OnUseLeft;
            @UseLeft.canceled -= instance.OnUseLeft;
            @UseRight.started -= instance.OnUseRight;
            @UseRight.performed -= instance.OnUseRight;
            @UseRight.canceled -= instance.OnUseRight;
        }

        public void RemoveCallbacks(IDemoActions instance)
        {
            if (m_Wrapper.m_DemoActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IDemoActions instance)
        {
            foreach (var item in m_Wrapper.m_DemoActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_DemoActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public DemoActions @Demo => new DemoActions(this);
    public interface IDemoActions
    {
        void OnUseLeft(InputAction.CallbackContext context);
        void OnUseRight(InputAction.CallbackContext context);
    }
}