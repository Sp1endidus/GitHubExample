using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class InputPlayer : InputBase
{
    public CannonsManager CannonsManager;

    MainInput mainInput;

    void Start()
    {
        mainInput = new MainInput();
        mainInput.Player.Movement.performed += SetMoveDirection;
        mainInput.Player.Attack.performed += Attack;
        mainInput.Player.SwitchWeaponForward.performed += SwitchWeaponForward;
        mainInput.Player.SwitchWeaponBackward.performed += SwitchWeaponBackward;
        mainInput.Enable();
    }
    void SetMoveDirection(CallbackContext context)
    {
        Direction = context.ReadValue<Vector2>();
    }

    void Attack(CallbackContext context)
    {
        CannonsManager.PerformShoot();
    }

    void SwitchWeaponForward(CallbackContext context)
    {
        CannonsManager.SwitchCannon(true);
    }

    void SwitchWeaponBackward(CallbackContext context)
    {
        CannonsManager.SwitchCannon(false);
    }

    void OnDestroy()
    {
        mainInput.Player.Movement.performed -= SetMoveDirection;
        mainInput.Player.Attack.performed -= Attack;
        mainInput.Player.SwitchWeaponForward.performed -= SwitchWeaponForward;
        mainInput.Player.SwitchWeaponBackward.performed -= SwitchWeaponBackward;
    }
}
