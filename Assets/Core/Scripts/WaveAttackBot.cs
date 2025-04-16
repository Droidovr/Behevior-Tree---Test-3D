using System.Collections;
using BehaviorDesigner.Runtime;
using UnityEngine;

public class WaveAttackBot : MonoBehaviour
{
    [SerializeField] private ExternalBehaviorTree _behaviorTreeAsset;
    [SerializeField] private float _waveInterval;
    [SerializeField] private float _waveDuration;
    [SerializeField] private float _fieldOfWievAngleCanSee;
    [SerializeField] private float _wievDistanceCanSee;
    [SerializeField] private GameObject _idlePoint;
    [SerializeField] private GameObject _heroTarget;

    private BehaviorTree _behavior;
    
    
    private IEnumerator  Start()
    {
        _behavior = gameObject.AddComponent<BehaviorTree>();
        _behavior.ExternalBehavior = _behaviorTreeAsset;
        _behavior.StartWhenEnabled = false;
        
        yield return null;
        
        _behavior.SetVariable("WaveInterval", (SharedFloat)_waveInterval);
        _behavior.SetVariable("WaveDuration", (SharedFloat)_waveDuration);
        _behavior.SetVariable("FieldOfWievAngleCanSee", (SharedFloat)_fieldOfWievAngleCanSee);
        _behavior.SetVariable("WievDistanceCanSee", (SharedFloat)_wievDistanceCanSee);
        _behavior.SetVariable("IdlePoint", (SharedGameObject)_idlePoint);
        _behavior.SetVariable("HeroTarget", (SharedGameObject)_heroTarget);
        
        yield return new WaitForEndOfFrame();
        
        _behavior.EnableBehavior();
    }
}
