


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

    public GameObject guest, old;

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

    

        void ChangeSelectedObject(PlacementObject selected = null)
        {
            foreach (PlacementObject current in placedObjects)
            {
              
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
                            boards[0].text = "Måndag" + "\n" + "\n" + "*Champinjonsoppa" + "\n" + "*Grillad Kotlett med Potatisgratäng" + "\n" + "*Mandelfisk med Äggsås" + "\n" + "*Huset Lasagne" + "\n" + "*Vegetarisk Paj med Grönsallad";
                            boards[1].text = "Tisdag" + "\n" + "\n" + "*Broccolisoppa" + "\n" + "*Grillad Kycklingfilé med Ris & Vitlökssås" + "\n" + "*Pocherad Torsk med Potatis & Grönsaker" + "\n" + "*Dagens Pasta" + "\n" + "*Vegetarisk Paj med Grönsallad";
                            boards[2].text = "Onsdag" + "\n" + "\n" + "*Skaldjurssoppa toppad med Aioli" + "\n" + "*Wallenbergare med Potatispuré, Gröna Ärtor & Skirat Smör" + "\n" + "*Huset Lasagne" + "\n" + "*Vegetarisk Paj med Grönsallad";
                            boards[3].text = "Cafe Panorama" + "\n" + "\n" + "Veckans lunch V. 16" + "\n" + "\n" + "Lunchpris 110:-" + "\n" + "\n" + "11h-17h Måndag-Lördag";
                            boards[4].text = "Torsdag" + "\n" + "\n" + "*Kantarellsoppa" + "\n" + "*Currykyckling med Ris" + "\n" + "*Pocherad Torsk med Räkor & Vitvinssås" + "\n" + "*Dagens Pasta" + "\n" + "*Vegetarisk Paj med Grönsallad";
                            boards[5].text = "Fredag" + "\n" + "\n" + "*Linssoppa" + "\n" + "*Grillad Kotlettrad med Potatisgratäng" + "\n" + "*Laxfilé med Dillstuvad Potatis" + "\n" + "*Dagens Pasta" + "\n" + "*Vegetarisk Paj med Grönsallad";
                            boards[6].text = "Lördag" + "\n" + "\n" + "*Fisksoppa med Aioli" + "\n" + "*Köttgryta med Ris" + "\n" + "*Fiskgryta med Ris" + "\n" + "*Huset Lasagne" + "\n" + "*Vegetarisk Paj med Grönsallad";
                        }
                        else if (current.name == "Teaterbaren")
                        {
                            boards[0].text = "Alla dagar" + "\n" + "\n" + "* Vegetariska soppa 102KR" + "\n" + "* Sallad med gravad lax 128KR" + "\n" +
                                "* Quinoabowl 128KR" + "\n" + "\n" + "Måndag" + "\n" + "\n" + "* Fiskgryta" + "\n" + "* Ricottafylld cannelloni ";
                            boards[1].text = "Tisdag" + "\n" + "\n" + "* Bakad kalvrostbiff" + "\n" + "* Shakshuka på lupinbönor" + "\n" + "\n" + "Onsdag" + "\n" + "\n" +
                                "* Grillad fläskkarré" + "\n" + "* Indisk Korma";
                            boards[2].text = "Torsdag" + "\n" + "\n" + "* Friterad kycklinglårfilé" + "\n" + "* Smörstekt gnocchi med gröna bönor" + "\n" + "\n" +
                                "Fredag" + "\n" + "\n" + "* Steak minute, bakpotatis" + "\n" + "* Kockens vegetariska val";
                            boards[3].text = "Teaterbaren" + "\n" + "\n" + "Lunch" + "\n" + "Måndag-Fredag" + "\n" + "11h-14h" + "\n" + "128 kr" + "\n" + "\n" + "Kväll & Hälg" + "\n" + "Café" + "\n" + " Bar";
                            boards[4].text = "Klassiker" + "\n" + "\n" + "* Fisk & Skaldjursgryta 158KR" + "\n" + "* Kycklingballotine 165KR" + "\n" +
                                "* Vegetarisk kåldolme 128KR";
                            boards[5].text = "Helg" + "\n" + "\n" + "* Soppa från svenska gröna gårdar 102KR" + "\n" + "* Helgens rätt 128KR" + "\n" +
                                "* Helgens vegetariska rätt 128KR";
                            boards[6].text = "Café" + "\n" + "\n" + "* Ostfralla 42KR" + "\n" + "* Avokadosmörgås 68KR" + "\n" + "* Liten räksmörgås 92KR";
                        }
                        else if (current.name == "Stories")
                        {
                            boards[0].text = "Måndag" + "\n" + "\n" + "*Kyckling fajitas  125:–" + "\n" + "*Krämig fisk & skaldjursgryta  125:–" +
                                 "\n" + "\n" + "Tisdag" + "\n" + "\n" + "*Biff Lindström 125:–" + "\n" + "*Chilibakad kolja 125:–";
                            boards[1].text = "Onsdag" + "\n" + "\n" + "*Spansk Chorizo med potatispuré 125:–" + "\n" +
                                "*Havets wallenbergare 125:–" + "\n" + "\n" + "Torsdag" + "\n" + "\n" +
                                "*Boeuf bourguignon 125:–" + "\n" + "*Halstrad lax 125:–";
                            boards[2].text = "Fredag" + "\n" + "\n" + "*Kalvfärsbiff 125:–" + "\n" +
                                "*Sotad tonfisk 125:–" + "\n" + "\n" + "Veckans Pasta" + "\n" + "*Cannelloni fylld med ricotta & spenat  125:– " + "\n" + "\n" +
                                "Veckans soppa" + "\n" + "*Grönärtssoppa med kräftstjärtar";
                            boards[3].text = "Stories" + "\n" + "\n" + "Måndag-Söndag" + "\n" + "10-15" + "\n" + "\n" + "Lunch" + "\n" + "Måndag -Fredag" + "\n" + "11h-14h30" + "\n" + "\n" + "Lunchen ingår salladsbuffé, kaffe/te & smulpaj";
                            boards[4].text = "Smått & Plock" + "\n" + "\n" + "*Färska gröna oliver 45:–" + "\n" + "*Marconamandlar 45:–" + "\n" + "*Hummus med cruditéer 65:–" + "\n" +
                                "*Charkbricka med grillat bröd 115:–" + "\n" + "*Löjrom med lantchips 95:–";
                            boards[5].text = "Mellan & Större" + "\n" + "\n" + "*Caesarsallad 145:–" + "\n" + "*Räksallad 165:–" + "\n" +
                            "*Falafelsallad 145:–" + "\n" + "*Kvällens soppa med tillbehör 105:–" + "\n" +
                            "*Köttbullar med potatispuré 155:–" + "\n" + "*Kvällens pasta  135:–";
                            boards[6].text = "För barnen" + "\n" + "\n" + "*Kalvköttbullar med potatispuré  85:–" + "\n" +
                                "*Amerikanska pannkakor med sylt & grädde   75:–" + "\n" + "\n" + "Något sött" + "\n" + "\n" + "*Chokladtryffel  25:–" + "\n" + "*Creme brûlée 75:–";
                        }
                        else if (current.name == "Nooshi")
                        {
                            boards[0].text = "Starter" + "\n" + "\n" + "* Miso soppa" + "\n" + "* Kimchi" + "\n" + "* Deep fried shrimp wontons" + "\n" +
                                 "* Tomyam gong - Spicy soup with shrimps" + "\n" + "* Tomka gai – Coconut chicken soup";
                            boards[1].text = "Main" + "\n" + "\n" + "* Gaeng phed - Red curry & coconut milk" + "\n" + "* Gaeng keaw wan - Green curry & coconut milk" + "\n" +
                                "* Pad gaprao - Stir-fry & thai basil" + "\n" + "* Yakiniku" + "\n" + "* Pad medmamuang - Stir-fry & cashew nuts";
                            boards[2].text = "Noodles and fried rice" + "\n" + "\n" + "* Beef & rice noodles salad" + "\n" + "* Phad thai" + "\n" +
                                "* Glass noodles stir-fry" + "\n" + "* Stir-fried egg noodles with beef" + "\n" + "* Nasigoreng – Spicy fried rice";
                            boards[3].text = "Nooshi" + "\n" + "\n" + "* Lunch buffé–Weekdays 11h-15h" + "\n" + "118KR" + "\n" + "\n" + "* Week-end buffé 12h-20h" + "\n" + "158KR";
                            boards[4].text = "Sushi" + "\n" + "\n" + "* Small–8p (3 Maki, 5 Nigiri)" + "\n" + "* Medium–10p(3 Maki, 7 Nigiri)"
                                + "\n" + "* Large–12p(3 Maki, 9 Nigiri)" + "\n" + "* California roll–10p" + "\n" + "* Temura rool–10p" + "\n" + "* Poké bowl";
                            boards[5].text = "Desert" + "\n" + "\n" + "* Deep fried banana & vanilla ice-cream" + "\n" + "* Warm chocolate & vanilla ice-cream" + "\n" +
                                "* Fruit salad & vanilla ice-cream";
                            boards[6].text = "";
                        }
                        else if (current.name == "Just nu...")
                        {
                            boards[0].text = "22/04 - 23/04" + "\n" + "\n" + "Boka ett cinemabiljett och vi bjuder på fika på Cafe Panorama";
                            boards[1].text = "28/04" + "\n" + "\n" + "20h-24h: " + "\n" + "Vår gästkock lagar mat på Teaterbaren, boka bord och vinn en matlagningslektion";
                            boards[2].text = "30/04" + "\n" + "\n" + "Boka bord på Stories och få 10% rabatt";
                            boards[3].text = "Just nu" + "\n" + "\n" + "Boka bord hos oss och vinn ett förkläde i sammarbete med... " + "\n" + "\n" + "+ Missa inte On-spot/Spot-on som på Stories och Cafe Panorama!";
                            boards[4].text = "06/05" + "\n" + "\n" + "Boka bord på Nooshi och kanske vinn en sushi-matlagningskurs";
                            boards[5].text = "Nästa vecka" + "\n" + "\n" + "Vi har en ny gästkock, stay tuned...";
                            boards[6].text = "";
                            //old.SetActive(true);
                            boards[7].text = "You missed that... but check our main board and see what's up now!";
                            //guest.SetActive(true);
                        }
                        
                        current.transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);                                             
                    }
                    
                }                
            }
        }
    }
}
