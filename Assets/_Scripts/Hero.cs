using UnityEngine;

public class Hero : MonoBehaviour
{
    private const string RunningAnimParam = "isRunning";
    private const string HorizontalAxisName = "Horizontal";
    private const string VerticalAxisName = "Vertical";

    [SerializeField] private Animator _animator;

    [SerializeField] private float _speed;
    [SerializeField] private float _rotateSpeed;

    private SmoothRotator _smoothRotator = new SmoothRotator();
    private Mover _mover;

    private float _deadZone = 0.1f;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
    }

    private void Update()
    {
        Vector3 input = new Vector3(Input.GetAxisRaw(HorizontalAxisName), 0, Input.GetAxisRaw(VerticalAxisName));
        Vector3 normalizedInput = input.normalized;

        if (input.magnitude <= _deadZone)
        {
            _animator.SetBool(RunningAnimParam, false);
            return;
        }

        _animator.SetBool(RunningAnimParam, true);
        _mover.ProcessMoveTo(normalizedInput, _speed);
        _smoothRotator.ProcessRotateTo(transform, _rotateSpeed, normalizedInput);
    }
}
