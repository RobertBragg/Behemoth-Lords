using UnityEngine;
using System.Collections;

public class CommandPanel : MonoBehaviour {
	GameObject[] minions;
	public AudioClip AudioAttackCommand;
	public AudioClip AudioFollowCommand;
	public AudioClip AudioHoldCommand;
	// Use this for initialization
	void Awake () {
		minions = GameObject.FindGameObjectsWithTag("Minions");
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("MinAttack"))
		{
			audio.PlayOneShot(AudioAttackCommand);
			foreach(GameObject min in minions)
			{
				min.GetComponent<MinMovement>().MoveTypeAttack();
			}
		}
		else if(Input.GetButtonDown("MinFollow"))
		{			
			audio.PlayOneShot(AudioFollowCommand);
			foreach(GameObject min in minions)
			{
				min.GetComponent<MinMovement>().MoveTypeFollow();
			}
		}
		else if(Input.GetButtonDown("MinHold"))
		{			
			audio.PlayOneShot(AudioHoldCommand);
			foreach(GameObject min in minions)
			{
				min.GetComponent<MinMovement>().MoveTypeHold();
			}
		}
	}
}
