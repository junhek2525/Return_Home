
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;       // 추격할 대상
    public float smoothSpeed = 5f; // 카메라 이동 속도
    public Vector3 offset;         // 카메라 위치 오프셋

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 targetPosition = target.position + offset;

        Vector3 smoothPosition = Vector3.Lerp(
            transform.position,
            targetPosition,
            smoothSpeed * Time.deltaTime
        );

        transform.position = smoothPosition;
    }
}
