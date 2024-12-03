using UnityEngine;

public class CameraWay : MonoBehaviour
{
    public Transform playerTransform; // Трансформ игрока
    public Vector3 offset = new Vector3(0f, 0f, -10f); // Смещение камеры (Z=-10 в 2D)

    private void LateUpdate()
    {
        // камеру в позицию игрока с учётом смещения
        transform.position = new Vector3(
            playerTransform.position.x + offset.x,
            playerTransform.position.y + offset.y,
            offset.z
        );
    }
}
