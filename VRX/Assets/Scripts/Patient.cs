﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Patient : MonoBehaviour, IInteractable, IPerson
{
    #region Properties

    [SerializeField] public string ObjectName;
    [SerializeField] public GameObject InteractMenu;
    [SerializeField] public GameObject ButtonPreFab;

    private List<GameObject> InteractMenuOptionButtons;
    public List<string> Questions;

    #endregion

    #region Start

    void Start()
    {
        InteractMenuOptionButtons = new List<GameObject>();
        Questions = new List<string>();

        // Instantiate both enquiry conversation buttons.
        GameObject enquiryConversation1Button = Instantiate(ButtonPreFab);
        enquiryConversation1Button.transform.GetChild(0).GetComponent<Text>().text = "Hi! How are you today?";
        enquiryConversation1Button.GetComponent<Button>().onClick.AddListener(onEnquiryConversation1);
        enquiryConversation1Button.name = "enquiryConversation1Button";
        Questions.Add(enquiryConversation1Button.name);
        InteractMenuOptionButtons.Add(enquiryConversation1Button);

        GameObject enquiryConversation2Button = Instantiate(ButtonPreFab);
        enquiryConversation2Button.transform.GetChild(0).GetComponent<Text>().text = "Are you in pain today?";
        enquiryConversation2Button.GetComponent<Button>().onClick.AddListener(onEnquiryConversation2);
        enquiryConversation2Button.name = "enquiryConversation2Button";
        Questions.Add(enquiryConversation2Button.name);
        InteractMenuOptionButtons.Add(enquiryConversation2Button);

        // Instantiate RotateLeft button for Patient. 
        GameObject rotateLeftButton = Instantiate(ButtonPreFab);
        rotateLeftButton.transform.GetChild(0).GetComponent<Text>().text = "Rotate Left";
        rotateLeftButton.GetComponent<Button>().onClick.AddListener(OnRotateLeftClick);
        InteractMenuOptionButtons.Add(rotateLeftButton);

        // Instantiate RotateRight button for Patient.
        GameObject rotateRightButton = Instantiate(ButtonPreFab);
        rotateRightButton.transform.GetChild(0).GetComponent<Text>().text = "Rotate Right";
        rotateRightButton.GetComponent<Button>().onClick.AddListener(OnRotateRightClick);
        InteractMenuOptionButtons.Add(rotateRightButton);

        // Instantiate Exit button for PatientBed. 
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

    void Update()
    {

    }

    #region On Hover

    public HoverOutput Hover()
    {
        return new HoverOutput
        {
            ObjectName = ObjectName
        };
    }

    public bool IsAlive()
    {
        return false;
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

    public void onEnquiryConversation1()
    {

        FindObjectOfType<DialogText>().PatientDialog(".");


    }
    public void onEnquiryConversation2()
    {

        FindObjectOfType<DialogText>().PatientDialog("......................");


    }
    public void OnRotateLeftClick()
    {
        RotatePatientLeft();
    }

    public void OnRotateRightClick()
    {
        RotatePatientRight();
    }

    public void OnExitButtonClick()
    {
        foreach (GameObject button in InteractMenuOptionButtons)
        {
            button.SetActive(false);
        }

        InteractMenu.SetActive(false);
    }

    #endregion

    #region Animations

    public void RotatePatientLeft()
    {
        Animator animator = this.GetComponent<Animator>();

        if (animator != null)
        {
            bool shouldRotate = animator.GetBool("RotateLeft");

            animator.SetBool("RotateLeft", !shouldRotate);
        }
    }

    public void RotatePatientRight()
    {
        Animator animator = this.GetComponent<Animator>();

        if (animator != null)
        {
            bool shouldRotate = animator.GetBool("RotateRight");

            animator.SetBool("RotateRight", !shouldRotate);
        }
    }

    #endregion
}
