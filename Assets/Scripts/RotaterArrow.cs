using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotaterArrow : MonoBehaviour {

    public Vector3 newTargetPos;
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(newTargetPos);
	}

    public void SetNewTargetPos(Vector3 pos)
    {
        newTargetPos = pos;
    }
}
