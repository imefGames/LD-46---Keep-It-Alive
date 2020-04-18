using UnityEngine;

public class FlowEntityEnabler : MonoBehaviour
{
    public EFlowState[] EnabledFlowStates;
    void Start()
    {
        FlowManager.Get().FlowStateChanged.AddListener(OnFlowStateChanged);
    }

    void OnFlowStateChanged(EFlowState flowState)
    {
        bool isEnabled = false;
        foreach (EFlowState allowedState in EnabledFlowStates)
        {
            if (allowedState == flowState)
            {
                isEnabled = true;
                break;
            }
        }

        gameObject.SetActive(isEnabled);
    }
}
