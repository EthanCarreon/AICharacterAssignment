using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using System.Collections.Generic;

namespace NodeCanvas.Tasks.Actions
{
    public class AT_Patrol : ActionTask 
    {
        public BBParameter<List<Transform>> patrolPoints;
        public BBParameter<int> maxPatrolRounds;
        public BBParameter<float> speed = 3f;
        public float arrivalDistance = 1f;

        public BBParameter<int> patrolRounds = 0;
        public int currentPatrolPointIndex = 0;

        protected override void OnExecute()
        {
            // set current patrol index to 0
            currentPatrolPointIndex = 0;
        }

        protected override void OnUpdate()
        {
            // set a transform target patrol point within the array of patrol points
            Transform targetPatrolPoint = patrolPoints.value[currentPatrolPointIndex];

            // check the distance between the character and the current target point
            float distanceToTarget = Vector3.Distance(agent.transform.position, targetPatrolPoint.position);

            // if the float value of the distance is less than a set arrival distance
            if (distanceToTarget < arrivalDistance)
            {

                // add one to the current index of patrol points
                currentPatrolPointIndex = currentPatrolPointIndex + 1;

                // if its greater than the count of indexes in the array, set it back to 0 so it can loop
                // also add one to the patrol points int so it checks how many rounds it goes through (use for later)
                if (currentPatrolPointIndex >= patrolPoints.value.Count)
                {
                    currentPatrolPointIndex = 0;
                    patrolRounds.value++;
                }

                // set the target patrol point transform value to the current index in the patrol points array
                targetPatrolPoint = patrolPoints.value[currentPatrolPointIndex];
            }

            // make a vector3 move direction variable to set the direction of where the character should go
            Vector3 moveDirection = (targetPatrolPoint.position - agent.transform.position).normalized;

            // move the character to the direction over time
            agent.transform.position += moveDirection * speed.value * Time.deltaTime;

            // if patrol rounds has reached enough rounds, end action
            if (patrolRounds.value >= maxPatrolRounds.value)
            {
                EndAction(true);
            }
        }
    }
}
