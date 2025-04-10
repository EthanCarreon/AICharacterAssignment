using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
    public class AT_Wander: ActionTask
    {
        public BBParameter<float> moveSpeed = 3f;
        public BBParameter<float> changeDirectionTime = 2f;
        public BBParameter<Transform> center;
        public BBParameter<float> wanderRadius = 5f;

        public BBParameter<float> wanderTimer;
        public float flyTime;

        private Vector3 wanderTarget;
        private float timeToNextDirection;

        protected override void OnExecute()
        {
            PickNewWanderPoint();
        }

        protected override void OnUpdate()
        {
            timeToNextDirection -= Time.deltaTime;
            wanderTimer.value += Time.deltaTime;

            if (timeToNextDirection <= 0f)
            {
                PickNewWanderPoint();
            }

            Vector3 moveDir = (wanderTarget - agent.transform.position).normalized;
            agent.transform.position += moveDir * moveSpeed.value * Time.deltaTime;

            if (wanderTimer.value >= flyTime)
            {
                wanderTimer.value = 0f;
                EndAction(true);
            }
        }

        void PickNewWanderPoint()
        {
            Vector3 randomDirection = Random.insideUnitSphere * wanderRadius.value;
            wanderTarget = center.value.position + randomDirection;
            timeToNextDirection = changeDirectionTime.value;
        }

        protected override void OnStop() { }

        protected override void OnPause() { }
    }
}
