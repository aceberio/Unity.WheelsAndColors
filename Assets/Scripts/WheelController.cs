using UnityEngine;

public class WheelController : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 100f;

    private void Update() => transform.Rotate(new Vector3(0, 0, _rotationSpeed * Time.deltaTime));
}