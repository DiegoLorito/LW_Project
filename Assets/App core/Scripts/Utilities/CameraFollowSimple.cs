using UnityEngine;

public class CameraFollowSimple : MonoBehaviour
{
    [SerializeField] private Transform _target; 

    private void Update()
    {
        Vector3 targetPosition = new Vector3(_target.position.x, _target.position.y, transform.position.z);

        transform.position = targetPosition;
    }
}
