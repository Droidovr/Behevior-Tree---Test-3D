/*using UnityEngine;
using UnityEngine.AI;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("Custom/NavMesh")]
[TaskDescription("Moves the agent toward a target using NavMeshAgent.SetDestination")]
public class MoveNavMesh : Action
{
    [BehaviorDesigner.Runtime.Tasks.Tooltip("The target to move toward")]
    public SharedGameObject target;

    [BehaviorDesigner.Runtime.Tasks.Tooltip("Optional stopping distance override")]
    public SharedFloat stoppingDistance = 0.5f;

    private NavMeshAgent agent;

    public override void OnStart()
    {
        agent = GetComponent<NavMeshAgent>();

        if (agent != null)
        {
            agent.stoppingDistance = stoppingDistance.Value;
            if (target.Value != null)
            {
                agent.SetDestination(target.Value.transform.position);
            }
        }
    }

    public override TaskStatus OnUpdate()
    {
        if (agent == null)
        {
            Debug.LogWarning("MoveNavMesh: NavMeshAgent is null");
            return TaskStatus.Failure;
        }

        if (target.Value == null)
        {
            Debug.LogWarning("MoveNavMesh: Target is null");
            return TaskStatus.Failure;
        }

        if (agent.pathPending)
        {
            return TaskStatus.Running;
        }

        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            return TaskStatus.Success;
        }

        return TaskStatus.Running;
    }

    public override void OnReset()
    {
        target = null;
        stoppingDistance = 0.5f;
    }
}*/