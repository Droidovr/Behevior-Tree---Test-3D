using UnityEngine;

public class CameraFreeflight : MonoBehaviour 
{
    public float speedNormal = 10.0f;
    public float speedFast   = 50.0f;
    public float jumpForce = 5.0f;  // Сила прыжка
    public float mouseSensitivityX = 5.0f;
    public float mouseSensitivityY = 5.0f;

    private float rotY = 0.0f;  // Угол вращения по оси Y

    private Rigidbody rb;  // Ссылка на Rigidbody, чтобы управлять физикой
    private bool isGrounded;  // Флаг для проверки, находимся ли мы на земле

    void Start()
    {
        rb = GetComponent<Rigidbody>();  // Получаем ссылку на Rigidbody
    }

    void Update()
    {
        // Проверка на землю с помощью Raycast
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f);

        // Поворот камеры с помощью мыши (влево/вправ и вверх/вниз)
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivityX;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivityY;

        rotY -= mouseY;  // Обновляем угол по оси Y
        rotY = Mathf.Clamp(rotY, -89.5f, 89.5f);  // Ограничиваем угол наклона камеры по оси X

        // Поворот камеры по оси X (поворот вверх/вниз)
        transform.localRotation = Quaternion.Euler(rotY, 0.0f, 0.0f); 

        // Поворот тела игрока по оси Y (поворот влево/вправ)
        transform.Rotate(Vector3.up * mouseX);  // Поворот относительно оси Y

        // Движение камеры
        float forward = Input.GetAxis("Vertical");
        float strafe  = Input.GetAxis("Horizontal");

        float speed = Input.GetKey(KeyCode.LeftShift) ? speedFast : speedNormal;

        // Движение вперёд/назад
        if (forward != 0.0f)  
        {
            Vector3 trans = new Vector3(0.0f, 0.0f, forward * speed * Time.deltaTime);
            transform.localPosition += transform.TransformDirection(trans);  // Движение относительно ориентации камеры
        }

        // Движение влево/вправ
        if (strafe != 0.0f) 
        {
            Vector3 trans = new Vector3(strafe * speed * Time.deltaTime, 0.0f, 0.0f);
            transform.localPosition += transform.TransformDirection(trans);  // Движение относительно ориентации камеры
        }

        // Прыжок
        if (Input.GetKeyDown(KeyCode.Space))// && isGrounded)  // Проверка нажатия пробела и нахождение на земле
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);  // Устанавливаем скорость для прыжка
        }
    }
}