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
            currentPatrolPointIndex = 0;
        }

        protected override void OnUpdate()
        {
            Transform targetPatrolPoint = patrolPoints.value[currentPatrolPointIndex];

            float distanceToTarget = Vector3.Distance(agent.transform.position, targetPatrolPoint.position);

            if (distanceToTarget < arrivalDistance)
            {
                currentPatrolPointIndex = (currentPatrolPointIndex + 1);

                if (currentPatrolPointIndex >= patrolPoints.value.Count)
                {
                    currentPatrolPointIndex = 0;
                    patrolRounds.value++;
                }

                targetPatrolPoint = patrolPoints.value[currentPatrolPointIndex];
            }

            Vector3 moveDirection = (targetPatrolPoint.position - agent.transform.position).normalized;
            agent.transform.position += moveDirection * speed.value * Time.deltaTime;

            if (patrolRounds.value >= maxPatrolRounds.value)
            {
                EndAction(true);
            }
        }
    }
}
