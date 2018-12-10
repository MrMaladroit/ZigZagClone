using UnityEngine;

public class CameraFollowController : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    private Transform cameraPosition;
    private Vector3 offset = new Vector3(2, 3, -2);

    private void Update()
    {
        if(PlayerMovementController.IsFalling == false)
        {
            gameObject.transform.position = target.transform.position + offset;                    
        }
    }

}