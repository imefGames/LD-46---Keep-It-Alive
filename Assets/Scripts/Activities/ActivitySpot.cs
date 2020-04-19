using Unity.Collections;
using UnityEngine;
using UnityEngine.Events;

public class ActivitySpot : MonoBehaviour
{
    public Transform ActivityPosition;
    public Transform LookPosition;
    public float ActivityDuration;
    public bool IsActivityDoable;
    public bool DisableActivityOnEnd;
    public UnityEvent ActivityStarted;
    public UnityEvent ActivityFinished;
    public UnityEvent ActivityDoable;
    public EStat RefilledStat = EStat.None;
    public float StatRefillRate = 0.0f;
    public string AnimationProperty;

    public void MakeActivityDoable()
    {
        if (IsActivityDoable == false)
        {
            IsActivityDoable = true;
            if (ActivityDoable != null)
            {
                ActivityDoable.Invoke();
            }
        }
    }

    public void StartActivity()
    {
        if (ActivityStarted != null)
        {
            ActivityStarted.Invoke();
        }
    }

    public void EndActivity()
    {
        if (DisableActivityOnEnd)
        {
            IsActivityDoable = false;
        }
        if (ActivityFinished != null)
        {
            ActivityFinished.Invoke();
        }
    }
}
