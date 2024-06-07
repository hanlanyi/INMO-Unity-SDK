using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static inmo.unity.sdk.ARPoseService;

namespace inmo.unity.sdk
{
    public class ARCamera : MonoBehaviour
    {
        //ar服务
        private ARPoseService _arService;

        //眼镜在空间中的pose
        private ARPose _arpose;

        //air2 眼镜的 fov,推荐设置为13.9f
        [SerializeField] private float _fieldOfView = 13.9f;

        //ar状态的文本
        [SerializeField] private Text _arstatus;

        private void OnEnable()
        {
            //默认选中 InitARService 按钮
            GameObject.Find("UI Canvas/Buttons/InitAR").GetComponent<Button>().Select();
            _arstatus.text = "ar：未初始化";
        }

        private void Update()
        {
            //获取ar的arpose
            if(_arService != null && _arService.isARPoseServiceRuning)
            {
                _arpose = _arService.GetARPose();
            }

            //双击右触摸板退出app
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit(0);
            }
        }

        private void LateUpdate()
        {
            //通过ar提供的arpose修改camera
            if (_arService.isARPoseServiceRuning)
            {
                Camera.main.transform.position = _arpose.position;
                Camera.main.transform.rotation = _arpose.rotation;
            }
        }

        #region AR通信事件
        public void InitARService()
        {
            _arService = new ARPoseService(Camera.main, _fieldOfView);
            _arstatus.text = "ar：已初始化";
        }

        public void StartARService()
        {
            if (_arService != null)
            {
                _arService.Start();
                _arstatus.text = "ar：已开启";
            }
        }

        public void PauseARService()
        {
            if (_arService != null)
            {
                _arService.Pause();
                _arstatus.text = "ar：已暂停";
            }
        }

        public void ResumeARService()
        {
            if (_arService != null)
            {
                _arService.Resume();
                _arstatus.text = "ar：已开启";
            }
        }

        public void StopARService()
        {
            if (_arService != null)
            {
                _arService.Stop();
                _arstatus.text = "ar：已销毁";
            }
        }

        public void GetARServiceVersion()
        {
            if (_arService != null)
            {
                string version = _arService.GetVersion();
                _arstatus.text = "ar：" + version;
            }
        }
        #endregion
    }
}
