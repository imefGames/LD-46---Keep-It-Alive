using UnityEngine;
using UnityEngine.Events;

public class FlowChangeHandler : MonoBehaviour
{
    public EFlowState WatchedFlowState;
    public UnityEvent StateReachedEvent;

    void Start()
    {
        FlowManager.Get().FlowStateChanged.AddListener(OnFlowStateChanged);
    }

    void OnFlowStateChanged(EFlowState flowState)
    {
        if (flowState == WatchedFlowState)
        {
            StateReachedEvent.Invoke();
        }
    }
}
