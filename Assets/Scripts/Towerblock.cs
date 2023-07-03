using MoreMountains.Feedbacks;
using MoreMountains.Tools;
using UnityEngine;
namespace MoreMountains.TopDownEngine
{
    public class Towerblock : TopDownMonoBehaviour
    {
        [Header("Owner")]
        /// the owner of the tower
        [MMReadOnly]
        [Tooltip("the owner of the tower")]
        public Character Owner;
        public Health _health;

        private void Awake()
        {
            _health = GetComponent<Health>();
        }
		private void OnEnable()
		{
		
			if (_health != null)
			{
				_health.OnDeath += OnDeath;
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
			}
		}
		public virtual void AssignPlayer(Character player)
        {
            Owner = player;
        }

        public void OnDeath()
        {
           // MultiplayerLevelManager.Instance.MakeTowerVulnerableTo(Owner);
            
        }
    }
}