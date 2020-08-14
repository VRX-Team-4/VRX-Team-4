using UnityEngine;

public class UpperRailing : MonoBehaviour, IInteractable
{
    [SerializeField] public string ObjectName; 
    [SerializeField] public GameObject Hinge_01;
    [SerializeField] public GameObject Hinge_02;

    // Start is called before the first frame update
    void Start()
    {
        
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

    #endregion

    #region On Interact

    public InteractionOutput Interact()
    {
        LowerRailing();
        LowerHinge_01();
        LowerHinge_02();

        return new InteractionOutput
        {
            ObjectName = ObjectName,
        };
    }

    #endregion

    #region Animations

    public void LowerRailing()
    {
        Animator animator = this.GetComponent<Animator>();

        if (animator != null)
        {
            bool shouldLower = animator.GetBool("Lower");

            animator.SetBool("Lower", !shouldLower);
        }
    }

    public void LowerHinge_01()
    {
        Animator animator = Hinge_01.GetComponent<Animator>();

        if (animator != null)
        {
            bool shouldLower = animator.GetBool("Lower");

            animator.SetBool("Lower", !shouldLower);
        }
    }

    public void LowerHinge_02()
    {
        Animator animator = Hinge_02.GetComponent<Animator>();

        if (animator != null)
        {
            bool shouldLower = animator.GetBool("Lower");

            animator.SetBool("Lower", !shouldLower);
        }
    }

    #endregion
}
