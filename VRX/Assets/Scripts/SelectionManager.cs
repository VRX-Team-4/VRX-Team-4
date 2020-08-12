using UnityEngine;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{
    //[SerializeField] private Material hightLightMaterial;
    //[SerializeField] private Material defaultMaterial;
    [SerializeField] private GameObject selectedObjectNamePanel;
    [SerializeField] private GameObject selectObjectNameText;
    [SerializeField] private GameObject interactionOutputText;
    [SerializeField] private string selectableTag = "Selectable";

    [SerializeField] private GameObject stethoscope;

    private Transform selectedObject;
    private Text outputText;
    private bool shouldDisplayOutputText;

    private void Start()
    {
        outputText = interactionOutputText.GetComponent<Text>();
    }

    private void Update()
    {
        // When cursor is not hovering over selectable object. 
        if (selectedObject != null && selectedObject.CompareTag(selectableTag))
        {
            var selectionRenderer = selectedObject.GetComponent<Renderer>();
            //selectionRenderer.material = defaultMaterial;

            // Remove selected object's name. 
            selectObjectNameText.GetComponent<Text>().text = null;
            selectedObjectNamePanel.SetActive(false);

            shouldDisplayOutputText = true;
            outputText.text = null;
            selectedObject = null;
        }

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // When cursor is hovering over selectable object. 
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            selectedObject = hit.transform;

            if (selectedObject.CompareTag(selectableTag))
            {
                var selectionRenderer = selectedObject.GetComponent<Renderer>();

                // Display selected object name. 
                var hoverOutput = selectedObject.GetComponent<IInteractable>().Hover();

                selectedObjectNamePanel.SetActive(true);
                selectObjectNameText.GetComponent<Text>().text = hoverOutput.ObjectName;

                if (selectionRenderer != null)
                {
                    //selectionRenderer.material = hightLightMaterial;

                    // If Left Mouse Button clicked.
                    if (Input.GetMouseButtonDown(0))
                    {
                        var interactionOutput = selectedObject.GetComponent<IInteractable>().Interact();
                    }
                }
            }

            // Get IPerson component if present from selectedObject.
            var person = selectedObject.GetComponent<IPerson>();

            // Check if person is alive if person is not null. 
            if (person != null)
            {
                if (stethoscope.GetComponent<Stethoscope>().IsBeingUsed && shouldDisplayOutputText)
                { 
                    outputText.text = person.IsAlive() ? "You detect a heart beat!!!" : "You do not detect a heart beat!!!";
                }

                // Do not try to set outputText with every Update. Only set once. 
                shouldDisplayOutputText = false;
            }
        }
    }

    //private void Update()
    //{
    //    if (_selection != null)
    //    {
    //        var selectionRenderer = _selection.GetComponent<Renderer>();
    //        selectionRenderer.material = defaultMaterial;

    //        // Remove selected object's name. 
    //        selectObjectNameText.GetComponent<Text>().text = null;
    //        selectedObjectNamePanel.SetActive(false);

    //        _selection = null;
    //    }

    //    var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

    //    if (Physics.Raycast(ray, out RaycastHit hit))
    //    {
    //        var selection = hit.transform;
    //        if (selection.CompareTag(selectableTag))
    //        {
    //            var selectionRenderer = selection.GetComponent<Renderer>();

    //            // Display selected object name. 
    //            var hoverOutput = selection.GetComponent<IInteractable>().Hover();

    //            selectedObjectNamePanel.SetActive(true);
    //            selectObjectNameText.GetComponent<Text>().text = hoverOutput.ObjectName;

    //            if (selectionRenderer != null)
    //            {
    //                selectionRenderer.material = hightLightMaterial;

    //                // If Left Mouse Button clicked.
    //                if (Input.GetMouseButtonDown(0))
    //                {
    //                    var selectedObject = selection.GetComponent<IInteractable>().Interact();
    //                }
    //            }

    //            _selection = selection;
    //        }
    //    }
    //}
}
