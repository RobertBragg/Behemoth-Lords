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
		Debug.Log("health");
		Debug.Log(health);
		Debug.Log("Damage");
		Debug.Log(damage);
		if(health < 1)
		{
			Dead();
		}
	}

	void Dead()
	{
		Debug.Log("dead");
		Destroy(gameObject);
	}
}
