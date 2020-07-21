using UnityEngine;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] public GameObject InteractMenu;
    [SerializeField] private Material hightLightMaterial;
    [SerializeField] private Material defaultMaterial;
    [SerializeField] private GameObject selectedObjectNamePanel;
    [SerializeField] private GameObject selectObjectNameText; 
    [SerializeField] private string selectableTag = "Selectable";

    private Transform _selection; 

    private void Update()
    {
        if (_selection != null)
        {
            var selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.material = defaultMaterial;

            // Remove selected object's name. 
            selectObjectNameText.GetComponent<Text>().text = null;
            selectedObjectNamePanel.SetActive(false);

            _selection = null;
        }

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            var selection = hit.transform;
            if (selection.CompareTag(selectableTag))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();

                // Display selected object name. 
                var hoverOutput = selection.GetComponent<IInteractable>().Hover();

                selectedObjectNamePanel.SetActive(true);
                selectObjectNameText.GetComponent<Text>().text = hoverOutput.ObjectName;

                if (selectionRenderer != null)
                {
                    selectionRenderer.material = hightLightMaterial;

                    // If Left Mouse Button clicked.
                    if (Input.GetMouseButtonDown(0))
                    {
                        var selectedObject = selection.GetComponent<IInteractable>().Interact();
                    }
                }

                _selection = selection;
            }
        }
    }
}
