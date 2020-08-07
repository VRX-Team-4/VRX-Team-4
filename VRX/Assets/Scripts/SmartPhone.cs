using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SmartPhone : MonoBehaviour
{
    [SerializeField] public GameObject ButtonPreFab;
    [SerializeField] public GameObject SmartPhonePanelPreFab;
    [SerializeField] public GameObject Canvas;

    private List<GameObject> SmartPhoneButtons;
    private GameObject smartPhonePanel;
    private RectTransform smartPhoneTransform;

    #region Start

    void Start()
    {
        SmartPhoneButtons = new List<GameObject>();

        smartPhonePanel = Instantiate(SmartPhonePanelPreFab);
        smartPhonePanel.transform.SetParent(Canvas.transform);
        smartPhonePanel.SetActive(false);

        GameObject callHospiceButton = Instantiate(ButtonPreFab);
        callHospiceButton.transform.GetChild(0).GetComponent<Text>().text = "Call Hospice";
        callHospiceButton.transform.SetParent(smartPhonePanel.transform);
        callHospiceButton.GetComponent<Button>().onClick.AddListener(CallHospice);
        SmartPhoneButtons.Add(callHospiceButton);

        GameObject callFuneralHomeButton = Instantiate(ButtonPreFab);
        callFuneralHomeButton.transform.GetChild(0).GetComponent<Text>().text = "Call Funeral Home";
        callFuneralHomeButton.transform.SetParent(smartPhonePanel.transform);
        callFuneralHomeButton.GetComponent<Button>().onClick.AddListener(CallFuneralHome);
        SmartPhoneButtons.Add(callFuneralHomeButton);

        smartPhoneTransform = smartPhonePanel.GetComponent<RectTransform>();
    }

    #endregion

    void Update()
    {
        // Set SmartPhone button panel to SmartPhone transform position. 
        if (smartPhonePanel != null)
        {
            var screenPoint = Camera.main.WorldToScreenPoint(this.transform.position);
            smartPhoneTransform.position = screenPoint + new Vector3(185f, 50f, 0f);
        }
    }

    public void ActivateSmartPhoneButtons()
    {
        smartPhonePanel.SetActive(!smartPhonePanel.activeSelf);

        foreach (GameObject button in SmartPhoneButtons)
        {
            button.SetActive(!button.activeSelf);
        }

        SmartPhoneButtons[0].GetComponent<Button>().Select();
    }

    #region On Button Click

    public void CallHospice()
    {
        Debug.Log("Called Hospice!!!");
    }

    public void CallFuneralHome()
    {
        Debug.Log("Called Funeral Home!!!");
    }

    #endregion
}
