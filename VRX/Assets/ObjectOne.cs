using UnityEngine;

public class ObjectOne : MonoBehaviour, IInteractable
{
    [SerializeField] public string ObjectName;

    public string Interact() 
    {
        return ObjectName;
    }
}
