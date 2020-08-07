using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] public GameObject smartPhone;
    [SerializeField] public KeyCode SmartPhoneKey;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(SmartPhoneKey))
        {
            RaiseSmartPhone();

            smartPhone.GetComponent<SmartPhone>().ActivateSmartPhoneButtons();
        }
    }

    // Calls raise/lower SmartPhone animation. 
    public void RaiseSmartPhone()
    {
        
        Animator animator = smartPhone.GetComponent<Animator>();

        if (animator != null)
        {
            bool shouldRaise = animator.GetBool("Raise");

            animator.SetBool("Raise", !shouldRaise);
        }
    }
}
