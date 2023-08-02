using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;

[Serializable]
public class MovementManager
{
    private PlayerInputActions playerInputActions;
    //private UIDocument document;
    private GameObject _player;
    private Rigidbody _rb;
    private Transform _groundCheck;
    [SerializeField] private LayerMask _platform;
    [SerializeField] private float mouseSense = 0.5f;
    [SerializeField] private float jumpForce = 10;

    // Construtor
    public MovementManager(GameObject player)
    {
        _player = player;
        _rb = _player.GetComponent<Rigidbody>();
        _groundCheck = GameObject.FindGameObjectWithTag("GroundCheck").transform;
        _platform = new LayerMask();

        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Jump.performed += Jump;
    }
    
    // Movementação do personagem
    public void Movement(float speed)
    {   
        if(IsGrounded())
        {
            Vector2 movementVector = playerInputActions.Player.Movement.ReadValue<Vector2>();
            Vector3 forceDirection = new Vector3(movementVector.x, 0, movementVector.y);
            _rb.AddForce(_player.transform.TransformDirection(forceDirection) * speed);
        }
    }
    
    // Rotação do personagem com a câmera
    public void Rotation()
    {
        Vector2 camVector = playerInputActions.Player.Mouse.ReadValue<Vector2>();
        _player.transform.Rotate(new Vector3(0, camVector.x, 0) * mouseSense);
    }

    // Salto
    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded())
            _rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    // Verifica se tá no chão
    private bool IsGrounded()
    {
        return Physics.CheckSphere(_groundCheck.position, .1f, _platform);
    }
}
