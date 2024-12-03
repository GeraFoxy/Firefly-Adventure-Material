using UnityEngine;

public class CameraWay : MonoBehaviour
{
    public Transform playerTransform; // ��������� ������
    public Vector3 offset = new Vector3(0f, 0f, -10f); // �������� ������ (Z=-10 � 2D)

    private void LateUpdate()
    {
        // ������ � ������� ������ � ������ ��������
        transform.position = new Vector3(
            playerTransform.position.x + offset.x,
            playerTransform.position.y + offset.y,
            offset.z
        );
    }
}
