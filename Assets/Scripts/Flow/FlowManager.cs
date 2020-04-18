using UnityEngine;
using UnityEngine.Events;

public enum EFlowState
{
    StartupMenu,
    InGame,
    EndGame
}

[System.Serializable]
public class FlowStateChangedEvent : UnityEvent<EFlowState>
{
}

public class FlowManager : MonoBehaviour
{
    private static FlowManager ms_Instance;

    private EFlowState m_FlowState = EFlowState.StartupMenu;

    public EFlowState FlowState
    {
        get { return m_FlowState; }
        set { 
            m_FlowState = value;
            FlowStateChanged.Invoke(m_FlowState);
        }
    }

    public FlowStateChangedEvent FlowStateChanged;


    public static FlowManager Get()
    {
        return ms_Instance;
    }

    void Awake()
    {
        ms_Instance = this;

        FlowStateChanged = new FlowStateChangedEvent();
        FlowStateChanged.AddListener(OnFlowStateChanged);

        FlowState = EFlowState.StartupMenu;
    }

    void Start()
    {
        FlowState = EFlowState.StartupMenu;
    }

    void OnFlowStateChanged(EFlowState flowState)
    {
        if (flowState == EFlowState.EndGame)
        {
            Application.Quit();
        }
    }
}
