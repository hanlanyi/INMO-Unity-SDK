using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace inmo.unity.sdk
{
    public class InmoRingPoseServiceGuide : MonoBehaviour
    {
        private RingPoseService ringThreeDofService;

        private void Awake()
        {
            ringThreeDofService = new RingPoseService();
        }

        private void Update()
        {
            transform.rotation = ringThreeDofService.GetRingPose();

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                ringThreeDofService.ResetRingPose();
            }
        }

        public void ButtonClick(string id)
        {
            switch (id)
            {
                case "start":
                    ringThreeDofService.Start();
                    break;
                case "pause":
                    ringThreeDofService.Pause();
                    break;
                case "resume":
                    ringThreeDofService.Resume();
                    break;
                case "stop":
                    ringThreeDofService.Stop();
                    break;
                case "reset":
                    ringThreeDofService.ResetRingPose();
                    break;
            }
        }
    }
}
