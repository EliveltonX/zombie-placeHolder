// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Inputs/Controles.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controles : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controles()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controles"",
    ""maps"": [
        {
            ""name"": ""PlayerControles"",
            ""id"": ""df2540c7-02f3-4530-818a-f41958f42113"",
            ""actions"": [
                {
                    ""name"": ""MOVIMENTO"",
                    ""type"": ""PassThrough"",
                    ""id"": ""8f6ac9e5-a0cb-458d-94be-cc5f810c7e34"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""INTERACT"",
                    ""type"": ""Button"",
                    ""id"": ""14aa525b-bd1c-4b79-a2e5-23e78b04ec7a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ATACK"",
                    ""type"": ""Button"",
                    ""id"": ""7a008024-fccc-4a51-a848-39e33fa14a80"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""INVENTORY"",
                    ""type"": ""Button"",
                    ""id"": ""2df60697-c362-4e63-beaa-191ce93cdb70"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Vector2"",
                    ""id"": ""9a84cbe5-fc82-4074-b9ae-d73f16431ecf"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MOVIMENTO"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Up"",
                    ""id"": ""a820c7c0-c45a-4761-bea8-775fa4ea1fe0"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MOVIMENTO"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Down"",
                    ""id"": ""5fd5f4a8-cb0f-45c3-9954-0fe7ea6d3776"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MOVIMENTO"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Left"",
                    ""id"": ""be3e9d03-b630-4087-8001-3d43702e3895"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MOVIMENTO"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Right"",
                    ""id"": ""24dd3b4c-b4c3-4d90-8236-f64deccfdd57"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MOVIMENTO"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""0d938426-0ed9-4403-bc31-472dc4b5b23d"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""INTERACT"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""de27d7e3-7234-46c9-8cd7-a9a81a298db8"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ATACK"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b5fb0657-e83f-4a0b-8f2c-cadaee36518a"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""INVENTORY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerControles
        m_PlayerControles = asset.FindActionMap("PlayerControles", throwIfNotFound: true);
        m_PlayerControles_MOVIMENTO = m_PlayerControles.FindAction("MOVIMENTO", throwIfNotFound: true);
        m_PlayerControles_INTERACT = m_PlayerControles.FindAction("INTERACT", throwIfNotFound: true);
        m_PlayerControles_ATACK = m_PlayerControles.FindAction("ATACK", throwIfNotFound: true);
        m_PlayerControles_INVENTORY = m_PlayerControles.FindAction("INVENTORY", throwIfNotFound: true);
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

    // PlayerControles
    private readonly InputActionMap m_PlayerControles;
    private IPlayerControlesActions m_PlayerControlesActionsCallbackInterface;
    private readonly InputAction m_PlayerControles_MOVIMENTO;
    private readonly InputAction m_PlayerControles_INTERACT;
    private readonly InputAction m_PlayerControles_ATACK;
    private readonly InputAction m_PlayerControles_INVENTORY;
    public struct PlayerControlesActions
    {
        private @Controles m_Wrapper;
        public PlayerControlesActions(@Controles wrapper) { m_Wrapper = wrapper; }
        public InputAction @MOVIMENTO => m_Wrapper.m_PlayerControles_MOVIMENTO;
        public InputAction @INTERACT => m_Wrapper.m_PlayerControles_INTERACT;
        public InputAction @ATACK => m_Wrapper.m_PlayerControles_ATACK;
        public InputAction @INVENTORY => m_Wrapper.m_PlayerControles_INVENTORY;
        public InputActionMap Get() { return m_Wrapper.m_PlayerControles; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerControlesActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerControlesActions instance)
        {
            if (m_Wrapper.m_PlayerControlesActionsCallbackInterface != null)
            {
                @MOVIMENTO.started -= m_Wrapper.m_PlayerControlesActionsCallbackInterface.OnMOVIMENTO;
                @MOVIMENTO.performed -= m_Wrapper.m_PlayerControlesActionsCallbackInterface.OnMOVIMENTO;
                @MOVIMENTO.canceled -= m_Wrapper.m_PlayerControlesActionsCallbackInterface.OnMOVIMENTO;
                @INTERACT.started -= m_Wrapper.m_PlayerControlesActionsCallbackInterface.OnINTERACT;
                @INTERACT.performed -= m_Wrapper.m_PlayerControlesActionsCallbackInterface.OnINTERACT;
                @INTERACT.canceled -= m_Wrapper.m_PlayerControlesActionsCallbackInterface.OnINTERACT;
                @ATACK.started -= m_Wrapper.m_PlayerControlesActionsCallbackInterface.OnATACK;
                @ATACK.performed -= m_Wrapper.m_PlayerControlesActionsCallbackInterface.OnATACK;
                @ATACK.canceled -= m_Wrapper.m_PlayerControlesActionsCallbackInterface.OnATACK;
                @INVENTORY.started -= m_Wrapper.m_PlayerControlesActionsCallbackInterface.OnINVENTORY;
                @INVENTORY.performed -= m_Wrapper.m_PlayerControlesActionsCallbackInterface.OnINVENTORY;
                @INVENTORY.canceled -= m_Wrapper.m_PlayerControlesActionsCallbackInterface.OnINVENTORY;
            }
            m_Wrapper.m_PlayerControlesActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MOVIMENTO.started += instance.OnMOVIMENTO;
                @MOVIMENTO.performed += instance.OnMOVIMENTO;
                @MOVIMENTO.canceled += instance.OnMOVIMENTO;
                @INTERACT.started += instance.OnINTERACT;
                @INTERACT.performed += instance.OnINTERACT;
                @INTERACT.canceled += instance.OnINTERACT;
                @ATACK.started += instance.OnATACK;
                @ATACK.performed += instance.OnATACK;
                @ATACK.canceled += instance.OnATACK;
                @INVENTORY.started += instance.OnINVENTORY;
                @INVENTORY.performed += instance.OnINVENTORY;
                @INVENTORY.canceled += instance.OnINVENTORY;
            }
        }
    }
    public PlayerControlesActions @PlayerControles => new PlayerControlesActions(this);
    public interface IPlayerControlesActions
    {
        void OnMOVIMENTO(InputAction.CallbackContext context);
        void OnINTERACT(InputAction.CallbackContext context);
        void OnATACK(InputAction.CallbackContext context);
        void OnINVENTORY(InputAction.CallbackContext context);
    }
}
