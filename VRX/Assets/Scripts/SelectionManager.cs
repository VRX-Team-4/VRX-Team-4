using UnityEngine;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{
    //[SerializeField] private Material hightLightMaterial;
    //[SerializeField] private Material defaultMaterial;
    [SerializeField] private GameObject selectedObjectNamePanel;
    [SerializeField] private GameObject selectObjectNameText; 
    [SerializeField] private string selectableTag = "Selectable";

    private Transform selectedObject;

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
