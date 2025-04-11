using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
    public class AT_Wander: ActionTask
    {
        public BBParameter<WanderData> wanderData;
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
            // start with picking a wander point to wander to
            PickNewWanderPoint();
        }

        protected override void OnUpdate()
        {
            // set time to next direction to subract over time
            timeToNextDirection -= Time.deltaTime;

            // add wander time to add over time
            wanderTimer.value += Time.deltaTime;

            // if time to next direction is less than or equal to 0, pick a new point
            if (timeToNextDirection <= 0f)
            {
                PickNewWanderPoint();
            }


            // find the move direction between the wander target and the fly position
            Vector3 moveDir = (wanderTarget - agent.transform.position).normalized;

            // add the current move direction to the current transform position of the fly, by speed and time
            agent.transform.position += moveDir * moveSpeed.value * Time.deltaTime;

            // if the fly time has reached its max point, reset back to 0 and end action and loop (spawn new fly after this)
            if (wanderTimer.value >= flyTime)
            {
                wanderTimer.value = 0f;
                EndAction(true);
            }
        }

        void PickNewWanderPoint()
        {
            // pick a random direction using inside unit spehere, multiplied by the wander radius (so its within the radius)
            Vector3 randomDirection = Random.insideUnitSphere * wanderRadius.value;
            // set the wander target starting from the center position, so it always stays within the center, and add the random direction
            wanderTarget = center.value.position + randomDirection;
            // set time to next direction to the change direcion value (how long it takes to change to the next direction)
            timeToNextDirection = changeDirectionTime.value;
        }

        protected override void OnStop() { }

        protected override void OnPause() { }
    }
}
