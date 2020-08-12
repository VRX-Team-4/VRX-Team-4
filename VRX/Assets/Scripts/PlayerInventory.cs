using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] public GameObject smartPhone;
    [SerializeField] public KeyCode SmartPhoneKey;

    [SerializeField] public GameObject stethoscope;
    [SerializeField] public KeyCode StethoscopeKey;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(SmartPhoneKey))
        {
            RaiseSmartPhone();

            smartPhone.GetComponent<SmartPhone>().ActivateSmartPhoneButtons();
        }

        if (Input.GetKeyDown(StethoscopeKey))
        {
            stethoscope.GetComponent<Stethoscope>().UseStethoscope();

            RaiseStethoscope();
        }
    }

    #region Animations

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

    // Calls raise/lower Stethoscope animation.
    public void RaiseStethoscope()
    {
        Animator animator = stethoscope.GetComponent<Animator>();

        if (animator != null)
        {
            bool shouldRaise = animator.GetBool("Raise");

            animator.SetBool("Raise", !shouldRaise);
        }
    }

    #endregion
}
