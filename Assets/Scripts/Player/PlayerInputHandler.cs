using UnityEditor.UI;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    private InputSystem_Actions input;
    private InputSystem_Actions.PlayerActions action;

    #region PRIVATE VARS
    
    private Vector2 _direction;
    private Vector2 _lookAt;
    private bool _jump;
    private bool _sprint;
    #endregion

    #region PUBLIC GET VARS
    public Vector2 Direction { get { return _direction; } }
    public Vector2 LookAt { get { return _lookAt; } }
    public bool JumpMode { get { return _jump; } }
    public bool Sprint { get { return _sprint; } }
    #endregion

    #region SET UP INPUT HANDLER
    private void Awake()
    {
        input = new();
        action = input.Player;
    }

    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
    }
    #endregion 

    private void Update()
    {
        if (Gamepad.current != null && Gamepad.current.wasUpdatedThisFrame)
        {
            InputSystem.DisableDevice(Mouse.current);
            if (action.Look.ReadValue<Vector2>() != Vector2.zero)
            _lookAt = action.Look.ReadValue<Vector2>();
            else _lookAt = Vector2.up;
        }
        else if ((Mouse.current != null && Mouse.current.wasUpdatedThisFrame) || 
            (Touchscreen.current != null && Touchscreen.current.wasUpdatedThisFrame))
        {
            InputSystem.EnableDevice(Mouse.current);
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(action.Look.ReadValue<Vector2>());
            Vector2 playerPosition = this.gameObject.transform.position;
            _lookAt = (mousePosition - playerPosition).normalized;

        }
        else
        {
            _lookAt = Vector2.zero;
            Debug.Log("ERROR INESPERADO NO USA NI TECLADO NI RATON");
        }
        _jump = action.Jump.IsPressed();
        
        if (!_jump ) _direction = action.Move.ReadValue<Vector2>();
        else _direction = Vector2.zero;

        _sprint = action.Sprint.IsPressed();


        
    }
}
