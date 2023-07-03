using MoreMountains.Feedbacks;
using MoreMountains.Tools;
using System.Collections.Generic;
using UnityEngine;
namespace MoreMountains.TopDownEngine
{
    public class MainTower : TopDownMonoBehaviour
    {
      
        Health _health;

		List<Character> vulnerableToPlayers = new List<Character>();

        private void Awake()
        {
            _health = GetComponent<Health>();
        }
		private void OnEnable()
		{
		
			if (_health != null)
			{
				_health.OnDeath += OnDeath;
				_health.OnHit += OnHit;
			}
		}

		/// <summary>
		/// On disable, we plug our OnDeath method to the health component
		/// </summary>
		private void OnDisable()
		{
			
			if (_health != null)
			{
				_health.OnDeath -= OnDeath;
				_health.OnHit += OnHit;
			}
		}
		
        public void OnDeath()
        {
            // game end
        }
		public void OnHit(GameObject damageDealer)
		{
			Character player = damageDealer.GetComponent<Character>();
			if (player != null)
            {
                if (vulnerableToPlayers.Contains(player))
                {
					_health.Kill();
				}
            }
		}
		public void AddPlayersVulnerableTo(Character player)
        {
			vulnerableToPlayers.Add(player);

		}
    }
}