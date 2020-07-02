using UnityEngine;

public class ObjectTwo : MonoBehaviour, IInteractable
{
    [SerializeField] public string ObjectName;

    public string Interact()
    {
        return ObjectName;
    }
}
