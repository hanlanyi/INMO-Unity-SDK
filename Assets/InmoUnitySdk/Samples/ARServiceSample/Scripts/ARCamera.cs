using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static inmo.unity.sdk.ARPoseService;

namespace inmo.unity.sdk
{
    public class ARCamera : MonoBehaviour
    {
        //ar����
        private ARPoseService _arService;

        //�۾��ڿռ��е�pose
        private ARPose _arpose;

        //air2 �۾��� fov,�Ƽ�����Ϊ13.9f
        [SerializeField] private float _fieldOfView = 13.9f;

        //ar״̬���ı�
        [SerializeField] private Text _arstatus;

        private void OnEnable()
        {
            //Ĭ��ѡ�� InitARService ��ť
            GameObject.Find("UI Canvas/Buttons/InitAR").GetComponent<Button>().Select();
            _arstatus.text = "ar��δ��ʼ��";
        }

        private void Update()
        {
            //��ȡar��arpose
            if(_arService != null && _arService.isARPoseServiceRuning)
            {
                _arpose = _arService.GetARPose();
            }

            //˫���Ҵ������˳�app
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit(0);
            }
        }

        private void LateUpdate()
        {
            //ͨ��ar�ṩ��arpose�޸�camera
            if (_arService.isARPoseServiceRuning)
            {
                Camera.main.transform.position = _arpose.position;
                Camera.main.transform.rotation = _arpose.rotation;
            }
        }

        #region ARͨ���¼�
        public void InitARService()
        {
            _arService = new ARPoseService(Camera.main, _fieldOfView);
            _arstatus.text = "ar���ѳ�ʼ��";
        }

        public void StartARService()
        {
            if (_arService != null)
            {
                _arService.Start();
                _arstatus.text = "ar���ѿ���";
            }
        }

        public void PauseARService()
        {
            if (_arService != null)
            {
                _arService.Pause();
                _arstatus.text = "ar������ͣ";
            }
        }

        public void ResumeARService()
        {
            if (_arService != null)
            {
                _arService.Resume();
                _arstatus.text = "ar���ѿ���";
            }
        }

        public void StopARService()
        {
            if (_arService != null)
            {
                _arService.Stop();
                _arstatus.text = "ar��������";
            }
        }

        public void GetARServiceVersion()
        {
            if (_arService != null)
            {
                string version = _arService.GetVersion();
                _arstatus.text = "ar��" + version;
            }
        }
        #endregion
    }
}
