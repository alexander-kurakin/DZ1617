using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunawayBehaviour : IBehaviour
{
    private const float Speed = 1f;

    private Mover _mover;
    private Transform _runawayTarget;
    private Vector3 _currentTarget;
    

    public RunawayBehaviour(Transform runawayTarget, Mover mover)
    {
        _mover = mover;
        _runawayTarget = runawayTarget;
    }
    public void Enter()
    {
        _currentTarget = _runawayTarget.position;
    }

    public void Exit()
    {
        _currentTarget = Vector3.zero;
    }

    public void Update()
    {
        _currentTarget = _runawayTarget.position;

        Vector3 direction = new Vector3(_mover.transform.position.x - _currentTarget.x, 0, _mover.transform.position.z - _currentTarget.z);

        _mover.ProcessTranslatedMoveTo(direction, Speed);
    }
}
