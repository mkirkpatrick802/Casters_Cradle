using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float _moveSpeed;

    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        SceneLoader.SetPlayerPosition += SetPlayerPosition;
    }

    private void OnDisable()
    {
        SceneLoader.SetPlayerPosition -= SetPlayerPosition;
    }

    private void SetPlayerPosition(Vector3 obj)
    {
        transform.position = obj;
    }

    public void PlayerMovement(Vector2 dir)
    {
        Vector2 _currentVelocity = _rb.velocity;
        Vector2 _targetVelocity = _moveSpeed * Time.deltaTime * dir.normalized;
        Vector2 _velocityChange = _targetVelocity - _currentVelocity;
        _rb.AddForce(Vector2.ClampMagnitude(_velocityChange, _moveSpeed), ForceMode2D.Impulse);
    }
}
