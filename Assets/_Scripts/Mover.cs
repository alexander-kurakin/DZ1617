using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private CharacterController _characterController;

    public void ProcessCharacterMoveTo(Vector3 direction, float speed)
    {
        _characterController.Move(direction * speed * Time.deltaTime);
        Debug.DrawRay(transform.position, direction, Color.yellow);
    }

    public void ProcessTranslatedMoveTo(Vector3 direction, float speed)
    {
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
        Debug.DrawRay(transform.position, direction, Color.yellow);
    }

    public Transform GetMovingObjectTransform()
    {
        return transform;
    }
}
