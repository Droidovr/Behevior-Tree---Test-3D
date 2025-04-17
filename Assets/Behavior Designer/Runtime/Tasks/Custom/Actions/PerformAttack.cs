using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class PerformAttack : Action
{
    [BehaviorDesigner.Runtime.Tasks.Tooltip("Time Of Attack")]
    public SharedFloat AttackDuration = 1.0f;

    [BehaviorDesigner.Runtime.Tasks.Tooltip("Target to attack")]
    public SharedGameObject AttackTarget;

    private float _attackStartTime;

    public override void OnStart()
    {
        _attackStartTime = Time.time;

        if (AttackTarget.Value != null)
        {
            Debug.Log($"Begin attack on: {AttackTarget.Value.name}");
        }
        else
        {
            Debug.LogWarning("No target set for PerformAttack.");
        }
    }

    public override TaskStatus OnUpdate()
    {
        if (Time.time - _attackStartTime >= AttackDuration.Value)
        {
            Debug.Log("Attack completed");

            // Здесь в будущем ты можешь вызывать:
            // attackTarget.Value.GetComponent<Health>()?.TakeDamage(damage);

            return TaskStatus.Success;
        }

        return TaskStatus.Running;
    }
}