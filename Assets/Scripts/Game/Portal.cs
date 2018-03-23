using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {

    private static bool teleporting = false;
    public Portal connectingPortal;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 rot = transform.eulerAngles;
        rot.z += 180 * Time.deltaTime;
        transform.eulerAngles = rot;
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ball" && teleporting == false)
        {
            collision.gameObject.transform.position = connectingPortal.transform.position;
            StartCoroutine(Teleporting());
        }
    }

    IEnumerator Teleporting()
    {
        teleporting = true;
        for(int i = 0; i < 2; i++)
        {
            yield return new WaitForFixedUpdate();  //Wait twice so you don't teleport back and forth.
            //Fixed update because FixedUpdate is when physics happens.
        }
        teleporting = false;
    }
}
