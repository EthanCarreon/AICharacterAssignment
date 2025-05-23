using NodeCanvas.Framework;
using ParadoxNotion.Design;


namespace NodeCanvas.Tasks.Conditions {

	public class CT_CheckPatrolRounds : ConditionTask {

        public BBParameter<PatrolData> patrolData;
        //public BBParameter<int> patrolRounds;
        //public BBParameter<int> maxPatrolRounds;
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

			// check the amount of patrol rounds, if it is greater than the max rounds amount, return true
			if (patrolData.value.patrolRounds >= patrolData.value.maxPatrolRounds)
			{
                return true;
            }
            return false;

        }
	}
}