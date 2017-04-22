using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {


    public GameObject mountainPrefab;
    public Transform terrainParent;

	void Start () {
		for (int i = 0; i < 20; i++)
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
	
	void Update () {
		
	}
}
