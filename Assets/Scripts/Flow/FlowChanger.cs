using UnityEngine;

public class FlowChanger : MonoBehaviour
{
    public EFlowState TargetFlowState;

    public void UpdateFlowState()
    {
        FlowManager.Get().FlowState = TargetFlowState;
    }
}
