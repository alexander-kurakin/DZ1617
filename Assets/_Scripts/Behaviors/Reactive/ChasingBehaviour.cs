using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingBehaviour : IBehaviour
{
    private Mover _mover;
    private Enemy _enemy;
    private Hero _hero;
    private Vector3 _currentTarget;

    private float _speed = 1f;
    public ChasingBehaviour(Enemy enemy, Mover mover) 
    {
        _mover = mover;
        _enemy = enemy;
    }

    public void Enter()
    {
        _hero = _enemy.GetCollidedHero();
        _currentTarget = _hero.transform.position;
    }

    public void Exit()
    {
        _currentTarget = Vector3.zero;
    }

    public void Update()
    {
        _currentTarget = _hero.transform.position;
        _mover.ProcessTranslatedMoveTo(_currentTarget - _mover.transform.position, _speed);
    }
}
