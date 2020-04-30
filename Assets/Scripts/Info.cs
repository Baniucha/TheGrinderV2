using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//SCRIPT RESPONSIBLE FOR DISPLAYING INFORMATION ABOUT INPUT FOR PLAYER
public class Info : MonoBehaviour
{
    //VERIABLES
    bool menu;
    public GameObject info;
    // Start is called before the first frame update
    void Start()
    { 
        //DISABLE OBJECT ON START
        info.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //IF PLAYER PRESSES ESCAPE BUTTON
        //ENABLE OR DISABLE MENU
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            menu = !menu;
        }
        if(menu)
        {
            info.SetActive(true);
        }
        else
        {
            info.SetActive(false);
        }
    }

    //BUTTON FUNCTION RESPONSIBLE FOR QUITING GAME
    public void Quitgame()
    {
        Application.Quit();
    }
}
