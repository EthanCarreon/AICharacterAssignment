using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class AT_Populate : ActionTask {

		public BBParameter<List<GameObject>> flies;

		public BBParameter<int> fliesIndex = 0;
		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			// add one to the flies index
            fliesIndex.value++;

			// if there are flies active and flies index value is less than the total count of flies in the list

            if (flies.value != null && fliesIndex.value < flies.value.Count)
            {

				// set the next fly in the list to be visible
                GameObject nextFly = flies.value[fliesIndex.value];
                nextFly.SetActive(true); 
            }

            EndAction(true);
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}