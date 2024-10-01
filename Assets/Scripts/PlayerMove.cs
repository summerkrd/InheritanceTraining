using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 1f;

    private CharacterController _characterController;
    private Vector3 _moveDirection = Vector3.zero;
    private float _rotateSpeed = 5f;
    private float _lastNonZeroXDirection = 1f;

    public float MoveSpeed
    {
        get { return _moveSpeed; }
        set { _moveSpeed = value; }
    }

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Start()
    {
        Debug.Log($"Скорость игрока {_moveSpeed}");
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
    }

    private void Rotate()
    {
        Vector3 eulerAngles = transform.localEulerAngles;
        Vector3 newEulerAngles;
        
        newEulerAngles = new Vector3(transform.rotation.x, _lastNonZeroXDirection > 0 ? 0f : 180f, transform.rotation.z);

        transform.localEulerAngles = Vector3.Lerp(eulerAngles, newEulerAngles, Time.deltaTime * _rotateSpeed);
    }
}
