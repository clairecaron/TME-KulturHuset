


using System.Collections.Generic;
using UnityEngine.XR.ARFoundation;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARSubsystems;
using TMPro;

public class SelectFromCamera : MonoBehaviour
{
    public TMP_Text text, text2;
    public int state;
        

    [SerializeField]
    private PlacementObject[] placedObjects;

    [SerializeField]
    private Color activeColor = Color.red;

    [SerializeField]
    private Color inactiveColor = Color.gray;

    public GameObject guest, book, old;

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
                    if (placementObject.name == "BookIn")
                    {
                        SetBook();
                    }
                    if (placementObject != null)
                    {
                        ChangeSelectedObject(placementObject);
                    }           
                }
                else
                {
                    foreach (PlacementObject p in placedObjects)
                    {
                        if (p.name != "BookIn" && p.name != "BookOut")
                        {
                        p.IsSelected = false;
                        MeshRenderer meshRenderer = p.GetComponent<MeshRenderer>();
                        meshRenderer.material.color = inactiveColor;
                        p.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                        }
                    }
                }

            }
        }

        void SetBook()
        {
            if (book.active)
            {
                book.SetActive(false);
            }
            else
            {
                book.SetActive(true);
            }
           
        }

        void ChangeSelectedObject(PlacementObject selected = null)
        {
            foreach (PlacementObject current in placedObjects)
            {
               
                if (current.name == "BookOut")
                {
                    book.SetActive(false);
                }
                if (current.name != "BookIn" && current.name != "BookOut")
                {
                    MeshRenderer meshRenderer = current.GetComponent<MeshRenderer>();
                    if (selected != current)
                    {
                        current.IsSelected = false;
                        meshRenderer.material.color = inactiveColor;
                        current.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                    }
                    else
                    {
                        current.IsSelected = true;
                        meshRenderer.material.color = activeColor;
                        string t = "";
                        if (current.name == "Cafe Panorama")
                        {
                            t = "Cafe Panorama";
                        }
                        else if (current.name == "Teaterbaren")
                        {
                            t = "Teaterbaren";
                        }
                        else if (current.name == "Stories")
                        {
                            t = "Stories";
                        }
                        else if (current.name == "Nooshi")
                        {
                            t = "Nooshi";
                        }
                        else if (current.name == "Just nu...")
                        {
                            t = "Right now... on top of our amazing menus, meet ???Chef with 10% off + Book it and maybe win a samarbete tote bag KULTURHUSET X ???CHEF. But you only have until the 25th of April, after that they leave, damn...";
                            guest.SetActive(true);
                        }
                        else if (current.name == "Old")
                        {
                            t = "Click on something to check our menus <3";
                            old.SetActive(true);
                            text2.text = "You missed that... but check our main board and see what's up now! <3";
                        }
                        text.text = t;
                        current.transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);                                             
                    }
                    
                }                
            }
        }
    }
}
