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
        whereIsHandsinkButton.GetComponent<Button>().onClick.AddListener(OnWhereIsPatientClick);
        whereIsHandsinkButton.name = "whereIsHandsinkButton";
        Questions.Add(whereIsHandsinkButton.name);
        InteractMenuOptionButtons.Add(whereIsHandsinkButton);

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

        // Stop the player from moving during dialogue
        GameObject thePlayer = GameObject.Find("Player");
        PlayerMovement pm = thePlayer.GetComponent<PlayerMovement>();
        pm.canMove = false;

        // Select first button. 
        InteractMenuOptionButtons[0].GetComponent<Button>().Select();

        return new InteractionOutput
        {
            ObjectName = ObjectName,
        };

    }

    #endregion

    #region On Button Click
    
    public void OnWhereIsPatientClick()
    {
        if(TalkedToFamilyMemberScore  == false){
            FindObjectOfType<Score>().UpdateScore();
            TalkedToFamilyMemberScore = true;
        }

        FindObjectOfType<DialogText>().FamilyMemberDialog("The patient is up the stairs, in the room the oposite side of the stair case");
    }

    public void OnWhereIsSinkClick()
    {
        if (TalkedToFamilyMemberScore == false)
        {
            FindObjectOfType<Score>().UpdateScore();
            TalkedToFamilyMemberScore = true;
        }

        FindObjectOfType<DialogText>().FamilyMemberDialog("The sink is up the stairs in the restroom. The room in front of the stair case");
    }

    public void OnExitButtonClick()
    {
        foreach (GameObject button in InteractMenuOptionButtons)
        {
            button.SetActive(false);
        }

        InteractMenu.SetActive(false);

        // allow the player to move again
        GameObject thePlayer = GameObject.Find("Player");
        PlayerMovement pm = thePlayer.GetComponent<PlayerMovement>();
        pm.canMove = true;
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
