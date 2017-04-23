using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {


    public GameObject mountainPrefab;
    public Transform terrainParent;

    public Material brownEarth, greenEarth;
    Renderer earthRend;
    float lerpT = 0f;
    List<Renderer> mountains;
    List<Color> mountainColors;
    List<Color> mountainTargetColors;

    public GameObject worldCam, behindCam;
    public GameObject curtain;

    bool gameWon = false;

    float startTime;
    float timeCurtain = 0f;

    void Awake () {

        for (int i = 0; i < 15; i++)
        {
            float randY;
            int opt = Random.Range(0, 2);
            if (opt == 0)
            {
                randY = Random.Range(-50f, -20f);
            }
            else
            {
                randY = Random.Range(20f, 50f);
            }

            Vector3 pos = new Vector3(Random.Range(-50f, 50f), randY, Random.Range(-50f, 50f));
            Instantiate(mountainPrefab, pos, Quaternion.identity, terrainParent);
        }
    }

    void Start ()
    {
        startTime = Time.time;

        mountains = new List<Renderer>();
        mountainColors = new List<Color>();
        mountainTargetColors = new List<Color>();
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("mountain"))
        {
            mountains.Add(g.GetComponent<Renderer>());
            mountainColors.Add(g.GetComponent<Renderer>().material.color);
            float h, s, v;
            Color.RGBToHSV(g.GetComponent<Renderer>().material.color, out h, out s, out v);
            h += 0.3f;
            mountainTargetColors.Add(Color.HSVToRGB(h, s, v));
        }

        earthRend = GameObject.FindGameObjectWithTag("earth").GetComponent<Renderer>();
    }
	
	void Update () {

        if (Time.time > startTime + 5f)
        {
            if (curtain.active)
            {

                curtain.GetComponent<Image>().color = Color.Lerp(Color.black, new Color(1f, 1f, 1f, 0f), timeCurtain / 3f);
                timeCurtain += Time.deltaTime;
            }
        }

        if (Time.time > startTime + 8f)
        {
            curtain.SetActive(false);

            if (Input.GetKeyDown(KeyCode.M))
            {
                if (behindCam.active)
                {
                    Debug.Log("a");
                    worldCam.SetActive(true);
                    behindCam.SetActive(false);
                }
                else if (worldCam.active)
                {
                    Debug.Log("b");
                    behindCam.SetActive(true);
                    worldCam.SetActive(false);
                }
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("menu");
        }
        
        if (gameWon)
        {
            for (int i=0; i < mountains.Count; i++)
            {
                mountains[i].material.color = Color.Lerp(mountains[i].material.color, mountainTargetColors[i], lerpT / 2f * Time.deltaTime);
            }
            lerpT += Time.deltaTime;

            if (lerpT >= 2f)
            {
                gameWon = false;
                earthRend.material = greenEarth;
                for (int i = 0; i < mountains.Count; i++)
                {
                    mountains[i].material.color = mountainTargetColors[i];
                }
            }
        }
	}

    public void WinGame ()
    {
        gameWon = true;
    }
}
