using UnityEngine;

public class Enemy : MonoBehaviour
{
    private IBehaviour _idleBehaviour;
    private IBehaviour _reactionBehaviour;

    private IBehaviour _currentBehaviour;

    private bool _isInitialized = false;
    private Color _currentGizmosColor;
    private Hero _collidedHero;

    public void Initialize(IBehaviour idleBehaviour, IBehaviour reactionBehaviour)
    {
        _currentGizmosColor = new Color(1f, 0f, 0f, 0.25f);
        _idleBehaviour = idleBehaviour;
        _reactionBehaviour = reactionBehaviour;

        _currentBehaviour = _idleBehaviour;
        
        _currentBehaviour.Enter();
        _isInitialized = true;
    }

    private void Update()
    {
        if (_isInitialized) 
            _currentBehaviour.Update();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Hero>(out Hero hero))
        {
            _collidedHero = hero;
            SwitchBehaviour(_reactionBehaviour);
            _currentGizmosColor = new Color(0f, 1f, 0f, 0.25f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Hero>(out Hero hero))
        {
            _currentGizmosColor = new Color(1f, 0f, 0f, 0.25f);
            SwitchBehaviour(_idleBehaviour);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = _currentGizmosColor;
        Gizmos.DrawSphere(transform.position, 2.5f);
    }

    private void SwitchBehaviour(IBehaviour behaviour)
    { 
        _currentBehaviour.Exit();
        _currentBehaviour = behaviour;
        _currentBehaviour.Enter();
    }

    public void DestroyEnemy()
    {
        //play effect
        Destroy(gameObject);
    }

    public Hero GetCollidedHero()
    {
        return _collidedHero;
    }
}
