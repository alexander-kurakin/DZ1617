using UnityEngine;

public class SmoothRotator
{
    public void ProcessRotateTo(Transform objectToRotate, float rotateSpeed, Vector3 direction)
    {
        if (direction == Vector3.zero)
            return;

        Quaternion lookRotation = Quaternion.LookRotation(direction);
        float step = rotateSpeed * Time.deltaTime;
        objectToRotate.rotation = Quaternion.RotateTowards(objectToRotate.rotation, lookRotation, step);
    }
}
