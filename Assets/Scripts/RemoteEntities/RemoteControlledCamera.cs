using UnityEngine;

public class RemoteControlledCamera : RemoteControlledEntity
{
    public GameObject Camera;

    public override void ActivateEntity()
    {
        Camera.transform.position = transform.position;
        Camera.transform.rotation = transform.rotation;
    }

    public override void DeactivateEntity()
    {
    }
}
