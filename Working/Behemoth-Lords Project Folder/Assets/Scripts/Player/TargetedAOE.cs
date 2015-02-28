using UnityEngine;
using System.Collections;

public class TargetedAOE : MonoBehaviour {
	public Transform pointer;
	public float mouseSpeed = 10.0f;
	
	void Start () {
		pointer.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		float horizontalM = Input.GetAxis("Mouse X");
		float verticalM = Input.GetAxis("Mouse Y");

		Vector3 direction = new Vector3(horizontalM, 0, verticalM);

		pointer.Translate(direction * Time.deltaTime * mouseSpeed);
		
		Debug.Log("hello world");
		if(Input.GetButtonDown("Player-TargetedAOE"))
		{
			pointer.gameObject.SetActive(true);
			pointer.position = transform.position;
			pointer.rotation = transform.rotation;
			Debug.Log("Woo");
		}
		
		if(Input.GetMouseButtonDown(1))
		{
			pointer.gameObject.SetActive(false);
			Debug.Log("Woo2");
		}
	}
	
	
}