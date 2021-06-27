using UnityEngine;

namespace Assets.Scripts.Weapon
{
	public class Rifle : Weapon
	{
		public override void Shoot(RaycastHit hit)
		{
			if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
			{
				nextTimeToFire = Time.time + 1f / weaponStats.fireRate;
				SpawnProjectile(hit);
			}
		}
	}
}
