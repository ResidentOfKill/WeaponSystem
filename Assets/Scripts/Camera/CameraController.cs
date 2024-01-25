using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float _xTurnSpeed;
    [SerializeField] private float _yTurnSpeed;
    [SerializeField] private float _minX, _maxX;

    [SerializeField, Header("References")] private Transform _player;

    private float _xRotation, _yRotation;

    private Vector2 _viewRotationInput;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void FixedUpdate()
    {
        Rotation();
    }

    public void OnROTATE(InputAction.CallbackContext context)
    {
        _viewRotationInput = context.ReadValue<Vector2>();
    }

    private void Rotation()
    {
        float mouseX = _viewRotationInput.x * Time.deltaTime * _xTurnSpeed;
        float mouseY = _viewRotationInput.y * Time.deltaTime * _yTurnSpeed;

        _yRotation += mouseX;
        _xRotation -= mouseY;

        _xRotation = Mathf.Clamp(_xRotation, _minX, _maxX);

        transform.rotation = Quaternion.Euler(_xRotation, _yRotation, 0);
        _player.rotation = Quaternion.Euler(0, _yRotation, 0);
    }
}
