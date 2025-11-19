using System.Collections.Generic;
using UnityEngine;

public class PatrolPointsBehaviour : IBehaviour
{
    private List<Transform> _patrolPoints;
    private Mover _mover;

    public PatrolPointsBehaviour(Mover mover, List<Transform> patrolPoints)
    {
        _patrolPoints = patrolPoints;
        _mover = mover;
    }

    public void Enter()
    {
        //generate first patrol point
    }

    public void Exit()
    {
        //reset patrol point list
    }

    public void Update()
    {
        //foreach patrol point _mover.ProcessMoveTo(direction, speed);
    }
}
