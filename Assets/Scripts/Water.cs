using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour {
    
	void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            Debug.Log("aaa");
            Destroy(gameObject.transform.parent.gameObject);
            GameManager.Instance.WinGame();
        }
    }
}
