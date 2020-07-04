using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectTwo : MonoBehaviour, IInteractable
{
    [SerializeField] public string ObjectName;

    public List<GameObject> InteractMenuOptionButtons;
    public GameObject ButtonPreFab;

    void Start()
    {
        GameObject objectOneButton = Instantiate(ButtonPreFab);
        objectOneButton.transform.GetChild(0).GetComponent<Text>().text = "Click Object Two";
        InteractMenuOptionButtons.Add(objectOneButton);

        GameObject exitButton = Instantiate(ButtonPreFab);
        exitButton.transform.GetChild(0).GetComponent<Text>().text = "Exit";
        InteractMenuOptionButtons.Add(exitButton);
    }

    public InteractionOutput Interact()
    {
        return new InteractionOutput
        {
            ObjectName = ObjectName,
            InteractMenuOptionButtons = InteractMenuOptionButtons,
        };
    }
}
