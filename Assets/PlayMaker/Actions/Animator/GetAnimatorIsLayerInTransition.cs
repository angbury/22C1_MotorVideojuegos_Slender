// (c) Copyright HutongGames, LLC 2010-2016. All rights reserved.

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory(ActionCategory.Animator)]
	[Tooltip("Returns true if the specified layer is in a transition. Can also send events")]
	public class GetAnimatorIsLayerInTransition: FsmStateActionAnimatorBase
	{
		[RequiredField]
		[CheckForComponent(typeof(Animator))]
        [Tooltip("The GameObject with an Animator Component.")]
		public FsmOwnerDefault gameObject;
		
		[RequiredField]
		[Tooltip("The layer's index")]
		public FsmInt layerIndex;
		
		[ActionSection("Results")]
		
		[UIHint(UIHint.Variable)]
		[Tooltip("True if automatic matching is active")]
		public FsmBool isInTransition;
		
		[Tooltip("Event send if automatic matching is active")]
		public FsmEvent isInTransitionEvent;
		
		[Tooltip("Event send if automatic matching is not active")]
		public FsmEvent isNotInTransitionEvent;

        private Animator animator
        {
            get { return cachedComponent; }
        }

        public override void Reset()
		{
			base.Reset();

			gameObject = null;
			isInTransition = null;
			isInTransitionEvent = null;
			isNotInTransitionEvent = null;
		}
		
		public override void OnEnter()
		{
            DoCheckIsInTransition();
			
			if(!everyFrame)
			{
				Finish();
			}
		}

		public override void OnActionUpdate() 
		{
			DoCheckIsInTransition();
		}


        private void DoCheckIsInTransition()
        {
            if (!UpdateCache(Fsm.GetOwnerDefaultTarget(gameObject)))
            {
                Finish();
                return;
            }

            var _isInTransition = animator.IsInTransition(layerIndex.Value);

			if (!isInTransition.IsNone)
			{
				isInTransition.Value = _isInTransition;
			}

            Fsm.Event(_isInTransition ? isInTransitionEvent : isNotInTransitionEvent);
        }
	}
}