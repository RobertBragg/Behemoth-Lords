using UnityEngine;
using System.Collections;

public class MinNatural : MonoBehaviour {
	protected GameObject leader;

	void Awake(){
		leader = GameObject.Find("First Person Controller");

	}
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
