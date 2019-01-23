using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class WaterSafing : MonoBehaviour {

	void OnTriggerStay(Collider col)
	{
		if (col.tag == "Physical" || col.tag == "Buoy") {
            float randCoeff = Random.Range(0, 0.8f);

            float mass = col.GetComponent<Rigidbody>().mass;
            float force = (mass - mass * randCoeff) * 20;
			col.GetComponent<Rigidbody>().AddForce (transform.up * force);
		}
	}
}