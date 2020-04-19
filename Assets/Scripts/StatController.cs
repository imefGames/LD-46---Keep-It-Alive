using System;
using UnityEngine;

public enum EStat
{
    None,
    Hunger,
    Thirst,
    Fun
}

[Serializable]
public class Stat
{
    public EStat StatType;
    public float StatValue = 0.0f;
    public float DecaySpeed = 0.0f;
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
}
