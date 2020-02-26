// GENERATED AUTOMATICALLY FROM 'Assets/Input/InputMaster.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputMaster : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputMaster()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputMaster"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""a50bde3e-c85d-4388-9327-aa7cf24303f6"",
            ""actions"": [
                {
                    ""name"": ""Attack Press"",
                    ""type"": ""Button"",
                    ""id"": ""29988889-b8a0-497c-a273-165ae56fec3e"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Attack Release"",
                    ""type"": ""Button"",
                    ""id"": ""50430aab-f46b-40c9-899f-9d42ca51a2ab"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""Charge Press"",
                    ""type"": ""Button"",
                    ""id"": ""100c7618-0dc5-436f-ac2a-c6d9eb76caf6"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Charge Release"",
                    ""type"": ""Button"",
                    ""id"": ""113076ac-cf21-4a61-9f03-42cecf67da75"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""db59a542-c06d-445e-b530-13e55b0a7ecc"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Keyboard Horizontal"",
                    ""type"": ""Button"",
                    ""id"": ""6d29a051-ab62-410d-88e4-1bf2858cb60d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""Keyboard Vertical"",
                    ""type"": ""Button"",
                    ""id"": ""6be06206-5c82-4cf7-9886-98afc88abfd0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""dcb02d7b-5521-4a6b-aec1-883146f0cb23"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Attack Press"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1f5a32e1-e278-4126-92b5-c474781f7481"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Attack Press"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e621675e-9078-43ac-a810-1cd92bd47448"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Attack Release"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c792c774-ba47-4823-8e33-29929775cc55"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Attack Release"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""840519d5-c0ea-4288-97f4-68e58fe489f1"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Charge Press"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7ed12672-06cf-4a69-a0a3-6b257894ab74"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Charge Press"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f35a28e4-14b0-4a36-bb45-24cd5651875c"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Charge Release"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c3aba1db-a0ce-424b-9033-a128ad7a765d"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Charge Release"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bfc3cbe1-a4af-459c-b146-d36b89b8191e"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""AD"",
                    ""id"": ""634ed13b-9cf5-4f8e-9e3d-9cd8c20dde96"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Keyboard Horizontal"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""ff846dc2-5f82-4c8a-883e-135f232cae2f"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Keyboard Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""8fc581ec-d9e7-4016-94a2-0e4f76d9b7bc"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Keyboard Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""WS"",
                    ""id"": ""f70eee4c-b850-4e62-a0da-85161d9ddf6a"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Keyboard Vertical"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""ecc84651-865c-4791-94a1-5135c8d21040"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Keyboard Vertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""e4a302c5-ec1c-4c27-827c-6ae96670d19e"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Keyboard Vertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_AttackPress = m_Player.FindAction("Attack Press", throwIfNotFound: true);
        m_Player_AttackRelease = m_Player.FindAction("Attack Release", throwIfNotFound: true);
        m_Player_ChargePress = m_Player.FindAction("Charge Press", throwIfNotFound: true);
        m_Player_ChargeRelease = m_Player.FindAction("Charge Release", throwIfNotFound: true);
        m_Player_Movement = m_Player.FindAction("Movement", throwIfNotFound: true);
        m_Player_KeyboardHorizontal = m_Player.FindAction("Keyboard Horizontal", throwIfNotFound: true);
        m_Player_KeyboardVertical = m_Player.FindAction("Keyboard Vertical", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_AttackPress;
    private readonly InputAction m_Player_AttackRelease;
    private readonly InputAction m_Player_ChargePress;
    private readonly InputAction m_Player_ChargeRelease;
    private readonly InputAction m_Player_Movement;
    private readonly InputAction m_Player_KeyboardHorizontal;
    private readonly InputAction m_Player_KeyboardVertical;
    public struct PlayerActions
    {
        private @InputMaster m_Wrapper;
        public PlayerActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @AttackPress => m_Wrapper.m_Player_AttackPress;
        public InputAction @AttackRelease => m_Wrapper.m_Player_AttackRelease;
        public InputAction @ChargePress => m_Wrapper.m_Player_ChargePress;
        public InputAction @ChargeRelease => m_Wrapper.m_Player_ChargeRelease;
        public InputAction @Movement => m_Wrapper.m_Player_Movement;
        public InputAction @KeyboardHorizontal => m_Wrapper.m_Player_KeyboardHorizontal;
        public InputAction @KeyboardVertical => m_Wrapper.m_Player_KeyboardVertical;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @AttackPress.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttackPress;
                @AttackPress.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttackPress;
                @AttackPress.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttackPress;
                @AttackRelease.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttackRelease;
                @AttackRelease.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttackRelease;
                @AttackRelease.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttackRelease;
                @ChargePress.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnChargePress;
                @ChargePress.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnChargePress;
                @ChargePress.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnChargePress;
                @ChargeRelease.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnChargeRelease;
                @ChargeRelease.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnChargeRelease;
                @ChargeRelease.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnChargeRelease;
                @Movement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @KeyboardHorizontal.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnKeyboardHorizontal;
                @KeyboardHorizontal.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnKeyboardHorizontal;
                @KeyboardHorizontal.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnKeyboardHorizontal;
                @KeyboardVertical.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnKeyboardVertical;
                @KeyboardVertical.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnKeyboardVertical;
                @KeyboardVertical.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnKeyboardVertical;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @AttackPress.started += instance.OnAttackPress;
                @AttackPress.performed += instance.OnAttackPress;
                @AttackPress.canceled += instance.OnAttackPress;
                @AttackRelease.started += instance.OnAttackRelease;
                @AttackRelease.performed += instance.OnAttackRelease;
                @AttackRelease.canceled += instance.OnAttackRelease;
                @ChargePress.started += instance.OnChargePress;
                @ChargePress.performed += instance.OnChargePress;
                @ChargePress.canceled += instance.OnChargePress;
                @ChargeRelease.started += instance.OnChargeRelease;
                @ChargeRelease.performed += instance.OnChargeRelease;
                @ChargeRelease.canceled += instance.OnChargeRelease;
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @KeyboardHorizontal.started += instance.OnKeyboardHorizontal;
                @KeyboardHorizontal.performed += instance.OnKeyboardHorizontal;
                @KeyboardHorizontal.canceled += instance.OnKeyboardHorizontal;
                @KeyboardVertical.started += instance.OnKeyboardVertical;
                @KeyboardVertical.performed += instance.OnKeyboardVertical;
                @KeyboardVertical.canceled += instance.OnKeyboardVertical;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnAttackPress(InputAction.CallbackContext context);
        void OnAttackRelease(InputAction.CallbackContext context);
        void OnChargePress(InputAction.CallbackContext context);
        void OnChargeRelease(InputAction.CallbackContext context);
        void OnMovement(InputAction.CallbackContext context);
        void OnKeyboardHorizontal(InputAction.CallbackContext context);
        void OnKeyboardVertical(InputAction.CallbackContext context);
    }
}
