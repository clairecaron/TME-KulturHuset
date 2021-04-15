


  
using UnityEngine;
using UnityEngine.UI;

public class SelectFromCamera : MonoBehaviour
{


    [SerializeField]
    private PlacementObject[] placedObjects;

    [SerializeField]
    private Color activeColor = Color.red;

    [SerializeField]
    private Color inactiveColor = Color.gray;

  

    [SerializeField]
    private Camera arCamera;

    private Vector2 touchPosition = default;

    [SerializeField]
    private bool displayOverlay = false;

    [SerializeField]
    private float rayDistanceFromCamera = 10.0f;

    [SerializeField]
    private float generateRayAfterSeconds = 2.0f;

    private float rayTimer = 0;

    [SerializeField]
    private GameObject selector;

   
    void Start() => ChangeSelectedObject(placedObjects[0]);



    void Update()
    {
      

        if (generateRayAfterSeconds <= rayTimer)
        {
            // creates a ray from the screen point origin 
            Ray ray = arCamera.ScreenPointToRay(selector.transform.position);

            RaycastHit hitObject;
            if (Physics.Raycast(ray, out hitObject, rayDistanceFromCamera))
            {
                PlacementObject placementObject = hitObject.transform.GetComponent<PlacementObject>();
                if (placementObject != null)
                {
                    ChangeSelectedObject(placementObject);
                }
            }
            else
            {
                ChangeSelectedObject();
            }

            rayTimer = 0;
        }
        else
        {
            rayTimer += Time.deltaTime * 1.0f;
        }
    }

    void ChangeSelectedObject(PlacementObject selected = null)
    {
        foreach (PlacementObject current in placedObjects)
        {
            MeshRenderer meshRenderer = current.GetComponent<MeshRenderer>();
            if (selected != current)
            {
                current.Selected = false;
                meshRenderer.material.color = inactiveColor;
            }
            else
            {
                current.Selected = true;
                meshRenderer.material.color = activeColor;
            }

            if (displayOverlay)
                current.ToggleOverlay();
        }
    }
}
