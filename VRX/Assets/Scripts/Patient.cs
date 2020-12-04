using System.Collections.Generic;
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

    public bool conversation1;
    public bool conversation2;
    public bool conversation3;
    public bool checkEyes;
    public bool takeBloodPressure;
    public bool takePulse;
    public bool checkBreathing;
    public bool checkSkinColor;
    public bool morphine4mg;
    public bool morphine8mg;

    #endregion

    #region Start

    void Start()
    {
        InteractMenuOptionButtons = new List<GameObject>();
        Questions = new List<string>();
        conversation1 = false;
        conversation2 = false;
        conversation3 = false;
        checkEyes = false;
        takeBloodPressure = false;
        takePulse = false;
        checkBreathing = false;
        checkSkinColor = false;
        morphine4mg = false;
        morphine8mg = false;

        // Instantiate enquiry conversation buttons.
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

        GameObject enquiryConversation3Button = Instantiate(ButtonPreFab);
        enquiryConversation3Button.transform.GetChild(0).GetComponent<Text>().text = "Can you lift your arm?";
        enquiryConversation3Button.GetComponent<Button>().onClick.AddListener(onEnquiryConversation3);
        enquiryConversation3Button.name = "enquiryConversation3Button";
        Questions.Add(enquiryConversation3Button.name);
        InteractMenuOptionButtons.Add(enquiryConversation3Button);

        // Instantiate Eye check button for Patient
        GameObject checkEyesButton = Instantiate(ButtonPreFab);
        checkEyesButton.transform.GetChild(0).GetComponent<Text>().text = "Check eyes";
        checkEyesButton.GetComponent<Button>().onClick.AddListener(onCheckEyesClick);
        checkEyesButton.name = "checkEyesButton";
        Questions.Add(checkEyesButton.name);
        InteractMenuOptionButtons.Add(checkEyesButton);

        // Instantiate Blood Pressure button for Patient
        GameObject takeBloodPressureButton = Instantiate(ButtonPreFab);
        takeBloodPressureButton.transform.GetChild(0).GetComponent<Text>().text = "Take blood pressure";
        takeBloodPressureButton.GetComponent<Button>().onClick.AddListener(onTakeBloodPressureClick);
        takeBloodPressureButton.name = "takeBloodPressureButton";
        Questions.Add(takeBloodPressureButton.name);
        InteractMenuOptionButtons.Add(takeBloodPressureButton);

        // Instantiate Pulse button for Patient
        GameObject takePulseButton = Instantiate(ButtonPreFab);
        takePulseButton.transform.GetChild(0).GetComponent<Text>().text = "Take Pulse";
        takePulseButton.GetComponent<Button>().onClick.AddListener(onTakePulseClick);
        takePulseButton.name = "takePulseButton";
        Questions.Add(takePulseButton.name);
        InteractMenuOptionButtons.Add(takePulseButton);

        // Instantiate check breathing button for Patient
        GameObject checkBreathingButton = Instantiate(ButtonPreFab);
        checkBreathingButton.transform.GetChild(0).GetComponent<Text>().text = "Check breathing";
        checkBreathingButton.GetComponent<Button>().onClick.AddListener(onCheckBreathingClick);
        checkBreathingButton.name = "checkBreathingButton";
        Questions.Add(checkBreathingButton.name);
        InteractMenuOptionButtons.Add(checkBreathingButton);

        // Instantiate check skin color button for Patient
        GameObject checkSkinColorButton = Instantiate(ButtonPreFab);
        checkSkinColorButton.transform.GetChild(0).GetComponent<Text>().text = "Check skin color";
        checkSkinColorButton.GetComponent<Button>().onClick.AddListener(onCheckSkinColorClick);
        checkSkinColorButton.name = "checkSkinColorButton";
        Questions.Add(checkSkinColorButton.name);
        InteractMenuOptionButtons.Add(checkSkinColorButton);

        // Instantiate administer medication button for Patient
        GameObject adminsiterMediationButton = Instantiate(ButtonPreFab);
        adminsiterMediationButton.transform.GetChild(0).GetComponent<Text>().text = "Adminsiter mediation";
        adminsiterMediationButton.GetComponent<Button>().onClick.AddListener(onAdminsiterMediationClick);
        adminsiterMediationButton.name = "adminsiterMediationButton";
        Questions.Add(adminsiterMediationButton.name);
        InteractMenuOptionButtons.Add(adminsiterMediationButton);

        /*
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
        */
        
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
        if (conversation1 == false)
        {
            FindObjectOfType<Score>().UpdateScore();
            conversation1 = true;
        }

        FindObjectOfType<DialogText>().PatientDialog(".");


    }
    public void onEnquiryConversation2()
    {
        if (conversation2 == false)
        {
            FindObjectOfType<Score>().UpdateScore();
            conversation2 = true;
        }
        FindObjectOfType<DialogText>().PatientDialog("......................");


    }
    public void onEnquiryConversation3()
    {
        if (conversation3 == false)
        {
            FindObjectOfType<Score>().UpdateScore();
            conversation3 = true;
        }
        FindObjectOfType<DialogText>().PatientDialog("......................");


    }
    
    //vital signs
    public void onCheckEyesClick()
    {
        //enter animation
        if (checkEyes == false)
        {
            FindObjectOfType<Score>().UpdateScore();
            checkEyes = true;
        }
        FindObjectOfType<DialogText>().PatientDialog("Slow response time");


    }
    public void onTakeBloodPressureClick()
    {
        //enter animation
        if (takeBloodPressure == false)
        {
            FindObjectOfType<Score>().UpdateScore();
            takeBloodPressure = true;
        }
        FindObjectOfType<DialogText>().PatientDialog("70/40");


    }
    public void onTakePulseClick()
    {
        //enter animation
        if (takePulse == false)
        {
            FindObjectOfType<Score>().UpdateScore();
            takePulse = true;
        }
        FindObjectOfType<DialogText>().PatientDialog("60");

    }
    public void onCheckBreathingClick()
    {
        //enter animation
        if (checkBreathing == false)
        {
            FindObjectOfType<Score>().UpdateScore();
            checkBreathing = true;
        }
        FindObjectOfType<DialogText>().PatientDialog("Slowed and rattled");

    }
    public void onCheckSkinColorClick()
    {
        //enter animation
        if (checkSkinColor == false)
        {
            FindObjectOfType<Score>().UpdateScore();
            checkSkinColor = true;
        }
        FindObjectOfType<DialogText>().PatientDialog("Cyanotic");

    }

    //medication menu
    public void onAdminsiterMediationClick()
    {
        //make this open a new text box with the medicines on click
        //FindObjectOfType<DialogText>().PatientDialog("Make this open a new text box");
    }

    /* This needs to either be moved into another file that is just for medicine or once the buttons made on this one can be uncommented.
    //Medication on clicks
    public void onMorphine4mgClick()
    {
        //enter animation
        if (morphine4mg == false)
        {
            FindObjectOfType<Score>().UpdateScore();
            morphine4mg = true;
        }
        FindObjectOfType<DialogText>().PatientDialog("Gave Morphine 4mg");

    }
    public void onMorphine8mgClick()
    {
        //enter animation
        if (morphine8mg == false)
        {
            FindObjectOfType<Score>().DecreaseScore();
            morphine8mg = true;
        }
        FindObjectOfType<DialogText>().PatientDialog("Gave Mophine 8mg (score -1 because wrong medication)");

    }
    */
    //
    
    //Animation clicks
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

    //add the animations for check up. ex blood pressure, pulse, breathing, bowel sounds, give meds.


    #endregion
}
