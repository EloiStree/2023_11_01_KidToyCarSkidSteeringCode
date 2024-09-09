using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputExostCarMono : MonoBehaviour
{
    public InputActionReference m_topLeftMotor;
    public InputActionReference m_topRightMotor;
    public InputActionReference m_bottomLeftMotor;
    public InputActionReference m_bottomRightMotor;
    public UnityEvent<bool> m_topLeftMotorEvent;
    public UnityEvent<bool> m_topRightMotorEvent;
    public UnityEvent<bool> m_bottomLeftMotorEvent;
    public UnityEvent<bool> m_bottomRightMotorEvent;

    public bool m_debugTopLeft;
    public bool m_debugTopRight;
    public bool m_debugBottomLeft;
    public bool m_debugBottomRight;

    void OnEnable()
    {
        m_topLeftMotor.action.Enable();
        m_topRightMotor.action.Enable();
        m_bottomLeftMotor.action.Enable();
        m_bottomRightMotor.action.Enable();

        m_topLeftMotor.action.performed += OnTopLeftMotorPerformed;
        m_topRightMotor.action.performed += OnTopRightMotorPerformed;
        m_bottomLeftMotor.action.performed += OnBottomLeftMotorPerformed;
        m_bottomRightMotor.action.performed += OnBottomRightMotorPerformed;

        m_topLeftMotor.action.canceled += OnTopLeftMotorPerformed;
        m_topRightMotor.action.canceled += OnTopRightMotorPerformed;
        m_bottomLeftMotor.action.canceled += OnBottomLeftMotorPerformed;
        m_bottomRightMotor.action.canceled += OnBottomRightMotorPerformed;

    }

    void OnDisable()
    {
        m_topLeftMotor.action.Disable();
        m_topRightMotor.action.Disable();
        m_bottomLeftMotor.action.Disable();
        m_bottomRightMotor.action.Disable();

        m_topLeftMotor.action.performed -= OnTopLeftMotorPerformed;
        m_topRightMotor.action.performed -= OnTopRightMotorPerformed;
        m_bottomLeftMotor.action.performed -= OnBottomLeftMotorPerformed;
        m_bottomRightMotor.action.performed -= OnBottomRightMotorPerformed;

        m_topLeftMotor.action.canceled -= OnTopLeftMotorPerformed;
        m_topRightMotor.action.canceled -= OnTopRightMotorPerformed;
        m_bottomLeftMotor.action.canceled -= OnBottomLeftMotorPerformed;
        m_bottomRightMotor.action.canceled -= OnBottomRightMotorPerformed;

    }

    private void OnTopLeftMotorPerformed(InputAction.CallbackContext context)
    {
        m_topLeftMotorEvent.Invoke(context.ReadValue<float>() > 0.5f);

        m_debugTopLeft = context.ReadValue<float>() > 0.5f;
    }

    private void OnTopRightMotorPerformed(InputAction.CallbackContext context)
    {
        m_topRightMotorEvent.Invoke(context.ReadValue<float>() > 0.5f);
        m_debugTopRight = context.ReadValue<float>() > 0.5f;
    }

    private void OnBottomLeftMotorPerformed(InputAction.CallbackContext context)
    {
        m_bottomLeftMotorEvent.Invoke(context.ReadValue<float>() > 0.5f);
        m_debugBottomLeft = context.ReadValue<float>() > 0.5f;
    }

    private void OnBottomRightMotorPerformed(InputAction.CallbackContext context)
    {
        m_bottomRightMotorEvent.Invoke(context.ReadValue<float>() > 0.5f);
        m_debugBottomRight = context.ReadValue<float>() > 0.5f;
    }
}
