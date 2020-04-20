 using UnityEngine;
 using UnityEngine.UI;
 using UnityEngine.EventSystems;
 
public class UIFocusHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string DisplayedText;
    public Text DisplayTextArea;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (DisplayTextArea != null)
        {
            DisplayTextArea.text = DisplayedText;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (DisplayTextArea != null)
        {
            DisplayTextArea.text = "";
        }
    }
}