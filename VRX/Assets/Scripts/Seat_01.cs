using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Seat_01 : MonoBehaviour, IInteractable
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

        // Instantiate Flush button for Seat_01. 
        GameObject toiletFlushButton = Instantiate(ButtonPreFab);
        toiletFlushButton.transform.GetChild(0).GetComponent<Text>().text = "Flush";
        toiletFlushButton.GetComponent<Button>().onClick.AddListener(FlushToilet);
        InteractMenuOptionButtons.Add(toiletFlushButton);

        // Instantiate LiftSeat_01 button for Seat_01. 
        GameObject liftSeatButton = Instantiate(ButtonPreFab);
        liftSeatButton.transform.GetChild(0).GetComponent<Text>().text = "Lift Seat";
        liftSeatButton.GetComponent<Button>().onClick.AddListener(LiftSeat_01);
        InteractMenuOptionButtons.Add(liftSeatButton);

        // Instantiate Exit button for Seat_01. 
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

    void FlushToilet()
    {
        Debug.Log("Flush!!!");
    }

    void LiftSeat_01() 
    {
        Animator animator = this.GetComponent<Animator>();

        if (animator != null)
        {
            bool isOpen = animator.GetBool("Open");

            animator.SetBool("Open", !isOpen);
        }
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
