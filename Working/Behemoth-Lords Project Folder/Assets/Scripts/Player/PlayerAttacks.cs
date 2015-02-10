using UnityEngine;
using System.Collections;

public class PlayerAttacks : PlayerStats {
	public float radius = 5.0f;
	public float force = 10f;

	private bool launch = false;

	Vector3 newRad;
	Vector3 oldRad;

	// Use this for initialization
	void Start () {
		force = magic * 5f;
		Debug.Log("force: " + force);
		newRad = new Vector3(radius, radius, radius);
		oldRad = new Vector3(1,1,1);
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetButtonDown("Player-AOE"))
		{
			LaunchAOE();
			ExplosionDamage();
		}


		if(launch)
		{
			Transform AOE;
			foreach(Transform child in transform)
			{
				if(child.name == "AOE")
				{
					AOE = child;
					AOE.gameObject.SetActive(true);
					

					AOE.localScale = Vector3.Slerp (AOE.localScale,  newRad * 2.55f, Time.deltaTime * 2);
					AOE.RotateAround(transform.position, new Vector3(0,1,0), 25f);

					if(AOE.localScale.x >= newRad.x * 2.2f)
					{
						launch = false;
						AOE.localScale = oldRad;
						AOE.gameObject.SetActive(false);
					}
				}

			}
		}
	}

	void ExplosionDamage() {
		Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);
		
		foreach (Collider enemy in hitColliders)
		{
			if(enemy.gameObject.tag == "Enemy-Minions")
			{
				Vector3 push = new Vector3(enemy.transform.position.x - transform.position.x, 1, enemy.transform.position.z - transform.position.z);

				enemy.gameObject.rigidbody.AddForce(push * force, ForceMode.Impulse);
			}
		}
	}

	void LaunchAOE()
	{
		launch = true;
	}
}
