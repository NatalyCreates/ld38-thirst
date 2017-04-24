using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

    public float height;
    public bool hasWater;

    bool isInPosition = false;
    bool createdWater = false;

    public GameObject waterPrefab;

    void Start () {
        
	}

	void Update () {
        if (!isInPosition && GetComponent<Rigidbody>().isKinematic) isInPosition = true;
        if (isInPosition && !createdWater && hasWater)
        {
            GameObject water = Instantiate(waterPrefab, Vector3.zero, Quaternion.identity, transform);
            water.transform.parent = transform;
            water.transform.localPosition = new Vector3(0f, 5f, 0f);
            water.transform.localScale = new Vector3(0.2f, 10f, 0.2f);
            water.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
            createdWater = true;
        }
    }
}
