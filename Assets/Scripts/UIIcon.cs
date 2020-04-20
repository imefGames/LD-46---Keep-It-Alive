using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIIcon : MonoBehaviour
{
    public Transform TrackedPosition;

    public Vector2 MinEntityPosition;
    public Vector2 MaxEntityPosition;
    public Vector2 MinMapPosition;
    public Vector2 MaxMapPosition;

    void Update()
    {
        Vector3 mapPosition = Vector3.zero;
        RectTransform rectTransform = GetComponent<RectTransform>();

        Vector3 positionRatio = TrackedPosition.localPosition;
        positionRatio.x = (positionRatio.x - MinEntityPosition.x) / (MaxEntityPosition.x - MinEntityPosition.x);
        positionRatio.z = (positionRatio.z - MinEntityPosition.y) / (MaxEntityPosition.y - MinEntityPosition.y);

        mapPosition.x = positionRatio.x * (MaxMapPosition.x - MinMapPosition.x) + MinMapPosition.x;
        mapPosition.y = positionRatio.z * (MaxMapPosition.y - MinMapPosition.y) + MinMapPosition.y;

        rectTransform.localPosition = mapPosition;
    }
}
