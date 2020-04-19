using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EAnimalState
{
    Idle,
    MovingToActivity,
    DoingActivity
}

public class AnimalController : MonoBehaviour
{
    [SerializeField]
    private ActivitySpot[] AvailableActivities;

    public EAnimalState State = EAnimalState.Idle;

    private System.Random m_Random = new System.Random();
    private ActivitySpot m_CurrentActivity;
    private float m_ActivityRemainingTime;

    void Update()
    {
        switch (State)
        {
            case EAnimalState.Idle:
            {
                List<ActivitySpot> doableActivities = FindDoableActivities();
                if (doableActivities.Count > 0)
                {
                    m_CurrentActivity = doableActivities[m_Random.Next(0, doableActivities.Count)];
                    State = EAnimalState.MovingToActivity;

                    NavMeshAgent agent = GetComponent<NavMeshAgent>();
                    agent.destination = m_CurrentActivity.ActivityPosition.position;
                    m_ActivityRemainingTime = m_CurrentActivity.ActivityDuration;
                }
                break;
            }
            case EAnimalState.MovingToActivity:
            {
                NavMeshAgent agent = GetComponent<NavMeshAgent>();
                if (agent.remainingDistance == 0.0f)
                {
                    State = EAnimalState.DoingActivity;
                    m_CurrentActivity.StartActivity();
                }
                break;
            }
            case EAnimalState.DoingActivity:
            {
                m_ActivityRemainingTime -= Time.deltaTime;
                if (m_ActivityRemainingTime <= 0.0f)
                {
                    State = EAnimalState.Idle;
                    m_CurrentActivity.EndActivity();
                }
                break;
            }
        }
    }

    private List<ActivitySpot> FindDoableActivities()
    {
        List<ActivitySpot> doableActivities = new List<ActivitySpot>();
        foreach (ActivitySpot activity in AvailableActivities)
        {
            if (activity.IsActivityDoable)
            {
                doableActivities.Add(activity);
            }
        }
        return doableActivities;
    }
}
