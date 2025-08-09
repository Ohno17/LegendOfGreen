using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] private float sensitivity = 3;
    [SerializeField] private Vector2 frameOffset = new(0, 1);
    [SerializeField] private Transform target;
    [SerializeField] private float followDistance = 5;
    [SerializeField] private LayerMask cameraAvoidMask;

    private float rotationX;
    private float rotationY;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        rotationX += -Input.GetAxis("Mouse Y") * sensitivity;
        rotationY += Input.GetAxis("Mouse X") * sensitivity;

        rotationX = Mathf.Clamp(rotationX, -89, 89);

        Quaternion targetRotation = Quaternion.Euler(rotationX, rotationY, 0);
        Vector3 focusPosition = target.position + new Vector3(frameOffset.x, frameOffset.y);

        float resultDistance = followDistance;

        if (Physics.Raycast(target.position, targetRotation * Vector3.back, out RaycastHit info, followDistance, cameraAvoidMask, QueryTriggerInteraction.Ignore))
        {
            resultDistance = info.distance;
        }

        Vector3 offsetVector = focusPosition - targetRotation * new Vector3(0, 0, resultDistance);
        
        transform.SetPositionAndRotation(offsetVector, targetRotation);
    }
}
