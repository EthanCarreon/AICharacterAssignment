using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class AT_Leave : ActionTask {

		public Transform startPos;
		public float speed;
		public float arrivalDist;
		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {

            Vector3 moveDirection = (startPos.position - agent.transform.position).normalized;
            agent.transform.position += moveDirection * speed * Time.deltaTime;

			float distance = Vector3.Distance(agent.transform.position, startPos.position);

			if (distance <= arrivalDist)
			{
				agent.gameObject.SetActive(false);
				EndAction(true);
			}

        }

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}