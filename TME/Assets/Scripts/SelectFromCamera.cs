


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
        boards[0].text = "Starter" + "\n" + "Miso soppa" + "\n" + "KIMCHI" + "\n" + "DEEP FRIED SHRIMP WONTONS" + "\n" +
                                 "TOMYAM GONG – SPICY THAI SOUP WITH SHRIMPS" + "\n" + "TOMKA GAI – COCONUT CHICKEN SOUP";
        boards[1].text = "Main" + "\n" + "GAENG PHED RED CURRY AND COCONUT MILK" + "\n" + "GAENG KEAW WAN GREEN CURRY AND COCONUT MILK" + "\n" +
            "PAD GAPRAO STIR - FRIED WITH THAI BASIL" + "\n" + "YAKINIKU" + "\n" + "PAD MEDMAMUANG STIR - FRIED WITH CASHEW NUTS";
        boards[2].text = "Noodles and fried rice" + "\n" + "BEEF WITH RICE NOODLES SALAD" + "\n" + "PHAD THAI" + "\n" +
            "GLASS NOODLES STIR-FRIED" + "\n" + "STIR - FRIED EGG NOODLES WITH BEEF" + "\n" + "NASIGORENG – SPICY FRIED RICE";
        boards[3].text = "Nooshi" + "\n" + "LUNCH BUFFÉ–WEEKDAYS 11h-15h 118KR" + "\n" + "WEEKEND BUFFÉ 12h-20h 158KR" + "\n" + "BEEF / CHICKEN / DUCK / SHRIMPS / TOFU + VEGETABLES";
        boards[4].text = "Sushi" + "\n" + "SMALL – 8p (3 MAKI, 5 NIGIRI)" + "\n" + "MEDIUM – 10p(3 MAKI, 7 NIGIRI)"
            + "\n" + "LARGE – 12p(3 MAKI, 9 NIGIRI)" + "\n" + "CALIFORNIA ROLL – 10p" + "\n" +
            "TEMPURA ROLL – 10p" + "\n" + "POKÉ BOWL";
        boards[5].text = "Desert" + "\n" + "DEEP FRIED BANANA WITH VANILLA ICE CREAM" + "\n" + "WARM CHOCOLATE BROWNIE SERVED WITH VANILLA ICE CREAM" + "\n" +
            "FRUIT SALAD WITH VANILLA ICE CREAM";
        boards[6].text = "";


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
                            boards[0].text = "Måndag" + "\n" + "*Champinjonsoppa" + "\n" + "*Grillad Kotlett med Potatisgratäng" + "\n" + "*Mandelfisk med Äggsås" + "\n"+ "*Huset Lasagne" + "\n" + "*Vegetarisk Paj med Grönsallad";
                            boards[1].text = "Tisdag" + "\n" + "*Broccolisoppa" + "\n" + "*Grillad Kycklingfilé med Ris & Vitlökssås" + "\n" + "*Pocherad Torsk med Potatis & Grönsaker" + "\n" + "*Dagens Pasta" + "\n" + "*Vegetarisk Paj med Grönsallad";
                            boards[2].text = "Onsdag" + "\n" + "*Skaldjurssoppa toppad med Aiol" + "\n" + "*Wallenbergare med Potatispuré, Gröna Ärtor & Skirat Smör" + "\n" + "*Panerad Koljafilé med Skaldjurssås" + "\n" + "*Huset Lasagne" + "\n" + "*Vegetarisk Paj med Grönsallad";
                            boards[3].text = "Cafe Panorama" + "\n" + "Veckans lunch V. 16" + "\n" + "Lunchpris 110:-" + "\n" + "11h-17h-Måndag-Lördag";
                            boards[4].text = "Torsdag" + "\n" + "*Kantarellsoppa" + "\n" + "*Currykyckling med Ris" + "\n" + "*Pocherad Torsk med Räkor & Vitvinssås" + "\n" + "*Dagens Pasta" + "\n" + "*Vegetarisk Paj med Grönsallad";
                            boards[5].text = "Fredag" + "\n" + "*Linssoppa" + "\n" + "*Grillad Kotlettrad med Potatisgratäng" + "\n" + "*Laxfilé med Dillstuvad Potatis" + "\n" + "*Dagens Pasta" + "\n" + "*Vegetarisk Paj med Grönsallad";
                            boards[6].text = "Lördag" + "\n" + "*Fisksoppa med Aioli" + "\n" + "*Köttgryta med Ris" + "\n" + "*Fiskgryta med Ris" + "\n" + "*Huset Lasagne" + "\n" + "*Vegetarisk Paj med Grönsallad";
                        }
                        else if (current.name == "Teaterbaren")
                        {
                            boards[0].text = "ALLA DAGAR: " + "\n" + "Vegetariska soppa 102 kr" + "\n" + "Sallad med gravad lax 128 kr" + "\n" +
                                "Quinoabowl 128 kr" + "\n" + "MÅNDAG" + "\n" + "Fiskgryta" + "\n" +  "Ricottafylld cannelloni ";
                            boards[1].text = "TISDAG" + "\n" + "Bakad kalvrostbiff" + "\n" + "Shakshuka på lupinbönor" + "\n" + "ONSDAG" + "\n" +
                                "Grillad fläskkarré" + "\n" + "Indisk Korma";
                            boards[2].text = "TORSDAG" + "\n" + "Friterad kycklinglårfilé ”kentucky style”" + "\n" + "Smörstekt gnocchi med gröna bönor" + "\n" +
                                "FREDAG" + "\n" + "Steak minute, bakpotatis" + "\n" + "Kockens vegetariska val";
                            boards[3].text = "Teaterbaren" + "\n" + "Lunch Månda-Fredag 11h-14h / 128 kr" + "\n" + "Kväll & Hälg" + "\n" + "Café" + "\n" +" Bar";
                            boards[4].text = "Klassiker" + "\n" + "FISK - &SKALDJURSGRYTA 158 kr" + "\n" + "KYCKLINGBALLOTINE 165 kr" + "\n" +
                                "VEGETARISK KÅLDOLME 128 kr";
                            boards[5].text = "Helg" + "\n" + "SOPPA FRÅN SVENSKA GRÖNA GÅRDAR 102 kr" + "\n" + "HELGENS RÄTT 128 kr" + "\n" +
                                "HELGENS VEGETARISKA RÄTT 128 kr";
                            boards[6].text = "Café" + "\n" + "Ostfralla 42 kr" + "\n" + "Avokadosmörgås 68 kr" + "\n" + "Liten räksmörgås 92 kr";
                        }
                        else if (current.name == "Stories")
                        {
                            boards[0].text = "Måndag" + "\n" + "Kyckling fajitas  125:–" + "\n" + "Krämig fisk & skaldjursgryta  125:–" +
                                "\n" + "Tisdag" + "\n" + "Biff Lindström 125:–" + "\n" + "Chilibakad kolja 125:–";
                            boards[1].text = "Onsdag" + "\n" + "Spansk Chorizo med parmesanpotatispuré 125:–" + "\n" +
                                "Havets wallenbergare med potatispuré 125:–" + "\n" + "Torsdag" + "\n" +
                                "Boeuf bourguignon med potatispuré 125:–" + "\n" + "Halstrad lax 125:–";
                            boards[2].text = "Fredag" + "\n" + "Kalvfärsbiff med rostade rotfrukter 125:–" + "\n" +
                                "Sotad tonfisk med jalapeñomajonnäs 125:–" + "\n" + "Veckans Pasta" + "\n" + "Cannelloni fylld med ricotta & spenat  125:– " + "\n" +
                                "Veckans soppa" + "\n" + "Grönärtssoppa med kräftstjärtar & pepparortsgrädde";
                            boards[3].text = "Stories" + "\n" + "Måndag-Söndag 10-15" + "\n" + "Lunch Måndag-Fredag 11h-14h30" + "\n" + "Lunchen ingår salladsbuffé, kaffe/te & smulpaj";
                            boards[4].text = "SMÅTT & PLOCK" + "\n" + "Färska gröna oliver 45:–" + "\n" + "Marconamandlar  45:–" + "\n" + "Hummus med cruditéer    65:–" + "\n" +
                                "Charkbricka med grillat bröd 115:–" + "\n" + "Löjrom med lantchips 95:–" + "\n" + "Grillat surdegsbröd med ricotta, zucchini och mynta 85:–" + "\n" +
                                "Comté med kvittenmarmelad och fröknäcke 75:–" + "\n" + "Pommes frites med dipp  45:–";
                            boards[5].text = "MELLAN & STÖRRE" + "\n" + "Caesarsallad 145:–" + "\n" + "Räksallad 165:–" + "\n" +
                            "Falafelsallad 145:–" + "\n" + "Kvällens soppa med tillbehör 105:–" + "\n" +
                            "Köttbullar med potatispuré 155:–" + "\n" + "Kvällens pasta  135:–" + "\n" + "Saffrans doftande fisk och skaldjursgryta 165:–";
                            boards[6].text = "FÖR BARNEN" + "\n" + "Kalvköttbullar med potatispuré  85:–" + "\n" +
                                "Amerikanska pannkakor med sylt och grädde   75:–" + "\n" + "NÅGOT SÖTT" + "\n" + "Chokladtryffel  25:–" + "\n" + "Creme brûlée 75:–";
                        }
                        else if (current.name == "Nooshi")
                        {
                            boards[0].text = "Starter" + "\n" + "Miso soppa" + "\n" + "KIMCHI" + "\n" + "DEEP FRIED SHRIMP WONTONS" + "\n" +
                                "TOMYAM GONG – SPICY THAI SOUP WITH SHRIMPS" + "\n" + "TOMKA GAI – COCONUT CHICKEN SOUP";
                            boards[1].text = "Main" + "\n" + "GAENG PHED RED CURRY AND COCONUT MILK" + "\n" + "GAENG KEAW WAN GREEN CURRY AND COCONUT MILK" + "\n" +
                                "PAD GAPRAO STIR - FRIED WITH THAI BASIL" + "\n" + "YAKINIKU" + "\n" + "PAD MEDMAMUANG STIR - FRIED WITH CASHEW NUTS";
                            boards[2].text = "Noodles and fried rice" + "\n" +  "BEEF WITH RICE NOODLES SALAD" + "\n" + "PHAD THAI" + "\n" +
                                "GLASS NOODLES STIR-FRIED" + "\n" + "STIR - FRIED EGG NOODLES WITH BEEF" + "\n" + "NASIGORENG – SPICY FRIED RICE";
                            boards[3].text = "Nooshi" + "\n" + "LUNCH BUFFÉ–WEEKDAYS 11h-15h 118KR" + "\n" + "WEEKEND BUFFÉ 12h-20h 158KR" + "\n" + "BEEF / CHICKEN / DUCK / SHRIMPS / TOFU + VEGETABLES" ;
                            boards[4].text = "Sushi" + "\n" +  "SMALL – 8p (3 MAKI, 5 NIGIRI)" + "\n" + "MEDIUM – 10p(3 MAKI, 7 NIGIRI)"
                                + "\n" + "LARGE – 12p(3 MAKI, 9 NIGIRI)" + "\n" + "CALIFORNIA ROLL – 10p" + "\n" +
                                "TEMPURA ROLL – 10p" + "\n" + "POKÉ BOWL";
                            boards[5].text = "Desert" + "\n" +  "DEEP FRIED BANANA WITH VANILLA ICE CREAM" + "\n" + "WARM CHOCOLATE BROWNIE SERVED WITH VANILLA ICE CREAM" + "\n" +
                                "FRUIT SALAD WITH VANILLA ICE CREAM";
                            boards[6].text = "";
                        }
                        else if (current.name == "Just nu...")
                        {
                            boards[0].text = "";
                            boards[1].text = "";
                            boards[2].text = "22/04 - 23/04" + "\n" + "Boka ett cinemabiljett och vi bjuder på fika på Cafe Panorama";
                            boards[3].text = "Just nu..." + "\n" + "Ikväll 20h-24h:" + "\n" + "Chefsmästaren ??? lagar mat på Stories, boka bord och få träffa dem!";
                            boards[4].text = "25/04" + "\n" + "Boka bord på Teaterbaren och få 10% rabatt";
                            boards[5].text = "Missa inte On-spot / Spot-on på Teaterbaren!";
                            boards[6].text = "Vi planerar... stay stuned";
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
