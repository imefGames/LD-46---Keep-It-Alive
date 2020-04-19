using System;
using System.Collections.Generic;
using UnityEngine;

public enum EStat
{
    None,
    Hunger,
    Thirst,
    Fun
}

public enum EStatState
{
    Normal,
    Warning,
    Critical
}

[Serializable]
public class Stat
{
    public EStat StatType;
    public float StatValue = 0.0f;
    public float DecaySpeed = 0.0f;
    public float WarningValue = 0.0f;
    public float CriticalValue = 0.0f;
}

public class StatController : MonoBehaviour
{
    public Stat[] Stats;
    public float DepressionMultiplier = 1.0f;

    void Start()
    {
        foreach (Stat s in Stats)
        {
            s.StatValue = 1.0f;
        }
    }

    void Update()
    {
        float multiplier = 1.0f;
        if (GetStat(EStat.Fun) == 0.0f)
        {
            multiplier = DepressionMultiplier;
        }

        foreach (Stat s in Stats)
        {
            s.StatValue = Mathf.Clamp(s.StatValue - Time.deltaTime * s.DecaySpeed * multiplier, 0.0f, 1.0f);
        }

        if (GetStat(EStat.Thirst) == 0.0f || GetStat(EStat.Hunger) == 0.0f)
        {
            FlowManager flowManager = FlowManager.Get();
            if (flowManager.FlowState == EFlowState.InGame)
            {
                flowManager.FlowState = EFlowState.GameOver;
            }
        }
    }

    public float GetStat(EStat statType)
    {
        foreach (Stat s in Stats)
        {
            if (s.StatType == statType)
            {
                return s.StatValue;
            }
        }
        return 0.0f;
    }

    public EStatState GetStatState(EStat statType)
    {
        foreach (Stat s in Stats)
        {
            if (s.StatType == statType)
            {
                EStatState state = EStatState.Normal;
                if (s.StatValue < s.CriticalValue)
                {
                    state = EStatState.Critical;
                }
                else if (s.StatValue < s.WarningValue)
                {
                    state = EStatState.Warning;
                }
                return state;
            }
        }
        return EStatState.Normal;
    }

    public void RefillStat(EStat statType, float amount)
    {
        foreach (Stat s in Stats)
        {
            if (s.StatType == statType)
            {
                s.StatValue = Mathf.Clamp(s.StatValue + Time.deltaTime * amount, 0.0f, 1.0f);
                break;
            }
        }
    }

    public List<EStat> ComputeLowStats()
    {
        List<EStat> lowStats = new List<EStat>();
        foreach (Stat s in Stats)
        {
            if (s.StatValue < s.CriticalValue || s.StatValue < s.WarningValue)
            {
                lowStats.Add(s.StatType);
            }
        }
        return lowStats;
    }
}
