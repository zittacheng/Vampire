using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Knight
{
    public class ChoiceEffect_SetCameraPosition : ChoiceEffect {
        public GameObject CameraPoint;

        public override void Effect()
        {
            base.Effect();
            Camera.main.transform.position = new Vector3(CameraPoint.transform.position.x, CameraPoint.transform.position.y,
                Camera.main.transform.position.z);
        }
    }
}