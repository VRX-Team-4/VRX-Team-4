using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogText : MonoBehaviour
{
    public Text OutputText;

    // Start is called before the first frame update
    void Start()
    {
        OutputText.text = "Enter the house, and approach the family member";
    }

    public void FamilyMemberDialog(string dialog)
    {
        OutputText.text = "Family Member: " + dialog;
    }
}
