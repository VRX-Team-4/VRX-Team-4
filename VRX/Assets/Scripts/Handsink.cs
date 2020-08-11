using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Handsink : MonoBehaviour, IInteractable
{
    #region Properties

    [SerializeField] public string ObjectName;
    [SerializeField] public GameObject InteractMenu;
    [SerializeField] public GameObject ButtonPreFab;
    [SerializeField] public GameObject HandSinkWater;
    [SerializeField] public GameObject HandSinkWaterStream;

    private List<GameObject> InteractMenuOptionButtons;

    public bool HandsWashed;
    public bool ClaimedPoint;

    #endregion

    #region Start

    void Start()
    {
        // Instantiate Goal Variable
        HandsWashed = false;
        ClaimedPoint = false;
        InteractMenuOptionButtons = new List<GameObject>();

        // Instantiate Wash Hands button for Handsink. 
        GameObject washHandsButton = Instantiate(ButtonPreFab);
        washHandsButton.transform.GetChild(0).GetComponent<Text>().text = "Wash Hands";
        washHandsButton.GetComponent<Button>().onClick.AddListener(WashHands);
        InteractMenuOptionButtons.Add(washHandsButton);

        // Instantiate Exit button for Handsink. 
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

    public void WashHands()
    {
        FindObjectOfType<Score>().UpdateScore();
        Debug.Log("Hands washed!!!");

        PourWater();
        FillSink();
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

    #region Scoring

    public bool AwardPoint()
    {
        if (HandsWashed && !ClaimedPoint)
        {
            ClaimedPoint = true;
            return true;
        }
        else
        {
            return false;

        } 
    }
    #endregion

    #region Animations

    public void FillSink()
    {
        Animator animator = HandSinkWater.GetComponent<Animator>();

        if (animator != null)
        {
            bool shouldFill = animator.GetBool("Fill");

            animator.SetBool("Fill", !shouldFill);
        }
    }

    public void PourWater()
    {
        Animator animator = HandSinkWaterStream.GetComponent<Animator>();

        if (animator != null)
        {
            bool shouldStream = animator.GetBool("Streaming");

            animator.SetBool("Streaming", !shouldStream);
}
    }

    #endregion
}
