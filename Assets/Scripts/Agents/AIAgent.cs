using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

namespace FSMMono
{
    public class AIAgent : MonoBehaviour, IDamageable
    {

        [SerializeField]
        int MaxHP = 100;

        private Gun Gun;

        [SerializeField]
        Slider HPSlider = null;

        Transform GunTransform;
        NavMeshAgent NavMeshAgentInst;
        Material MaterialInst;
        CharacterHealth CharacterHealth;

        bool IsDead = false;
        int CurrentHP;

        private void SetMaterial(Color col)
        {
            MaterialInst.color = col;
        }
        public void SetWhiteMaterial() { SetMaterial(Color.white); }
        public void SetRedMaterial() { SetMaterial(Color.red); }
        public void SetBlueMaterial() { SetMaterial(Color.blue); }
        public void SetYellowMaterial() { SetMaterial(Color.yellow); }

        public Transform Target;

        #region MonoBehaviour

        private void Awake()
        {
            CurrentHP = MaxHP;

            NavMeshAgentInst = GetComponent<NavMeshAgent>();

            Renderer rend = transform.Find("Body").GetComponent<Renderer>();
            MaterialInst = rend.material;

            GunTransform = transform.Find("Body/Gun");
            if (GunTransform == null)
                Debug.Log("could not fin gun transform");

            if (HPSlider != null)
            {
                HPSlider.maxValue = MaxHP;
                HPSlider.value = CurrentHP;
            }

            //NavMeshAgentInst.updatePosition = false;
        }

        private void Start()
        {
            Gun = GetComponentInChildren<Gun>();
            CharacterHealth = GetComponent<CharacterHealth>();
        }
        private void OnTriggerEnter(Collider other)
        {
        }
        private void OnTriggerExit(Collider other)
        {
        }
        private void OnDrawGizmos()
        {
        }

        #endregion

        #region Perception methods

        #endregion

        #region MoveMethods
        public void StopMove()
        {
            NavMeshAgentInst.isStopped = true;
        }
        public void MoveTo(Vector3 dest)
        {
            NavMeshAgentInst.isStopped = false;
            NavMeshAgentInst.SetDestination(dest);
        }
        public bool HasReachedPos()
        {
            return NavMeshAgentInst.remainingDistance - NavMeshAgentInst.stoppingDistance <= 0f;
        }

        #endregion

        #region ActionMethods

        public void AddDamage(int amount)
        {
            Debug.Log("Damage");
            CharacterHealth.TakeDamage(amount);
        }
        public void ShootToPosition(Vector3 pos)
        {
            // look at target position
            transform.LookAt(pos + (Vector3.up * transform.position.y));

            if (Gun)
            {
                Gun.Shoot();
            }
        }

        Vector3 velocity = Vector3.zero;

        public void FixedUpdate()
        {
            // ugly hard coded position next to the player
            //NavMeshAgentInst.SetDestination(Target.position + Vector3.right * 5.0f);
        }
        #endregion
    }
}