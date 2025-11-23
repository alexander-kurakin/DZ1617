using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private List<Transform> _targets;
    [SerializeField] private Transform _centralPoint;

    [SerializeField] private BehaviourType _idleType;
    [SerializeField] private BehaviourType _reactionType;

    private void Awake()
    {
        Enemy enemy = Instantiate(_enemyPrefab, transform.position, Quaternion.identity);

        IBehaviour idleBehaviour = CreateBehaviour(_idleType, enemy);
        IBehaviour reactionBehaviour = CreateBehaviour(_reactionType, enemy);

        enemy.Initialize(idleBehaviour, reactionBehaviour);
    }

    private IBehaviour CreateBehaviour(BehaviourType behaviourType, Enemy enemy)
    {
        switch (behaviourType)
        { 
            case BehaviourType.PatrolPointsBehaviour:
                return new PatrolPointsBehaviour(enemy.GetComponent<Mover>(), _targets);

            case BehaviourType.StandingStillBehaviour:
                return new StandingStillBehaviour();

            case BehaviourType.ChaoticMovementBehaviour:
                return new ChaoticMovementBehaviour(enemy.GetComponent<Mover>(), _centralPoint);

            case BehaviourType.RunawayBehaviour:
                return new RunawayBehaviour(enemy, enemy.GetComponent<Mover>());

            case BehaviourType.ChasingBehaviour:
                return new ChasingBehaviour(enemy, enemy.GetComponent<Mover>());

            case BehaviourType.InstantDeathBehaviour:
                return new InstantDeathBehaviour(enemy);

            default:
                return null;
        }
    }
}
