using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectOne : MonoBehaviour, IInteractable
{
    [SerializeField] public string ObjectName;
    
    public List<GameObject> InteractMenuOptionButtons;
    public GameObject ButtonPreFab;

    void Start()
    {
        GameObject objectOneButton = Instantiate(ButtonPreFab);
        objectOneButton.transform.GetChild(0).GetComponent<Text>().text = "Click Object One";
        InteractMenuOptionButtons.Add(objectOneButton);

        GameObject exitButton = Instantiate(ButtonPreFab);
        exitButton.transform.GetChild(0).GetComponent<Text>().text = "Exit";
        exitButton.GetComponent<Button>().onClick.AddListener(OnExitButtonClick);
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

    void OnExitButtonClick() 
    {
        Debug.Log("Exit was clicked!!!");
    }
}
