using UnityEngine;

public class UIGauge : MonoBehaviour
{
    private float m_Value = 1.0f;

    public float Value
    {
        get { return m_Value; }
        set
        {
            m_Value = Mathf.Clamp(value, 0.0f, 1.0f);
            if (GaugeTransform != null)
            {
                GaugeTransform.localScale = new Vector3(m_Value, 1.0f, 1.0f);
            }
        }
    }

    public RectTransform GaugeTransform;
}
