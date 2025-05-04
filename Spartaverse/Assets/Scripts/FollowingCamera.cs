using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;      // ���� ��� (��: �÷��̾�)
    public Vector3 offset;        // ī�޶�� ��� ������ �Ÿ� (���ϸ� ����)
    public float smoothSpeed = 5f; // �ε巴�� ������� �ӵ�

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
            transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z);
        }
    }
}
