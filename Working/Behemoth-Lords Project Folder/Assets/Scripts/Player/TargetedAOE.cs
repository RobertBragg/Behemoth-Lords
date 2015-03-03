using UnityEngine;
using System.Collections;

public class TargetedAOE : MonoBehaviour {
	public Transform pointer;
	public float mouseSpeed = 10.0f;

	Transform intendedPosition;

	
	void Start () {
		pointer.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

		if(pointer.gameObject.activeInHierarchy)
		{		
			RaycastHit hit;
			float yValue = 0.0f;
			float horizontalM = Input.GetAxis("Mouse X");
			float verticalM = Input.GetAxis("Mouse Y");

			if(Physics.Raycast(new Vector3(pointer.position.x, pointer.position.y + 30, pointer.position.z), -Vector3.up, out hit, 100.0f))
			{
				yValue = 30 - hit.distance;
			}

			Vector3 direction = new Vector3(horizontalM, yValue, verticalM);

			pointer.Translate(direction * Time.deltaTime * mouseSpeed);
			Debug.Log("asdfadf");
		}

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
		}
		if(Input.GetMouseButtonDown(0))
		{
			pointer.gameObject.SetActive(false);
		}
	}
	
	
}