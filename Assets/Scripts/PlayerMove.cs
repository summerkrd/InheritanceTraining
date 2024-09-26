using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 1f;
    
    private CharacterController _characterController;
    private Vector3 _moveDirection = Vector3.zero;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        _moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        //_moveDirection = transform.TransformDirection(_moveDirection);
        //_moveDirection *= _moveSpeed;

        _characterController.Move(_moveDirection * _moveSpeed * Time.deltaTime);
    }
}
