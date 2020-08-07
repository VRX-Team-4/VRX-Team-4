using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SmartPhone : MonoBehaviour
{
    [SerializeField] public KeyCode SmartPhoneKey;
    [SerializeField] public GameObject ButtonPreFab;
    [SerializeField] public GameObject SmartPhonePanelPreFab;
    [SerializeField] public GameObject Canvas;

    private List<GameObject> SmartPhoneButtons;
    private GameObject smartPhonePanel;
    private RectTransform smartPhoneTransform;

    void Start()
    {
        SmartPhoneButtons = new List<GameObject>();

        smartPhonePanel = Instantiate(SmartPhonePanelPreFab);
        smartPhonePanel.transform.SetParent(Canvas.transform);
        smartPhonePanel.SetActive(false);

        GameObject callHospiceButton = Instantiate(ButtonPreFab);
        callHospiceButton.transform.GetChild(0).GetComponent<Text>().text = "Call Hospice";
        callHospiceButton.transform.SetParent(smartPhonePanel.transform);
        SmartPhoneButtons.Add(callHospiceButton);

        GameObject callFuneralHome = Instantiate(ButtonPreFab);
        callFuneralHome.transform.GetChild(0).GetComponent<Text>().text = "Call Funeral Home";
        callFuneralHome.transform.SetParent(smartPhonePanel.transform);
        SmartPhoneButtons.Add(callFuneralHome);

        smartPhoneTransform = smartPhonePanel.GetComponent<RectTransform>();
    }

    void Update()
    {
        // Set SmartPhone button panel to SmartPhone transform position. 
        if (smartPhonePanel != null)
        {
            var screenPoint = Camera.main.WorldToScreenPoint(this.transform.position);
            smartPhoneTransform.position = screenPoint + new Vector3(185f, 50f, 0f);
        }

        // If key pressed, play animation and set SmartPhone button panel active/inactive.
        if (Input.GetKeyDown(SmartPhoneKey)) 
        {
            RaiseSmartPhone();

            smartPhonePanel.SetActive(!smartPhonePanel.activeSelf);

            foreach (GameObject button in SmartPhoneButtons)
            {
                button.SetActive(!button.activeSelf);
            }

            SmartPhoneButtons[0].GetComponent<Button>().Select();
        }
    }

    // Calls raise/lower SmartPhone animation. 
    public void RaiseSmartPhone() 
    {
        Animator animator = this.GetComponent<Animator>();

        if (animator != null)
        {
            bool shouldRaise = animator.GetBool("Raise");

            animator.SetBool("Raise", !shouldRaise);
        }
    }
}
