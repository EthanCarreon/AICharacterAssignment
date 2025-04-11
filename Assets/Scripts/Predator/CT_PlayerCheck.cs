using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Net;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions {

	public class CT_PlayerCheck : ConditionTask {

		public BBParameter<GameObject> player;
		public float interruptDist;

		public BBParameter<bool> isPredatorInterrupted;
        public BBParameter<float> timerToSpawn;
        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit(){
			return null;
		}

		//Called whenever the condition gets enabled.
		protected override void OnEnable() {
			
		}

		//Called whenever the condition gets disabled.
		protected override void OnDisable() {
			
		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {
			
			float distance = Vector3.Distance(agent.transform.position, player.value.transform.position);
			Debug.Log(distance);

            if (distance <= interruptDist)
			{
                timerToSpawn.value = 0f;
                isPredatorInterrupted = true;
                return true;
			}
			return false;
		}
	}
}