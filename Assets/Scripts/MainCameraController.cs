using UnityEngine;

public class MainCameraController : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;

    private void Update()
    {
        Vector3 cameraPosition = transform.position;
        if (_playerTransform.position.y > cameraPosition.y)
            transform.position = new Vector3(cameraPosition.x, _playerTransform.position.y, cameraPosition.z);
    }
}