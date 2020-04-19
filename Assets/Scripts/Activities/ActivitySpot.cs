using Unity.Collections;
using UnityEngine;
using UnityEngine.Events;

public class ActivitySpot : MonoBehaviour
{
    public Transform ActivityPosition;
    public float ActivityDuration;
    public bool IsActivityDoable;
    public bool DisableActivityOnEnd;
    public UnityEvent ActivityStarted;
    public UnityEvent ActivityFinished;
    public UnityEvent ActivityDoable;

    public void MakeActivityDoable()
    {
        if (ActivityDoable != null)
        {
            ActivityDoable.Invoke();
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
