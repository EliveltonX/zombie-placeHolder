// GENERATED AUTOMATICALLY FROM 'Assets/ControllsSystem/GameControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @GameControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @GameControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameControls"",
    ""maps"": [
        {
            ""name"": ""Game"",
            ""id"": ""c383eb8a-9327-4d77-b3fe-6f97efafadc0"",
            ""actions"": [
                {
                    ""name"": ""Walk"",
                    ""type"": ""Value"",
                    ""id"": ""8bd5f220-c5ea-4123-8297-b8c38ce1c2a4"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interaction"",
                    ""type"": ""Button"",
                    ""id"": ""4df205da-c056-482e-91ea-f67f72018a85"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Atack"",
                    ""type"": ""Button"",
                    ""id"": ""a58279f2-52a3-4e23-a2ba-7307083da161"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Inventory"",
                    ""type"": ""Button"",
                    ""id"": ""82bd2524-b09f-48ca-8b42-b9485b7c94ab"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""5f9d3c03-f0b7-4639-bc19-94ccdc43c7cd"",
                    ""path"": ""<XInputController>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interaction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""880aa9da-089f-454f-b05e-7e352ac399f9"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""010406ff-6beb-48c0-ba18-0a869e777bce"",
                    ""path"": ""<XInputController>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""03048d0f-74b9-4368-95c8-2d941e29ea72"",
                    ""path"": ""<XInputController>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""213d355b-149f-494a-81fe-71ffbf0815f7"",
                    ""path"": ""<XInputController>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""349f2611-16e7-48a5-9960-1395d37a47e4"",
                    ""path"": ""<XInputController>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""cbd2a539-ffc8-4c16-b8c7-c13a9a0c598d"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Atack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9c6e802d-a26c-41c6-95af-148b465fa2d0"",
                    ""path"": ""<XInputController>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Inventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Game
        m_Game = asset.FindActionMap("Game", throwIfNotFound: true);
        m_Game_Walk = m_Game.FindAction("Walk", throwIfNotFound: true);
        m_Game_Interaction = m_Game.FindAction("Interaction", throwIfNotFound: true);
        m_Game_Atack = m_Game.FindAction("Atack", throwIfNotFound: true);
        m_Game_Inventory = m_Game.FindAction("Inventory", throwIfNotFound: true);
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

    // Game
    private readonly InputActionMap m_Game;
    private IGameActions m_GameActionsCallbackInterface;
    private readonly InputAction m_Game_Walk;
    private readonly InputAction m_Game_Interaction;
    private readonly InputAction m_Game_Atack;
    private readonly InputAction m_Game_Inventory;
    public struct GameActions
    {
        private @GameControls m_Wrapper;
        public GameActions(@GameControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Walk => m_Wrapper.m_Game_Walk;
        public InputAction @Interaction => m_Wrapper.m_Game_Interaction;
        public InputAction @Atack => m_Wrapper.m_Game_Atack;
        public InputAction @Inventory => m_Wrapper.m_Game_Inventory;
        public InputActionMap Get() { return m_Wrapper.m_Game; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameActions set) { return set.Get(); }
        public void SetCallbacks(IGameActions instance)
        {
            if (m_Wrapper.m_GameActionsCallbackInterface != null)
            {
                @Walk.started -= m_Wrapper.m_GameActionsCallbackInterface.OnWalk;
                @Walk.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnWalk;
                @Walk.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnWalk;
                @Interaction.started -= m_Wrapper.m_GameActionsCallbackInterface.OnInteraction;
                @Interaction.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnInteraction;
                @Interaction.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnInteraction;
                @Atack.started -= m_Wrapper.m_GameActionsCallbackInterface.OnAtack;
                @Atack.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnAtack;
                @Atack.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnAtack;
                @Inventory.started -= m_Wrapper.m_GameActionsCallbackInterface.OnInventory;
                @Inventory.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnInventory;
                @Inventory.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnInventory;
            }
            m_Wrapper.m_GameActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Walk.started += instance.OnWalk;
                @Walk.performed += instance.OnWalk;
                @Walk.canceled += instance.OnWalk;
                @Interaction.started += instance.OnInteraction;
                @Interaction.performed += instance.OnInteraction;
                @Interaction.canceled += instance.OnInteraction;
                @Atack.started += instance.OnAtack;
                @Atack.performed += instance.OnAtack;
                @Atack.canceled += instance.OnAtack;
                @Inventory.started += instance.OnInventory;
                @Inventory.performed += instance.OnInventory;
                @Inventory.canceled += instance.OnInventory;
            }
        }
    }
    public GameActions @Game => new GameActions(this);
    public interface IGameActions
    {
        void OnWalk(InputAction.CallbackContext context);
        void OnInteraction(InputAction.CallbackContext context);
        void OnAtack(InputAction.CallbackContext context);
        void OnInventory(InputAction.CallbackContext context);
    }
}
