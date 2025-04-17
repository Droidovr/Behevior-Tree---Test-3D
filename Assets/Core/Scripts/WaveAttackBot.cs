using BehaviorDesigner.Runtime;
using UnityEngine;

public class WaveAttackBot : MonoBehaviour
{
    [SerializeField] private ExternalBehaviorTree _behaviorTreeAsset;
    [SerializeField] private GameObject _heroTarget;
    [SerializeField] private float _attackRange;
    [SerializeField] private float _attackWindup;
    [SerializeField] private float _attackCooldown;
    [SerializeField] private float _attackDuration;
    [SerializeField] private float _fieldOfViewAngle;
    [SerializeField] private float _viewDistance;
    [SerializeField] private float _speedMoving;
    [SerializeField] private float _seekArriveDistance;


    private BehaviorTree _behavior;
    
    
    private void Awake()
    {
        _behavior = gameObject.AddComponent<BehaviorTree>();
        _behavior.ExternalBehavior = _behaviorTreeAsset;
        _behavior.StartWhenEnabled = false;
        
        _behavior.SetVariable("HeroTarget", (SharedGameObject)_heroTarget);
        _behavior.SetVariable("AttackRange", (SharedFloat)_attackRange);
        _behavior.SetVariable("AttackWindup", (SharedFloat)_attackWindup);
        _behavior.SetVariable("AttackCooldown", (SharedFloat)_attackCooldown);
        _behavior.SetVariable("AttackDuration", (SharedFloat)_attackDuration);
        _behavior.SetVariable("FieldOfViewAngle", (SharedFloat)_fieldOfViewAngle);
        _behavior.SetVariable("ViewDistance", (SharedFloat)_viewDistance);
        _behavior.SetVariable("SpeedMoving", (SharedFloat)_speedMoving);
        _behavior.SetVariable("SeekArriveDistance", (SharedFloat)_seekArriveDistance);
        
        _behavior.EnableBehavior();
    }
}