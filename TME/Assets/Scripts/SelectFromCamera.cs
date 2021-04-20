


using System.Collections.Generic;
using UnityEngine.XR.ARFoundation;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARSubsystems;
using TMPro;

public class SelectFromCamera : MonoBehaviour
{
    public TMP_Text[] boards;

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

    //private bool displayOverlay = false;    
    //private float rayDistanceFromCamera = 10.0f; 
    //private float generateRayAfterSeconds = 2.0f;
    //private float rayTimer = 0;

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
                        if (current.name == "Cafe Panorama")
                        {
                            boards[0].text = "M�ndag" + "\n" + "*Champinjonsoppa" + "\n" + "*Grillad Kotlett med Potatisgrat�ng" + "\n" + "*Mandelfisk med �ggs�s" + "\n"+ "*Huset Lasagne" + "\n" + "*Vegetarisk Paj med Gr�nsallad";
                            boards[1].text = "Tisdag" + "\n" + "*Broccolisoppa" + "\n" + "*Grillad Kycklingfil� med Ris & Vitl�kss�s" + "\n" + "*Pocherad Torsk med Potatis & Gr�nsaker" + "\n" + "*Dagens Pasta" + "\n" + "*Vegetarisk Paj med Gr�nsallad";
                            boards[2].text = "Onsdag" + "\n" + "*Skaldjurssoppa toppad med Aiol" + "\n" + "*Wallenbergare med Potatispur�, Gr�na �rtor & Skirat Sm�r" + "\n" + "*Panerad Koljafil� med Skaldjurss�s" + "\n" + "*Huset Lasagne" + "\n" + "*Vegetarisk Paj med Gr�nsallad";
                            boards[3].text = "Cafe Panorama" + "\n" + "Veckans lunch V. 16" + "\n" + "Lunchpris 110:-" + "\n" + "11h-17h-M�ndag-L�rdag";
                            boards[4].text = "Torsdag" + "\n" + "*Kantarellsoppa" + "\n" + "*Currykyckling med Ris" + "\n" + "*Pocherad Torsk med R�kor & Vitvinss�s" + "\n" + "*Dagens Pasta" + "\n" + "*Vegetarisk Paj med Gr�nsallad";
                            boards[5].text = "Fredag" + "\n" + "*Linssoppa" + "\n" + "*Grillad Kotlettrad med Potatisgrat�ng" + "\n" + "*Laxfil� med Dillstuvad Potatis" + "\n" + "*Dagens Pasta" + "\n" + "*Vegetarisk Paj med Gr�nsallad";
                            boards[6].text = "L�rdag" + "\n" + "*Fisksoppa med Aioli" + "\n" + "*K�ttgryta med Ris" + "\n" + "*Fiskgryta med Ris" + "\n" + "*Huset Lasagne" + "\n" + "*Vegetarisk Paj med Gr�nsallad";
                        }
                        else if (current.name == "Teaterbaren")
                        {
                            boards[0].text = "M�ndag";
                            boards[1].text = "Tisdag";
                            boards[2].text = "Onsdag";
                            boards[3].text = "Teaterbaren";
                            boards[4].text = "Torsdag";
                            boards[5].text = "Fredag";
                            boards[6].text = "Helg";
                        }
                        else if (current.name == "Stories")
                        {
                            boards[0].text = "M�ndag";
                            boards[1].text = "Tisdag";
                            boards[2].text = "Onsdag";
                            boards[3].text = "Stories";
                            boards[4].text = "Torsdag";
                            boards[5].text = "Fredag";
                            boards[6].text = "Helg";
                        }
                        else if (current.name == "Nooshi")
                        {
                            boards[0].text = "Starter";
                            boards[1].text = "Main";
                            boards[2].text = "Noodles and fried rice";
                            boards[3].text = "Nooshi";
                            boards[4].text = "Sushi";
                            boards[5].text = "Desert";
                            boards[6].text = "";
                        }
                        else if (current.name == "Just nu...")
                        {
                            boards[0].text = "";
                            boards[1].text = "";
                            boards[2].text = "22/04 - 23/04" + "\n" + "Boka ett cinemabiljett och vi bjuder p� fika p� Cafe Panorama";
                            boards[3].text = "Just nu..." + "\n" + "Ikv�ll 20h-24h:" + "\n" + "Chefsm�staren ??? lagar mat p� Stories, boka bord och f� tr�ffa dem!";
                            boards[4].text = "25/04" + "\n" + "Boka bord p� Teaterbaren och f� 10% rabatt";
                            boards[5].text = "Vi planerar... stay stuned";
                            boards[6].text = "";
                            guest.SetActive(true);
                        }
                        else if (current.name == "Old")
                        {
                            old.SetActive(true);
                            boards[7].text = "You missed that... but check our main board and see what's up now!";
                        }
                        current.transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);                                             
                    }
                    
                }                
            }
        }
    }
}
