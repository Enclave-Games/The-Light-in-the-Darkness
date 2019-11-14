using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIController : MonoBehaviour
{
    public GameObject panelPause;
    public GameObject panelInventory;


    public void ActivatePause()
    {
        panelPause.SetActive(true);
    }

    public void ActivateInventoryPanel()
    {
        if(panelInventory.active == false)
        {
            panelInventory.SetActive(true);
        }
        else
        {
            panelInventory.SetActive(false);
        }
    }
}
