using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

namespace NodeCanvas.Tasks.Actions
{
    public class AT_PatrolTwo : ActionTask
    {
        public BBParameter<PatrolData> patrolData;
        public BBParameter<float> speed = 3f;
        public float arrivalDistance = 1f;

        public int currentPatrolPointIndex = 0;

        public GameObject exclamation;

        protected override void OnExecute()
        {
            exclamation.SetActive(true);
            currentPatrolPointIndex = 0;
        }

        // Code similar to AT_Patrol
        protected override void OnUpdate()
        {
            Transform targetPatrolPoint = patrolData.value.patrolPointsTwo[currentPatrolPointIndex];

            float distanceToTarget = Vector3.Distance(agent.transform.position, targetPatrolPoint.position);

            if (distanceToTarget < arrivalDistance)
            {
                currentPatrolPointIndex = (currentPatrolPointIndex + 1);

                if (currentPatrolPointIndex >= patrolData.value.patrolPointsTwo.Count)
                {
                    currentPatrolPointIndex = 0;
                    patrolData.value.patrolRoundsTwo++;
                }

                targetPatrolPoint = patrolData.value.patrolPointsTwo[currentPatrolPointIndex];
            }

            Vector3 moveDirection = (targetPatrolPoint.position - agent.transform.position).normalized;
            agent.transform.position += moveDirection * speed.value * Time.deltaTime;

            if (patrolData.value.patrolRoundsTwo >= patrolData.value.maxPatrolRounds)
            {
                EndAction(true);
            }
        }
    }
}
