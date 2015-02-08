using UnityEngine;
using System.Collections;

public class MinionStats : MonoBehaviour {
	public int health = 10;


	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Damage(int damage)
	{
		health -= damage;

		if(health < 1)
		{
			Dead();
		}
	}

	void Dead()
	{

		Destroy(gameObject);
	}
}
