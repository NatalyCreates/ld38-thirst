using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
    
    enum MenuItem { Start, Exit };
    MenuItem selectedMenuItem;

    public GameObject startText, exitText;

    Color selectedColor, unselectedColor;

	void Start () {
        unselectedColor = Color.white;
        selectedColor = new Color(223f / 255f, 197f / 255f, 112f / 255f);
        selectedMenuItem = MenuItem.Start;
        Debug.Log(startText.GetComponent<Text>().color);
	}
	
	void Update () {

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            switch (selectedMenuItem)
            {
                case MenuItem.Start:
                    selectedMenuItem = MenuItem.Exit;
                    break;
                case MenuItem.Exit:
                    selectedMenuItem = MenuItem.Start;
                    break;
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            switch (selectedMenuItem)
            {
                case MenuItem.Start:
                    selectedMenuItem = MenuItem.Exit;
                    break;
                case MenuItem.Exit:
                    selectedMenuItem = MenuItem.Start;
                    break;
            }
        }

        switch (selectedMenuItem)
        {
            case MenuItem.Start:
                startText.GetComponent<Text>().color = selectedColor;
                exitText.GetComponent<Text>().color = unselectedColor;
                break;
            case MenuItem.Exit:
                startText.GetComponent<Text>().color = unselectedColor;
                exitText.GetComponent<Text>().color = selectedColor;
                break;
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            switch (selectedMenuItem)
            {
                case MenuItem.Start:
                    SceneManager.LoadScene("game");
                    break;
                case MenuItem.Exit:
                    Debug.Log("Quitting");
                    Application.Quit();
                    break;
            }
        }
	}
}
