using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PatientHead : MonoBehaviour, IInteractable
{
    #region Properties

    [SerializeField] public string ObjectName;
    [SerializeField] public GameObject InteractMenu;
    [SerializeField] public GameObject ButtonPreFab;

    private List<GameObject> InteractMenuOptionButtons;

    #endregion

    #region Start

    void Start()
    {
        InteractMenuOptionButtons = new List<GameObject>();

        // Instantiate CleanHair button for Patient. 
        GameObject cleanHairButton = Instantiate(ButtonPreFab);
        cleanHairButton.transform.GetChild(0).GetComponent<Text>().text = "Clean Hair";
        cleanHairButton.GetComponent<Button>().onClick.AddListener(OnCleanHairClick);
        InteractMenuOptionButtons.Add(cleanHairButton);

        // Instantiate RotateRight button for Patient.
        GameObject cleanTeethButton = Instantiate(ButtonPreFab);
        cleanTeethButton.transform.GetChild(0).GetComponent<Text>().text = "Clean Teeth";
        cleanTeethButton.GetComponent<Button>().onClick.AddListener(OnCleanTeethClick);
        InteractMenuOptionButtons.Add(cleanTeethButton);

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

    public void OnCleanHairClick()
    {
        Debug.Log("Cleaned Hair!!!");
    }

    public void OnCleanTeethClick()
    {
        Debug.Log("Clean Teeth!!!");
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
}
