using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;

    public GameObject mountainPrefab;
    public Transform terrainParent;

    public Material brownEarth, greenEarth;
    Renderer earthRend;
    float lerpT = 0f;
    List<GameObject> mountains;
    List<Color> mountainColors;
    List<Color> mountainTargetColors;

    public GameObject worldCam, behindCam;
    public GameObject curtain;

    bool curtainIntroHidden = false;

    bool gameWon = false;

    float startTime;
    float timeCurtain = 0f;
    float timeCurtainEnd = 0f;

    float endTime;

    void Awake () {

        Instance = this;

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

        mountains = new List<GameObject>();
        mountainColors = new List<Color>();
        mountainTargetColors = new List<Color>();
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("mountain"))
        {
            mountains.Add(g);
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
            if (curtain.active && !curtainIntroHidden)
            {
                curtain.GetComponent<Image>().color = Color.Lerp(Color.black, new Color(0f, 0f, 0f, 0f), timeCurtain / 3f);
                timeCurtain += Time.deltaTime;
            }
        }

        if (Time.time > startTime + 8f)
        {
            if (!curtainIntroHidden)
            {
                curtain.SetActive(false);
                curtainIntroHidden = true;
            }

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
                try
                {
                    if (mountains[i].active)
                    {
                        Renderer r = mountains[i].GetComponent<Renderer>();
                        r.material.color = Color.Lerp(r.material.color, mountainTargetColors[i], lerpT / 2f * Time.deltaTime);
                    }
                }
                catch
                {

                }
            }
            lerpT += Time.deltaTime;

            if (lerpT >= 2f)
            {
                //gameWon = false;
                earthRend.material = greenEarth;
                for (int i = 0; i < mountains.Count; i++)
                {
                    try
                    {
                        if (mountains[i].active)
                        {
                            Renderer r = mountains[i].GetComponent<Renderer>();
                            r.material.color = mountainTargetColors[i];
                        }
                    }
                    catch
                    {

                    }
                }

                curtain.GetComponentInChildren<Text>().text = "Ahhh Water At Last...";
                curtain.SetActive(true);
                curtain.GetComponent<Image>().color = Color.Lerp(new Color(0f, 0f, 0f, 0f), Color.black, timeCurtainEnd / 3f);
                timeCurtainEnd += Time.deltaTime;
            }
            
            if (Time.time > endTime + 8f)
            {
                SceneManager.LoadScene("menu");
            }
        }
	}

    public void WinGame ()
    {
        endTime = Time.time;
        gameWon = true;
        Audio.Instance.PlayWinTune();
    }
}
