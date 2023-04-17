using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level3Inv : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite phone;
    public Sprite bag;
    public Sprite necklace;

    public GameObject[] slots;
    private Sprite image;

    public GameObject bagObject;
    public GameObject phoneObject;
    public GameObject necklaceObject;
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Level 3")
        {
            if (LoadManager.bagIsPickedUp == true)
            {
                Destroy(bagObject);
            }
            if (LoadManager.phoneIsPickedUp == true)
            {
                Destroy(phoneObject);
            }
            if (LoadManager.necklaceIsPickedUp == true)
            {
                Destroy(necklaceObject);
            }
        }

        LoadManager.inv.Clear();

        for (int i = 0; i < LoadManager.inv.Count; i++)
        {
            if (LoadManager.inv[i] != null)
            {
                switch (LoadManager.inv[i])
                {
                    case "bag":
                        slots[i].GetComponent<Image>().sprite = bag;
                        break;
                    case "phone":
                        slots[i].GetComponent<Image>().sprite = phone;
                        break;
                    case "necklace":
                        slots[i].GetComponent<Image>().sprite = necklace;
                        break;
                    default:
                        break;
                }

                slots[i].GetComponent<Image>().color = new Color32(255, 255, 225, 255);
            }
        }
    }
}
