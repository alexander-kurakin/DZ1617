using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private CharacterController _characterController;

    public void ProcessMoveTo(Vector3 direction, float speed)
    {
        _characterController.Move(direction * speed * Time.deltaTime);
    }
}
