using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
    
    enum MenuItem { Start, Exit };
    MenuItem selectedMenuItem;

    public GameObject startText, exitText, quoteText;

    Color selectedColor, unselectedColor;

    List<string> quotes;

    float quoteTimer = 0f;

    Color transparentColor, quoteColor;
    float lerp = 0f;

    int nextQuote = 0;

    void Start () {
        
        quoteText.GetComponent<Text>().text = "";

        transparentColor = new Color(140f / 255f, 140f / 255f, 140f / 255f, 0f);
        quoteColor = new Color(140f / 255f, 140f / 255f, 140f / 255f, 1f);

        quoteText.GetComponent<Text>().color = transparentColor;

        quotes = new List<string>();
        quotes.Add("To a thirsty man, a drop of water is worth more than a sack of gold.");
        quotes.Add("My fake plants died because I did not pretend to water them.\n - Mitch Hedberg");
        quotes.Add("No man ever steps in the same river twice, for it's not the same river and he's not the same man.\n - Heraclitus");
        quotes.Add("You have reached the end of your free trial membership at WaterQuotes.com\n - Benjamin Franklin");
        quotes.Add("If you don't die of thirst, there are blessings in the desert.\n - Anne Lamott");

        quotes.Add("Save water for a rainy day.");
        quotes.Add("Nothing is softer or more flexible than water, yet nothing can resist it.\n - Lao Tzu");
        quotes.Add("No water, no life. No blue, no green.\n - Sylvia Earle");
        quotes.Add("Have you also learned that secret from the river; that there is no such thing as time? That the river is everywhere at the same time, at the source and at the mouth, at the waterfall, at the ferry, at the current, in the ocean and in the mountains, everywhere and that the present only exists for it, not the shadow of the past nor the shadow of the future.\n - Hermann Hesse, Siddhartha");
        quotes.Add("You can lead a horse to water, but you can't make him drink.");
        quotes.Add("I incessantly look for water in wells dug by men, and I have drunk enough sand to prove it.\n - Craig D. Lounsbrough");
        quotes.Add("He supposed that even in Hell, people got an occasional sip of water, if only so they could appreciate the full horror of unrequited thirst when it set in again.\n - Stephen King");
        quotes.Add("To underestimate one's thirst, to pass a given landmark to the right or left, to find a dry spring where one looked for running water - there is no help for any of these things.\n - Mary Hunter Austin");
        quotes.Add("You should not see the desert simply as some faraway place of little rain. There are many forms of thirst.\n - William Langewiesche");

        unselectedColor = Color.white;
        selectedColor = new Color(223f / 255f, 197f / 255f, 112f / 255f);
        selectedMenuItem = MenuItem.Start;

        quoteTimer = 7f;
	}
	
    void CycleQuotes ()
    {
        if (quoteTimer < 7f)
        {
            quoteTimer += Time.deltaTime;
        }
        else
        {
            //quoteText.GetComponent<Text>().text = quotes[Random.Range(0, quotes.Count)];
            quoteText.GetComponent<Text>().text = quotes[nextQuote];
            quoteTimer = 0f;
            if (nextQuote < 5)
            {
                nextQuote += 1;
            }
            else
            {
                nextQuote = Random.Range(0, quotes.Count);
            }
        }

        if (lerp < 1f)
        {
            quoteText.GetComponent<Text>().color = Color.Lerp(transparentColor, quoteColor, lerp);
            lerp += Time.deltaTime;
        }
        else if (lerp > 1f && lerp < 6f)
        {
            quoteText.GetComponent<Text>().color = quoteColor;
            lerp += Time.deltaTime;
        }
        else if (lerp > 6f && lerp < 7f)
        {
            quoteText.GetComponent<Text>().color = Color.Lerp(quoteColor, transparentColor, lerp - 6f);
            lerp += Time.deltaTime;
        }
        else
        {
            quoteText.GetComponent<Text>().color = transparentColor;
            lerp = 0f;
        }
    }

    void Update () {

        CycleQuotes();

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
