using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIController : MonoBehaviour
{
    public Button btnRight;
    public Button btnLeft;
    private PlayerController playerController;


    void Start()
    {
        playerController = new PlayerController();
    }

   

    void Update()
    {
        
    }
}
