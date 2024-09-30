using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 1f;

    private CharacterController _characterController;
    private Vector3 _moveDirection = Vector3.zero;
    private float _rotateSpeed = 5f;
    private float _lastNonZeroXDirection = 1f;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        _moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);

        _characterController.Move(_moveDirection * _moveSpeed * Time.deltaTime);

        if (_moveDirection.x != 0)
        {
            _lastNonZeroXDirection = Mathf.Sign(_moveDirection.x);
        }

        Rotate();

        Debug.Log(_moveDirection.x);
    }

    private void Rotate()
    {
        Vector3 eulerAngles = transform.localEulerAngles;
        Vector3 newEulerAngles;

        if (_moveDirection.x < -0.1f)
        {
            newEulerAngles = new Vector3(transform.rotation.x, 180f, transform.rotation.z);
        }
        else if (_moveDirection.x > 0.1f)
        {
            newEulerAngles = new Vector3(transform.rotation.x, 0f, transform.rotation.z);
        }
        else
        {
            newEulerAngles = new Vector3(transform.rotation.x, _lastNonZeroXDirection > 0 ? 0f : 180f, transform.rotation.z);
        }

        transform.localEulerAngles = Vector3.Lerp(eulerAngles, newEulerAngles, Time.deltaTime * _rotateSpeed);
    }
}
