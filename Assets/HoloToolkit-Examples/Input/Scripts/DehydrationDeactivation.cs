// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using UnityEngine;

namespace HoloToolkit.Unity.InputModule.Tests
{
    public class DehydrationDeactivation : StateMachineBehaviour
    {
        /// <summary>
        /// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        /// </summary>
        /// <param Name="animator">Animator that triggered OnStateEnter.</param>
        /// <param Name="stateInfo">Animator state info.</param>
        /// <param Name="layerIndex">Layer index.</param>
        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.transform.gameObject.SetActive(false);
        }
    }
}
