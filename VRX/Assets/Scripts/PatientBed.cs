using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PatientBed : MonoBehaviour, IInteractable
{
    #region Properties

    [SerializeField] public string ObjectName;
    [SerializeField] public GameObject InteractMenu;
    [SerializeField] public GameObject ButtonPreFab;

    [SerializeField] public GameObject Mattress;
    [SerializeField] public GameObject Patient;

    private List<GameObject> InteractMenuOptionButtons;

    #endregion

    #region Start

    void Start()
    {
        InteractMenuOptionButtons = new List<GameObject>();

        // Instantiate Raise/Lower Head button for PatientBed. 
        GameObject raiseHeadButton = Instantiate(ButtonPreFab);
        raiseHeadButton.transform.GetChild(0).GetComponent<Text>().text = "Raise/Lower Head";
        raiseHeadButton.GetComponent<Button>().onClick.AddListener(OnLowerHeadClick);
        InteractMenuOptionButtons.Add(raiseHeadButton);

        // Instantiate Raise/Lower Bed button for PatientBed. 
        GameObject raiseBedButton = Instantiate(ButtonPreFab);
        raiseBedButton.transform.GetChild(0).GetComponent<Text>().text = "Raise/Lower Bed";
        raiseBedButton.GetComponent<Button>().onClick.AddListener(OnLowerHeightClick);
        InteractMenuOptionButtons.Add(raiseBedButton);

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

    // Update is called once per frame
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

    public void OnLowerHeadClick()
    {
        LowerPatientBedHead();
    }

    public void OnLowerHeightClick()
    {
        LowerPatientBedHeight();
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

    public void LowerPatientBedHead()
    {
        Animator animator = Mattress.GetComponent<Animator>();

        if (animator != null)
        {
            bool shouldLower = animator.GetBool("Lower");

            animator.SetBool("Lower", !shouldLower);
        }
    }

    public void LowerPatientBedHeight()
    {
        Animator animator = this.GetComponent<Animator>();

        if (animator != null)
        {
            bool shouldLower = animator.GetBool("LowerHeight");

            animator.SetBool("LowerHeight", !shouldLower);
        }
    }

    #endregion
}
