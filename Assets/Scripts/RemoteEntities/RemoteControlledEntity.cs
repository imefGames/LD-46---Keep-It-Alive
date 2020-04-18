using UnityEngine;

public abstract class RemoteControlledEntity : MonoBehaviour
{
    void Start()
    {
        DeactivateEntity();
    }

    public abstract void ActivateEntity();
    public abstract void DeactivateEntity();
}
