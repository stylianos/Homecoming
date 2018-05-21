using UnityEngine;
using System.Collections;

public class angry_weapon : vp_Component {
	
	private vp_FPWeaponMeleeAttack m_Weapon = null;
	public string test = "test2";
	// Use this for initialization
	
	protected override void Start()
	{

		base.Start();
		m_Weapon = (vp_FPWeaponMeleeAttack)this.GetComponentInChildren(typeof(vp_FPWeaponMeleeAttack));
		

	}

	
	// Update is called once per frame
	protected override void Update()
	{

		/*
		base.Update();
		m_Weapon.Damage = 3000;
		m_Weapon.DamageForce = 4000;
		*/		
	}
}
