// (c) Copyright HutongGames, LLC 2010-2016. All rights reserved.

using UnityEngine;
using HutongGames.PlayMaker.Actions;

namespace HutongGames.PlayMakerEditor
{
    [CustomActionEditor(typeof(GetAnimatorCurrentTransitionInfo))]
    public class GetAnimatorCurrentTransitionInfoActionEditor : OnAnimatorUpdateActionEditorBase
    {

        public override bool OnGUI()
        {
            EditField("gameObject");
            EditField("layerIndex");
            EditField("name");

            EditField("nameHash");
            EditField("userNameHash");
            EditField("normalizedTime");

            bool changed = EditEveryFrameField();

            return GUI.changed || changed;
        }

    }
}
