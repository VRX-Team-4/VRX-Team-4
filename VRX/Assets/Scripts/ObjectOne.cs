using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectOne : MonoBehaviour, IInteractable
{
    [SerializeField] public string ObjectName;
    [SerializeField] public GameObject InteractMenu;
    //[SerializeField] public GameObject InteractCanvas;

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

        //GameObject interactMenu = Instantiate(InteractMenu);

        foreach (var button in InteractMenuOptionButtons)
        {
            button.transform.SetParent(InteractMenu.transform);
        }

        //interactMenu.transform.SetParent(InteractCanvas.transform);
        //interactMenu.transform.position = new Vector3(0.0f, -80f, 0.0f);

        //interactMenu.SetActive(true);
    }

    public InteractionOutput Interact() 
    {
        //GameObject objectOneButton = Instantiate(ButtonPreFab);
        //objectOneButton.transform.GetChild(0).GetComponent<Text>().text = "Click Object One";
        //InteractMenuOptionButtons.Add(objectOneButton);

        //GameObject exitButton = Instantiate(ButtonPreFab);
        //exitButton.transform.GetChild(0).GetComponent<Text>().text = "Exit";
        //exitButton.GetComponent<Button>().onClick.AddListener(OnExitButtonClick);
        //InteractMenuOptionButtons.Add(exitButton);

        //GameObject interactMenu = Instantiate(InteractMenu);

        //foreach (var button in InteractMenuOptionButtons) 
        //{
        //    button.transform.SetParent(interactMenu.transform);
        //}

        //interactMenu.transform.SetParent(InteractCanvas.transform);
        InteractMenu.SetActive(true);

        foreach (var button in InteractMenuOptionButtons)
        {
            button.SetActive(true);
        }

        InteractMenuOptionButtons[0].GetComponent<Button>().Select();

        Debug.Log("i test");
        return new InteractionOutput
        {
            ObjectName = ObjectName,
            //InteractionManuPanel = interactMenu
            //InteractMenuOptionButtons = InteractMenuOptionButtons,
        };
    }

    void OnExitButtonClick()
    {
        foreach (var button in InteractMenuOptionButtons)
        {
            button.SetActive(false);
            InteractMenu.SetActive(false);
        }
        //foreach (Transform child in InteractMenu.transform)
        //{
        //    Destroy(child.gameObject);
        //}
        //InteractMenu.transform.DetachChildren();
        //foreach (GameObject option in InteractMenuOptionButtons)
        //{
        //    option.transform.parent = null;
        //}
        //InteractMenu.SetActive(false);
    }
}
