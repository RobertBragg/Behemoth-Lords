using UnityEngine;
using System.Collections;

public class ShowCommandPanel : MonoBehaviour {
	GameObject panel;

	// Use this for initialization
	void Start () {
		panel = GameObject.Find("CommandPanel");
		panel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetButtonDown("CommandPanel"))
		{
			if(!panel.activeInHierarchy)
				panel.SetActive(true);
			else
				panel.SetActive(false);

		}
	}
}
