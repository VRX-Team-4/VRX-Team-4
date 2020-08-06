using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Seat_01 : MonoBehaviour, IInteractable
{
    #region Properties

    [SerializeField] public string ObjectName;
    [SerializeField] public GameObject InteractMenu;

    public List<GameObject> InteractMenuOptionButtons;
    public GameObject ButtonPreFab;

    public GameObject SeatRotationPoint;
    public bool IsLifting = false;
    public float AngleToRotate = 90f;
    public float TimeToRotate = 1024f;
    public float StepAngle;

    #endregion

    #region Start

    void Start()
    {
        StepAngle = AngleToRotate / ( TimeToRotate / 1000f );

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
        //if (transform.rotation.eulerAngles.x <= -90f)
        //{
        //    Debug.Log("check");
        //    IsLifting = false;
        //}

        //if (IsLifting == true) 
        //{
        //    transform.RotateAround(SeatRotationPoint.transform.position, new Vector3(1f, 0f, 0f), -60 * Time.deltaTime);
        //}
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
        //IsLifting = true;
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
