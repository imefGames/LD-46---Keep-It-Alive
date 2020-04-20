using UnityEngine;
using UnityEngine.UI;

public class UIActivityButton : MonoBehaviour
{
    public ActivitySpot WatchedActivity;
    public Image IconImage;

    void Update()
    {
        Button button = GetComponent<Button>();
        button.interactable = !WatchedActivity.IsActivityDoable;

        Color c = IconImage.color;
        if (button.interactable)
        {
            c.a = button.colors.normalColor.a;
        }
        else
        {
            c.a = button.colors.disabledColor.a;
        }
        IconImage.color = c;
    }
}
