using UnityEngine;
using UnityEngine.UI;

public class UIGauge : MonoBehaviour
{
    private float m_Value = 1.0f;
    private Color m_Color;

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

    public Color Color
    {
        get { return m_Color; }
        set
        {
            m_Color = value;
            if (GaugeImage != null)
            {
                GaugeImage.color = m_Color;
            }
        }
    }

    public RectTransform GaugeTransform;
    public Image GaugeImage;
}
