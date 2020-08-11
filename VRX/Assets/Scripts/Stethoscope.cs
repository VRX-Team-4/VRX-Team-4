using UnityEngine;

public class Stethoscope : MonoBehaviour
{
    public bool IsBeingUsed;

    void Start()
    {
        IsBeingUsed = false;
    }

    void Update()
    {
        //transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 5.0f));
    }

    public bool UseStethoscope()
    {
        IsBeingUsed = !IsBeingUsed;

        return IsBeingUsed;
    }
}
