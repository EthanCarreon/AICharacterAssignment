using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{

    public class AT_MoveToTarget : ActionTask
    {
        public BBParameter<Transform> currentTarget;
        public float speed;
        public float arrivalDist;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit()
        {
            return null;
        }

        //This is called once each time the task is enabled.
        //Call EndAction() to mark the action as finished, either in success or failure.
        //EndAction can be called from anywhere.
        protected override void OnExecute()
        {
            Vector3 directionToMove = currentTarget.value.position - agent.transform.position;
            agent.transform.position += directionToMove.normalized * speed * Time.deltaTime;

            float distance = Vector3.Distance(currentTarget.value.position, agent.transform.position);

            if (distance <= arrivalDist)
            {
                currentTarget.value.gameObject.SetActive(false);
            }
            EndAction(true);
        }

        //Called once per frame while the action is active.
        protected override void OnUpdate()
        {

        }

        //Called when the task is disabled.
        protected override void OnStop()
        {

        }

        //Called when the task is paused.
        protected override void OnPause()
        {

        }
    }
}