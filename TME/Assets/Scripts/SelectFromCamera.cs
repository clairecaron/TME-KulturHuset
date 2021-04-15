


using System.Collections.Generic;
using UnityEngine.XR.ARFoundation;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARSubsystems;

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


    //void Start() => ChangeSelectedObject(placedObjects[0]);



    void Update()
    {

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            touchPosition = touch.position;
            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = arCamera.ScreenPointToRay(touch.position);
                RaycastHit hitObject;
                if (Physics.Raycast(ray, out hitObject))
                {
                    PlacementObject placementObject = hitObject.transform.GetComponent<PlacementObject>();
                    if (placementObject != null)
                    {
                        ChangeSelectedObject(placementObject);
                    }

                }

            }
        }

        void ChangeSelectedObject(PlacementObject selected = null)
        {
            foreach (PlacementObject current in placedObjects)
            {
                MeshRenderer meshRenderer = current.GetComponent<MeshRenderer>();
                if (selected != current)
                {
                    current.IsSelected = false;
                    meshRenderer.material.color = inactiveColor;
                }
                else
                {
                    current.IsSelected = true;
                    meshRenderer.material.color = activeColor;
                }

               
            }
        }
    }
}
