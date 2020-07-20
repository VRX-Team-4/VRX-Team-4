using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] public GameObject InteractMenu;
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
            selectObjectNameText.GetComponent<Text>().text = null;

            _selection = null;
        }

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            var selection = hit.transform;
            if (selection.CompareTag(selectableTag))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();

                if (selectionRenderer != null)
                {
                    //var selectedObject = selection.GetComponent<IInteractable>().Interact();

                    selectionRenderer.material = hightLightMaterial;
                    //selectObjectNameText.GetComponent<Text>().text = selectedObject.ObjectName;

                    // If Left Mouse Button clicked.
                    if (Input.GetMouseButtonDown(0))
                    {
                        //InteractMenu.SetActive(true);

                        var selectedObject = selection.GetComponent<IInteractable>().Interact();

                        //selectedObject.InteractionManuPanel.SetActive(true);
                        //Debug.Log(selectedObject.InteractMenuOptionButtons.Count);
                        //foreach (var menuOption in selectedObject.InteractMenuOptionButtons)
                        //{
                        //    menuOption.transform.SetParent(InteractMenu.transform);
                        //}

                        ////InteractMenu.transform.GetChild(0).GetComponent<Button>().Select();

                        //selectedObject.InteractMenuOptionButtons[0].GetComponent<Button>().Select();
                    }
                }

                _selection = selection;
            }
        }
    }
}
