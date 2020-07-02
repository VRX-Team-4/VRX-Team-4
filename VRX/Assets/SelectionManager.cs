using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] private Material hightLightMaterial;
    [SerializeField] private Material defaultMaterial;
    [SerializeField] private GameObject selectObjectNameText; 
    [SerializeField] private string selectableTag = "Selectable";

    private Transform _selection; 

    // Update is called once per frame
    private void Update()
    {
        if (_selection != null)
        {
            var selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.material = defaultMaterial;
            
            _selection = null;
        }
        
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)) 
        {
            var selection = hit.transform;
            if (selection.CompareTag(selectableTag)) 
            {
                var selectionRenderer = selection.GetComponent<Renderer>();

                if (selectionRenderer != null)
                {
                    selectionRenderer.material = hightLightMaterial;

                    // If Left Mouse Button clicked.
                    if (Input.GetMouseButtonDown(0))
                    {
                        var selectedObject = selection.GetComponent<IInteractable>();
                        
                        selectObjectNameText.GetComponent<Text>().text = selectedObject.Interact();
                    }
                }

                _selection = selection;
            }
        }
    }
}
