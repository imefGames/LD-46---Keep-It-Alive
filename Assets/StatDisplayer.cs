using UnityEngine;

public class StatDisplayer : MonoBehaviour
{
    public StatController StatSource;
    public UIGauge HungerGauge;
    public UIGauge ThirstGauge;
    public UIGauge FunGauge;

    void Update()
    {
        if (StatSource != null)
        {
            HungerGauge.Value = StatSource.GetStat(EStat.Hunger);
            ThirstGauge.Value = StatSource.GetStat(EStat.Thirst);
            FunGauge.Value = StatSource.GetStat(EStat.Fun);
        }
    }
}
