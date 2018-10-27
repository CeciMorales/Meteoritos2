using UnityEngine;
using System.Collections;

public class RandomRotation : MonoBehaviour {

  public float Tumble = 3;

	// Use this for initialization
	void Start () {
    gameObject.GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * Tumble;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
