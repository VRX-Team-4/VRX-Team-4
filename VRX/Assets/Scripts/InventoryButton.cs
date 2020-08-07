using UnityEngine;
using UnityEngine.UI;

public class InventoryButton : MonoBehaviour
{
    [SerializeField] public GameObject InventoryPanel;
    [SerializeField] public KeyCode Key;

    void Start()
    {
        transform.GetChild(0).GetComponent<Text>().text = "Inventory [" + Key + "]";
        transform.GetComponent<Button>().onClick.AddListener(OpenInventoryPanel);
    }

    void Update()
    {
        if (Input.GetKeyDown(Key))
        {
            transform.GetComponent<Button>().onClick.Invoke();
        }
    }

    public void OpenInventoryPanel() 
    {
        if (InventoryPanel != null)
        {
            Animator animator = InventoryPanel.GetComponent<Animator>();

            if (animator != null)
            {
                bool isOpen = animator.GetBool("Open");

                animator.SetBool("Open", !isOpen);
            }
        }
    }
}
