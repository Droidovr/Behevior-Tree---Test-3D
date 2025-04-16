using BehaviorDesigner.Runtime;
using UnityEngine;

public class WaveAttackBot : MonoBehaviour
{
    [SerializeField] private ExternalBehaviorTree _behaviorTreeAsset;
    [SerializeField] private GameObject _target;
    
    
    private void Start()
    {
        var behavior = gameObject.AddComponent<BehaviorTree>();
        behavior.ExternalBehavior = _behaviorTreeAsset;
        
        // Здесь установить в глобальную переменную Target = _target
        SharedGameObject sharedTarget = new SharedGameObject();
        sharedTarget.Value = _target;
        GlobalVariables.Instance.SetVariable("Target", sharedTarget);
        
        behavior.EnableBehavior();
    }
}
