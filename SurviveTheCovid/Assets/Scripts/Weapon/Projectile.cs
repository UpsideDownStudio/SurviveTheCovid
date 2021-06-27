using System;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Weapon
{
	public class Projectile : MonoBehaviour
	{
		public float range;
		public float radiusOfDamage;

		public TypeOfProjectile typeOfProjectile;

		private Vector3 _distance;

		public enum TypeOfProjectile
		{
			PistolProj,
			RifleProj,
			RpgProj
		}

		void Start()
		{
			_distance = transform.position;
		}

		void Update()
		{
			CheckDistance();
		}

		private void OnDrawGizmos()
		{
			Gizmos.DrawSphere(transform.position, radiusOfDamage);
		}

		public void CheckDistance()
		{
			if ((transform.position - _distance).magnitude >= range)
				Destroy(gameObject);
		}

		public void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag("Enemy"))
			{
				Target target;
				if(other.TryGetComponent(out target))
					DealDamage(typeOfProjectile, target);
			}

			if(!other.CompareTag("Player"))
				Destroy(gameObject);
		}

		private void DealDamage(TypeOfProjectile projectile, Target target)
		{
			SelectTheTypeOfDamage(typeOfProjectile, target);
			Destroy(gameObject);
		}

		private void SelectTheTypeOfDamage(TypeOfProjectile projectile, Target target)
		{
			switch (projectile)
			{
				case TypeOfProjectile.RpgProj:
					DealDamageByAoE(target);
					break;

				default:
					DealDamageByTarget(target);
					break;
			}
		}

		private void DealDamageByAoE(Target target)
		{
			Collider[] colliders = Physics.OverlapSphere(transform.position, radiusOfDamage);

			foreach (var targetCollider in colliders)
			{
				Target targetItem;
				if(targetCollider.TryGetComponent(out targetItem))
					DealDamageByTarget(targetItem);
			}
		}

		private void DealDamageByTarget(Target target)
		{
			target.TakeDamage(FindObjectOfType<PlayerStats>().damage.GetValue());
		}
	}
}
