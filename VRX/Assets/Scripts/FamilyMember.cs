using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FamilyMember : MonoBehaviour, IInteractable, IPerson
{
    #region Properties

    [SerializeField] public string ObjectName;
    [SerializeField] public GameObject InteractMenu;
    [SerializeField] public GameObject ButtonPreFab;

    private List<GameObject> InteractMenuOptionButtons;

    public List<string> Questions;
    public bool TalkedToFamilyMemberScore;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        TalkedToFamilyMemberScore = false;
        InteractMenuOptionButtons = new List<GameObject>();
        Questions = new List<string>();

        // Instantiate Patient ID check.
        GameObject patientIdCheckButton = Instantiate(ButtonPreFab);
        patientIdCheckButton.transform.GetChild(0).GetComponent<Text>().text = "Can you please tell me the patient's name and birthday?";
        patientIdCheckButton.GetComponent<Button>().onClick.AddListener(onPatientIdCheck);
        patientIdCheckButton.name = "patientIdCheckButton";
        Questions.Add(patientIdCheckButton.name);
        InteractMenuOptionButtons.Add(patientIdCheckButton);

        // Instantiate both casual conversation buttons.
        GameObject casualConversation1Button = Instantiate(ButtonPreFab);
        casualConversation1Button.transform.GetChild(0).GetComponent<Text>().text = "Hi! How are you today?";
        casualConversation1Button.GetComponent<Button>().onClick.AddListener(onCasualConversation1);
        casualConversation1Button.name = "casualConversation1Button";
        Questions.Add(casualConversation1Button.name);
        InteractMenuOptionButtons.Add(casualConversation1Button);

        GameObject casualConversation2Button = Instantiate(ButtonPreFab);
        casualConversation2Button.transform.GetChild(0).GetComponent<Text>().text = "How is your husband feeling today?";
        casualConversation2Button.GetComponent<Button>().onClick.AddListener(onCasualConversation2);
        casualConversation2Button.name = "casualConversation2Button";
        Questions.Add(casualConversation2Button.name);
        InteractMenuOptionButtons.Add(casualConversation2Button);

        // Instantiate where is patient dialog button. 
        GameObject whereIsPatientButton = Instantiate(ButtonPreFab);
        whereIsPatientButton.transform.GetChild(0).GetComponent<Text>().text = "Where Is the Patient?";
        whereIsPatientButton.GetComponent<Button>().onClick.AddListener(OnWhereIsPatientClick);
        whereIsPatientButton.name = "whereIsPatientButton";
        Questions.Add(whereIsPatientButton.name);
        InteractMenuOptionButtons.Add(whereIsPatientButton);

        // Instantiate where is sink dialog button. 
        GameObject whereIsHandsinkButton = Instantiate(ButtonPreFab);
        whereIsHandsinkButton.transform.GetChild(0).GetComponent<Text>().text = "Where Is the Sink?";
        whereIsHandsinkButton.GetComponent<Button>().onClick.AddListener(OnWhereIsSinkClick);
        whereIsHandsinkButton.name = "whereIsHandsinkButton";
        Questions.Add(whereIsHandsinkButton.name);
        InteractMenuOptionButtons.Add(whereIsHandsinkButton);
        
        // Instantiate Reporting the checkup dialog button.
        GameObject reportOnPatientButton = Instantiate(ButtonPreFab);
        reportOnPatientButton.transform.GetChild(0).GetComponent<Text>().text = "This is how he was doing today";
        reportOnPatientButton.GetComponent<Button>().onClick.AddListener(OnReportOnPatientClick);
        reportOnPatientButton.name = "reportOnPatientButton";
        Questions.Add(reportOnPatientButton.name);
        InteractMenuOptionButtons.Add(reportOnPatientButton);

        // Instantiate Teaching the wife dialog button. 
        GameObject teachingWifeButton = Instantiate(ButtonPreFab);
        teachingWifeButton.transform.GetChild(0).GetComponent<Text>().text = "Teach wife how to take care of patient";
        teachingWifeButton.GetComponent<Button>().onClick.AddListener(OnTeachingWifeClick);
        teachingWifeButton.name = "reportOnPatientButton";
        Questions.Add(teachingWifeButton.name);
        InteractMenuOptionButtons.Add(teachingWifeButton);
        
        // Instantiate Exit button. 
        GameObject exitButton = Instantiate(ButtonPreFab);
        exitButton.transform.GetChild(0).GetComponent<Text>().text = "Exit";
        exitButton.GetComponent<Button>().onClick.AddListener(OnExitButtonClick);
        exitButton.name = "exitButton";
        Questions.Add(exitButton.name);
        InteractMenuOptionButtons.Add(exitButton);

        // Instantiate Exit button for PatientBed. 
        //GameObject okayButton = Instantiate(ButtonPreFab);
        //okayButton.transform.GetChild(0).GetComponent<Text>().text = "Okay";
        //okayButton.GetComponent<Button>().onClick.AddListener(OnOkayClick);
        //okayButton.name = "okayButton";
        //InteractMenuOptionButtons.Add(okayButton);

        // Set each button as child to SelectedObjectInteractMenu. 
        foreach (GameObject button in InteractMenuOptionButtons)
        {
            button.transform.SetParent(InteractMenu.transform);
            //if(button.name == "okayButton")
            //{
            //    okayButton.SetActive(false);
            //}
        }
    }

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

    public bool IsAlive()
    {
        return true;
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
    public void onPatientIdCheck()
    {

        FindObjectOfType<DialogText>().FamilyMemberDialog("My husbands name is Jim and he was born November 12, 1950");

        foreach (GameObject button in InteractMenuOptionButtons)
        {
            if (Questions.Contains(button.name))
            {
                //button.SetActive(false); // all of these make the menu go away on each button click for some reason and not just the button
            }
        }
    }
    public void onCasualConversation1()
    {

        FindObjectOfType<DialogText>().FamilyMemberDialog("I am doing fine, I hope you are doing well.");

        foreach (GameObject button in InteractMenuOptionButtons)
        {
            if (Questions.Contains(button.name))
            {
               // button.SetActive(false);
            }
        }
    }
    public void onCasualConversation2()
    {

        FindObjectOfType<DialogText>().FamilyMemberDialog("He is feeling a little better today. I am glad you are here to check on him.");

        foreach (GameObject button in InteractMenuOptionButtons)
        {
            if (Questions.Contains(button.name))
            {
               // button.SetActive(false);
            }
        }
    }
    public void OnWhereIsPatientClick()
    {
        if (TalkedToFamilyMemberScore == false)
        {
            FindObjectOfType<Score>().UpdateScore();
            TalkedToFamilyMemberScore = true;
        }

        FindObjectOfType<DialogText>().FamilyMemberDialog("The patient is up the stairs, in the room the oposite side of the stair case");

        foreach (GameObject button in InteractMenuOptionButtons)
        {
            if (Questions.Contains(button.name))
            {
                //button.SetActive(false);
            }
        }
    }

    public void OnWhereIsSinkClick()
    {
        if (TalkedToFamilyMemberScore == false)
        {
            FindObjectOfType<Score>().UpdateScore();
            TalkedToFamilyMemberScore = true;
        }

        FindObjectOfType<DialogText>().FamilyMemberDialog("The sink is up the stairs in the restroom. The room in front of the stair case");

        foreach (GameObject button in InteractMenuOptionButtons)
        {
            if (Questions.Contains(button.name))
            {
               // button.SetActive(false);
            }
        }
    }
    
    public void OnReportOnPatientClick()
    {
        if (TalkedToFamilyMemberScore == false)
        {
            FindObjectOfType<Score>().UpdateScore();
            TalkedToFamilyMemberScore = true;
        }

        FindObjectOfType<DialogText>().FamilyMemberDialog("Thank you I am glad you came to check on him.");

        foreach (GameObject button in InteractMenuOptionButtons)
        {
            if (Questions.Contains(button.name))
            {
               // button.SetActive(false);
            }
        }
    }

    public void OnTeachingWifeClick()
    {
        if (TalkedToFamilyMemberScore == false)
        {
            FindObjectOfType<Score>().UpdateScore();
            TalkedToFamilyMemberScore = true;
        }

        FindObjectOfType<DialogText>().FamilyMemberDialog("Ok i will do that. Thank you for coming and I will see you next time.");

        foreach (GameObject button in InteractMenuOptionButtons)
        {
            if (Questions.Contains(button.name))
            {
                //button.SetActive(false);
            }
        }
    }
    
    public void OnExitButtonClick()
    {
        foreach (GameObject button in InteractMenuOptionButtons)
        {
            button.SetActive(false);
        }

        InteractMenu.SetActive(false);
    }

    public void OnOkayClick()
    {
        foreach (GameObject button in InteractMenuOptionButtons)
        {
            if (Questions.Contains(button.name))
            {
                button.SetActive(true);
            }
            else if (button.name == "okayButton")
            {
                button.SetActive(false);
            }
        }
    }

    #endregion
}
