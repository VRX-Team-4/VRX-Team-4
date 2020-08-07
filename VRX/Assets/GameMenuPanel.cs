using UnityEngine;
using UnityEngine.UI;

public class GameMenuPanel : MonoBehaviour
{
    [SerializeField] public GameObject InventoryPanel;
    [SerializeField] public KeyCode InventoryKey;

    public GameObject ButtonPreFab;

    private GameObject inventoryButton; 

    void Start()
    {
        inventoryButton = Instantiate(ButtonPreFab);
        inventoryButton.transform.GetChild(0).GetComponent<Text>().text = "Inventory [" + InventoryKey.ToString() + "]";
        inventoryButton.transform.GetComponent<Button>().onClick.AddListener(OpenInventoryPanel);

        inventoryButton.transform.SetParent(this.transform);
        inventoryButton.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(InventoryKey))
        {
            inventoryButton.transform.GetComponent<Button>().onClick.Invoke();
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

