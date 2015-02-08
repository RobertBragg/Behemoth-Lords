using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {
	protected int strength = 1;
	protected int magic = 1;
	protected int defense = 1;
	protected int speed = 1;
	protected int size = 1;
	protected int hoard = 0;
	protected int domain = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetStrength(int str)
	{
		strength = str;
	}

	public void SetMagic(int mag)
	{
		magic = mag;
	}

	public void SetDefense(int def)
	{
		defense = def;
	}

	public void SetSpeed(int spd)
	{
		speed = spd;
	}

	public void SetSize(int siz)
	{
		size = siz;
	}

	public void SetHoard(int hrd)
	{
		hoard = hrd;
	}

	public void SetDomain(int dom)
	{
		domain = dom;
	}

}
