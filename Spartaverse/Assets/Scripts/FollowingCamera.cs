using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;      // 따라갈 대상 (예: 플레이어)
    public Vector3 offset;        // 카메라와 대상 사이의 거리 (원하면 설정)
    public float smoothSpeed = 5f; // 부드럽게 따라오는 속도

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
