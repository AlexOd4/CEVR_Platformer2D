using UnityEngine;

public class MenuInputHandler : MonoBehaviour
{
    private InputSystem_Actions input;
    private InputSystem_Actions.UIActions action;

    

    #region PUBLIC GET VARS

    #endregion

    #region SET UP INPUT HANDLER
    private void Awake()
    {
        input = new();
        action = input.UI;
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

}