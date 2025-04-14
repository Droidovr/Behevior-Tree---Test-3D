using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    public Transform player;  // Ссылка на трансформ игрока
    public float mouseSensitivityX = 5.0f;  // Чувствительность мыши по оси X (поворот влево/вправ)
    public float mouseSensitivityY = 5.0f;  // Чувствительность мыши по оси Y (поворот вверх/вниз)
    public float height = 1.5f;  // Высота камеры относительно игрока
    public float distanceFromPlayer = 0.5f;  // Расстояние камеры от игрока

    private float rotX = 0.0f;  // Угол поворота по оси X (вертикальное вращение)
    private float rotY = 0.0f;  // Угол поворота по оси Y (горизонтальное вращение)

    private void Start()
    {
        // Блокировка мыши в центре экрана
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        // Получение движения мыши
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivityX;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivityY;

        // Вертикальное вращение (вверх/вниз)
        rotY -= mouseY;
        rotY = Mathf.Clamp(rotY, -89.5f, 89.5f);  // Ограничиваем вращение по оси Y (не даём камере сильно наклоняться вверх/вниз)

        // Горизонтальное вращение (влево/вправ)
        rotX += mouseX;

        // Применяем повороты к камере
        transform.localRotation = Quaternion.Euler(rotY, rotX, 0.0f);

        // Камера будет находиться немного выше, чтобы видеть игрока
        Vector3 desiredPosition = player.position + Vector3.up * height - transform.forward * distanceFromPlayer;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * 10f);
    }
}