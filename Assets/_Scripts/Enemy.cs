using UnityEngine;

public class Enemy : MonoBehaviour
{
    private IBehaviour _idleBehaviour;
    private IBehaviour _reactionBehaviour;

    private IBehaviour _currentBehaviour;

    public void Initialize(IBehaviour idleBehaviour, IBehaviour reactionBehaviour)
    {
        _idleBehaviour = idleBehaviour;
        _reactionBehaviour = reactionBehaviour;

        _currentBehaviour = _idleBehaviour;
    }

    private void Update()
    {
        _currentBehaviour.Update();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Hero>(out Hero hero))
            SwitchBehaviour(_reactionBehaviour);
        else
            SwitchBehaviour(_idleBehaviour);
    }

    private void SwitchBehaviour(IBehaviour behaviour)
    { 
        _currentBehaviour.Exit();
        _currentBehaviour = behaviour;
        _currentBehaviour.Enter();
    }
}
