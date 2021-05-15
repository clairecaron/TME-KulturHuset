


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
                            boards[0].text = "M�ndag" + "\n" + "\n" + "*Champinjonsoppa" + "\n" + "*Grillad Kotlett med Potatisgrat�ng" + "\n" + "*Mandelfisk med �ggs�s" + "\n" + "*Huset Lasagne" + "\n" + "*Vegetarisk Paj med Gr�nsallad";
                            boards[1].text = "Tisdag" + "\n" + "\n" + "*Broccolisoppa" + "\n" + "*Grillad Kycklingfil� med Ris & Vitl�kss�s" + "\n" + "*Pocherad Torsk med Potatis & Gr�nsaker" + "\n" + "*Dagens Pasta" + "\n" + "*Vegetarisk Paj med Gr�nsallad";
                            boards[2].text = "Onsdag" + "\n" + "\n" + "*Skaldjurssoppa toppad med Aioli" + "\n" + "*Wallenbergare med Potatispur�, Gr�na �rtor & Skirat Sm�r" + "\n" + "*Huset Lasagne" + "\n" + "*Vegetarisk Paj med Gr�nsallad";
                            boards[3].text = "Cafe Panorama" + "\n" + "\n" + "Veckans lunch V. 16" + "\n" + "\n" + "Lunchpris 110:-" + "\n" + "\n" + "11h-17h M�ndag-L�rdag";
                            boards[4].text = "Torsdag" + "\n" + "\n" + "*Kantarellsoppa" + "\n" + "*Currykyckling med Ris" + "\n" + "*Pocherad Torsk med R�kor & Vitvinss�s" + "\n" + "*Dagens Pasta" + "\n" + "*Vegetarisk Paj med Gr�nsallad";
                            boards[5].text = "Fredag" + "\n" + "\n" + "*Linssoppa" + "\n" + "*Grillad Kotlettrad med Potatisgrat�ng" + "\n" + "*Laxfil� med Dillstuvad Potatis" + "\n" + "*Dagens Pasta" + "\n" + "*Vegetarisk Paj med Gr�nsallad";
                            boards[6].text = "L�rdag" + "\n" + "\n" + "*Fisksoppa med Aioli" + "\n" + "*K�ttgryta med Ris" + "\n" + "*Fiskgryta med Ris" + "\n" + "*Huset Lasagne" + "\n" + "*Vegetarisk Paj med Gr�nsallad";
                        }
                        else if (current.name == "Teaterbaren")
                        {
                            boards[0].text = "Alla dagar" + "\n" + "\n" + "* Vegetariska soppa 102KR" + "\n" + "* Sallad med gravad lax 128KR" + "\n" +
                                "* Quinoabowl 128KR" + "\n" + "\n" + "M�ndag" + "\n" + "\n" + "* Fiskgryta" + "\n" + "* Ricottafylld cannelloni ";
                            boards[1].text = "Tisdag" + "\n" + "\n" + "* Bakad kalvrostbiff" + "\n" + "* Shakshuka p� lupinb�nor" + "\n" + "\n" + "Onsdag" + "\n" + "\n" +
                                "* Grillad fl�skkarr�" + "\n" + "* Indisk Korma";
                            boards[2].text = "Torsdag" + "\n" + "\n" + "* Friterad kycklingl�rfil�" + "\n" + "* Sm�rstekt gnocchi med gr�na b�nor" + "\n" + "\n" +
                                "Fredag" + "\n" + "\n" + "* Steak minute, bakpotatis" + "\n" + "* Kockens vegetariska val";
                            boards[3].text = "Teaterbaren" + "\n" + "\n" + "Lunch" + "\n" + "M�ndag-Fredag" + "\n" + "11h-14h" + "\n" + "128 kr" + "\n" + "\n" + "Kv�ll & H�lg" + "\n" + "Caf�" + "\n" + " Bar";
                            boards[4].text = "Klassiker" + "\n" + "\n" + "* Fisk & Skaldjursgryta 158KR" + "\n" + "* Kycklingballotine 165KR" + "\n" +
                                "* Vegetarisk k�ldolme 128KR";
                            boards[5].text = "Helg" + "\n" + "\n" + "* Soppa fr�n svenska gr�na g�rdar 102KR" + "\n" + "* Helgens r�tt 128KR" + "\n" +
                                "* Helgens vegetariska r�tt 128KR";
                            boards[6].text = "Caf�" + "\n" + "\n" + "* Ostfralla 42KR" + "\n" + "* Avokadosm�rg�s 68KR" + "\n" + "* Liten r�ksm�rg�s 92KR";
                        }
                        else if (current.name == "Stories")
                        {
                            boards[0].text = "M�ndag" + "\n" + "\n" + "*Kyckling fajitas  125:�" + "\n" + "*Kr�mig fisk & skaldjursgryta  125:�" +
                                 "\n" + "\n" + "Tisdag" + "\n" + "\n" + "*Biff Lindstr�m 125:�" + "\n" + "*Chilibakad kolja 125:�";
                            boards[1].text = "Onsdag" + "\n" + "\n" + "*Spansk Chorizo med potatispur� 125:�" + "\n" +
                                "*Havets wallenbergare 125:�" + "\n" + "\n" + "Torsdag" + "\n" + "\n" +
                                "*Boeuf bourguignon 125:�" + "\n" + "*Halstrad lax 125:�";
                            boards[2].text = "Fredag" + "\n" + "\n" + "*Kalvf�rsbiff 125:�" + "\n" +
                                "*Sotad tonfisk 125:�" + "\n" + "\n" + "Veckans Pasta" + "\n" + "*Cannelloni fylld med ricotta & spenat  125:� " + "\n" + "\n" +
                                "Veckans soppa" + "\n" + "*Gr�n�rtssoppa med kr�ftstj�rtar";
                            boards[3].text = "Stories" + "\n" + "\n" + "M�ndag-S�ndag" + "\n" + "10-15" + "\n" + "\n" + "Lunch" + "\n" + "M�ndag -Fredag" + "\n" + "11h-14h30" + "\n" + "\n" + "Lunchen ing�r salladsbuff�, kaffe/te & smulpaj";
                            boards[4].text = "Sm�tt & Plock" + "\n" + "\n" + "*F�rska gr�na oliver 45:�" + "\n" + "*Marconamandlar 45:�" + "\n" + "*Hummus med crudit�er 65:�" + "\n" +
                                "*Charkbricka med grillat br�d 115:�" + "\n" + "*L�jrom med lantchips 95:�";
                            boards[5].text = "Mellan & St�rre" + "\n" + "\n" + "*Caesarsallad 145:�" + "\n" + "*R�ksallad 165:�" + "\n" +
                            "*Falafelsallad 145:�" + "\n" + "*Kv�llens soppa med tillbeh�r 105:�" + "\n" +
                            "*K�ttbullar med potatispur� 155:�" + "\n" + "*Kv�llens pasta  135:�";
                            boards[6].text = "F�r barnen" + "\n" + "\n" + "*Kalvk�ttbullar med potatispur�  85:�" + "\n" +
                                "*Amerikanska pannkakor med sylt & gr�dde   75:�" + "\n" + "\n" + "N�got s�tt" + "\n" + "\n" + "*Chokladtryffel  25:�" + "\n" + "*Creme br�l�e 75:�";
                        }
                        else if (current.name == "Nooshi")
                        {
                            boards[0].text = "Starter" + "\n" + "\n" + "* Miso soppa" + "\n" + "* Kimchi" + "\n" + "* Deep fried shrimp wontons" + "\n" +
                                 "* Tomyam gong - Spicy soup with shrimps" + "\n" + "* Tomka gai � Coconut chicken soup";
                            boards[1].text = "Main" + "\n" + "\n" + "* Gaeng phed - Red curry & coconut milk" + "\n" + "* Gaeng keaw wan - Green curry & coconut milk" + "\n" +
                                "* Pad gaprao - Stir-fry & thai basil" + "\n" + "* Yakiniku" + "\n" + "* Pad medmamuang - Stir-fry & cashew nuts";
                            boards[2].text = "Noodles and fried rice" + "\n" + "\n" + "* Beef & rice noodles salad" + "\n" + "* Phad thai" + "\n" +
                                "* Glass noodles stir-fry" + "\n" + "* Stir-fried egg noodles with beef" + "\n" + "* Nasigoreng � Spicy fried rice";
                            boards[3].text = "Nooshi" + "\n" + "\n" + "* Lunch buff�Weekdays 11h-15h" + "\n" + "118KR" + "\n" + "\n" + "* Week-end buff� 12h-20h" + "\n" + "158KR";
                            boards[4].text = "Sushi" + "\n" + "\n" + "* Small�8p (3 Maki, 5 Nigiri)" + "\n" + "* Medium�10p(3 Maki, 7 Nigiri)"
                                + "\n" + "* Large�12p(3 Maki, 9 Nigiri)" + "\n" + "* California roll�10p" + "\n" + "* Temura rool�10p" + "\n" + "* Pok� bowl";
                            boards[5].text = "Desert" + "\n" + "\n" + "* Deep fried banana & vanilla ice-cream" + "\n" + "* Warm chocolate & vanilla ice-cream" + "\n" +
                                "* Fruit salad & vanilla ice-cream";
                            boards[6].text = "";
                        }
                        else if (current.name == "Just nu...")
                        {
                            boards[0].text = "22/04 - 23/04" + "\n" + "\n" + "Boka ett cinemabiljett och vi bjuder p� fika p� Cafe Panorama";
                            boards[1].text = "28/04" + "\n" + "\n" + "20h-24h: " + "\n" + "V�r g�stkock lagar mat p� Teaterbaren, boka bord och vinn en matlagningslektion";
                            boards[2].text = "30/04" + "\n" + "\n" + "Boka bord p� Stories och f� 10% rabatt";
                            boards[3].text = "Just nu" + "\n" + "\n" + "Boka bord hos oss och vinn ett f�rkl�de i sammarbete med... " + "\n" + "\n" + "+ Missa inte On-spot/Spot-on som p� Stories och Cafe Panorama!";
                            boards[4].text = "06/05" + "\n" + "\n" + "Boka bord p� Nooshi och kanske vinn en sushi-matlagningskurs";
                            boards[5].text = "N�sta vecka" + "\n" + "\n" + "Vi har en ny g�stkock, stay tuned...";
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
