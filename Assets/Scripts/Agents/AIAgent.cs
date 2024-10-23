using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

namespace FSMMono
{
    public class AIAgent : Entity
    {
        NavMeshAgent NavMeshAgentInst;

        public Transform Target;

        [SerializeField] private RotateManager RotateManager;

        public override void AimAtPosition(Vector3 _pos)
        {
            if (IsInRangeAndNotTooClose(_pos))
            {
                Vector3 targetNpcLookAt = _pos + Vector3.up * transform.position.y;
                targetNpcLookAt.y = transform.position.y;

                Vector3 targetLookAt = _pos;
                transform.LookAt(targetNpcLookAt);

                RotateManager.Rotate(_pos);
            }
        }

        #region MonoBehaviour

        private void Awake()
        {

            NavMeshAgentInst = GetComponent<NavMeshAgent>();
            //NavMeshAgentInst.updatePosition = false;
        }

        protected override void Start()
        {
            base.Start();
            RotateManager = GetComponent<RotateManager>();
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
        public void MoveTo(Vector3 _dest)
        {
            NavMeshAgentInst.isStopped = false;
            NavMeshAgentInst.SetDestination(_dest);
        }
        public bool HasReachedPos()
        {
            return NavMeshAgentInst.remainingDistance - NavMeshAgentInst.stoppingDistance <= 0f;
        }

        #endregion

        #region ActionMethods


        #endregion
    }
}