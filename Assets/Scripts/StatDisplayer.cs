using UnityEngine;

public class StatDisplayer : MonoBehaviour
{
    public StatController StatSource;
    public UIGauge HungerGauge;
    public UIGauge ThirstGauge;
    public UIGauge FunGauge;
    public Color NormalColor;
    public Color WarningColor;
    public Color CriticalColor;

    void Update()
    {
        if (StatSource != null)
        {
            HungerGauge.Value = StatSource.GetStat(EStat.Hunger);
            ThirstGauge.Value = StatSource.GetStat(EStat.Thirst);
            FunGauge.Value = StatSource.GetStat(EStat.Fun);


            HungerGauge.Color = FindStatColor(StatSource.GetStatState(EStat.Hunger));
            ThirstGauge.Color = FindStatColor(StatSource.GetStatState(EStat.Thirst));
            FunGauge.Color = FindStatColor(StatSource.GetStatState(EStat.Fun));
        }
    }

    Color FindStatColor(EStatState state)
    {
        switch (state)
        {
            case EStatState.Warning: return WarningColor;
            case EStatState.Critical: return CriticalColor;
        }
        return NormalColor;
    }
}
