using UnityEngine;

public class CameraFollowController : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    private Transform cameraPosition;
    private Vector3 offset = new Vector3(2, 3, -2);

    private void Update()
    {
        gameObject.transform.position = target.transform.position + offset;
    }

}