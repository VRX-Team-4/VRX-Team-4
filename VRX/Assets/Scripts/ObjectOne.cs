﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectOne : MonoBehaviour, IInteractable
{
    #region Properties

    [SerializeField] public string ObjectName;
    [SerializeField] public GameObject InteractMenu;

    public List<GameObject> InteractMenuOptionButtons;
    public GameObject ButtonPreFab;

    #endregion

    #region Start

    void Start()
    {
        // Instantiate first button for Object One. 
        GameObject objectOneButton = Instantiate(ButtonPreFab);
        objectOneButton.transform.GetChild(0).GetComponent<Text>().text = "Rotate me!!!";
        objectOneButton.GetComponent<Button>().onClick.AddListener(RotateObjectOne);
        InteractMenuOptionButtons.Add(objectOneButton);

        // Instantiate Exit button for Object One. 
        GameObject exitButton = Instantiate(ButtonPreFab);
        exitButton.transform.GetChild(0).GetComponent<Text>().text = "Exit";
        exitButton.GetComponent<Button>().onClick.AddListener(OnExitButtonClick);
        InteractMenuOptionButtons.Add(exitButton);

        // Set each button as child to SelectedObjectInteractMenu. 
        foreach (GameObject button in InteractMenuOptionButtons)
        {
            button.transform.SetParent(InteractMenu.transform);
        }
    }

    #endregion

    #region On Hover

    public HoverOutput Hover()
    {
        return new HoverOutput 
        { 
            ObjectName = ObjectName
        };
    }

    #endregion

    #region On Interact

    public InteractionOutput Interact() 
    {
        // Show SelectedObjectInteractMenu on Interact. 
        InteractMenu.SetActive(true);

        // Show each button on Interact. 
        foreach (GameObject button in InteractMenuOptionButtons)
        {
            button.SetActive(true);
        }

        // Select first button. 
        InteractMenuOptionButtons[0].GetComponent<Button>().Select();

        return new InteractionOutput
        {
            ObjectName = ObjectName,
        };
    }

    #endregion

    #region On Button Click

    void RotateObjectOne()
    {
        transform.Rotate(0f, 45f, 0f);
    }

    void OnExitButtonClick()
    {
        foreach (GameObject button in InteractMenuOptionButtons)
        {
            button.SetActive(false);
        }

        InteractMenu.SetActive(false);
    }

    #endregion
}
