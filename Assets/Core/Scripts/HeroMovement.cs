using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SimplePlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float rotationSpeed = 700f; // Скорость вращения

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // Направление движения
        Vector3 moveDir = new Vector3(h, 0f, v).normalized;

        // Применение скорости движения
        Vector3 velocity = moveDir * moveSpeed;
        _rigidbody.linearVelocity = new Vector3(velocity.x, _rigidbody.linearVelocity.y, velocity.z);

        // Поворот персонажа в сторону движения
        if (moveDir.magnitude > 0.1f) // Если есть движение
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDir);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    private void Jump()
    {
        // Прыжок по нажатию клавиши пробела
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}