using UnityEngine;

public class ChasingBehaviour : IBehaviour
{
    private const float Speed = 1f;

    private Mover _mover;
    private Transform _chaseTarget;
    private Vector3 _currentTarget;
    

    public ChasingBehaviour(Transform chaseTarget, Mover mover) 
    {
        _mover = mover;
        _chaseTarget = chaseTarget;
    }

    public void Enter()
    {
        _currentTarget = _chaseTarget.position;
    }

    public void Exit()
    {
        _currentTarget = Vector3.zero;
    }

    public void Update()
    {
        _currentTarget = _chaseTarget.position;

        Vector3 direction = new Vector3(_currentTarget.x - _mover.transform.position.x, 0, _currentTarget.z - _mover.transform.position.z);

        _mover.ProcessTranslatedMoveTo(direction, Speed);
    }
}
