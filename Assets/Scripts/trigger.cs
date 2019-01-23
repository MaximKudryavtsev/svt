using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour {

    public GameController controller;

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Buoy")
        {
            Destroy(col.gameObject);
            controller.AddScore();
            controller.CreateNewBuoy();
        }
    }
}
