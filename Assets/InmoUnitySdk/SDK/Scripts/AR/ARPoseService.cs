using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace inmo.unity.sdk
{
    /// <summary>
    /// �ṩ�Ӿ����ٹ��ܵ���
    /// </summary>
    public class ARPoseService
    {
        public struct ARPose
        {
            public Vector3 position;
            public Quaternion rotation;
        }

        /// <summary>
        /// �۾���̬
        /// </summary>
        private ARPose arPose;

        /// <summary>
        /// ��׿����
        /// </summary>
        private AndroidJavaObject androidJavaObject;

        /// <summary>
        /// ��׿��
        /// </summary>
        private AndroidJavaClass androidJavaClass;

        /// <summary>
        /// ARService�Ƿ�������,���Ƿ������Ӿ�����
        /// </summary>
        public bool isARPoseServiceRuning;

        /// <summary>
        /// float�������͵�6dofԴ����
        /// </summary>
        private float[] arSixDofData;

        /// <summary>
        /// ����arservice���󡣽�arcamera��field of view����Ϊ����ʵ�13.9
        /// </summary>
        /// <param name="camera">������ʵ��ARЧ����Camera</param>
        /// <param name="fov">ARCamera��field of view���Ƽ�����Ϊ13.9</param>
        public ARPoseService(Camera camera,float fov = 13.9f)
        {
            AndroidJavaObject context = new AndroidJavaClass("com.unity3d.player.UnityPlayer")
                .GetStatic<AndroidJavaObject>("currentActivity");
            androidJavaObject = new AndroidJavaObject("com.arglasses.arsdk.ArServiceSession", context);
            androidJavaClass = new AndroidJavaClass("com.arglasses.arsdk.ArServiceSession");
            if(camera != null)
            {
                camera.fieldOfView = fov;
            }
        }

        public void Start()
        {
            arPose = new ARPose();
            arSixDofData = new float[7];
            isARPoseServiceRuning = androidJavaObject.Call<bool>("create");
        }

        public void Stop()
        {
            isARPoseServiceRuning = false;
            androidJavaObject.Call("destroy");
        }

        public void Pause()
        {
            isARPoseServiceRuning = false;
            androidJavaObject.Call("pause");
        }

        public void Resume()
        {
            isARPoseServiceRuning = true;
            androidJavaObject.Call("resume");
        }

        public string GetVersion()
        {
            return androidJavaObject.Call<string>("getVersion");
        }

        /// <summary>
        /// ��ȡ�۾���Unity��������ϵ�µ���̬
        /// </summary>
        /// <returns>��ת����Unity��������ϵ��̬����</returns>
        public ARPose GetARPose()
        {
            if(!isARPoseServiceRuning)
            {
                return arPose;
            }
            arSixDofData = androidJavaClass.CallStatic<float[]>("getPose");

            arPose.position.x = arSixDofData[0];
            arPose.position.y = arSixDofData[2];
            arPose.position.z = arSixDofData[1];

            arPose.rotation.x = -arSixDofData[3];
            arPose.rotation.y = -arSixDofData[5];
            arPose.rotation.z = -arSixDofData[4];
            arPose.rotation.w = arSixDofData[6];

            return arPose;
        }

        /// <summary>
        /// ��ȡԴ������̬
        /// </summary>
        /// <returns>δ��������ϵת������̬</returns>
        public ARPose GetOriginARPose()
        {
            if (!isARPoseServiceRuning)
            {
                return arPose;
            }
            arSixDofData = androidJavaClass.CallStatic<float[]>("getPose");

            arPose.position.x = arSixDofData[0];
            arPose.position.y = arSixDofData[1];
            arPose.position.z = arSixDofData[2];

            arPose.rotation.x = arSixDofData[3];
            arPose.rotation.y = arSixDofData[4];
            arPose.rotation.z = arSixDofData[5];
            arPose.rotation.w = arSixDofData[6];

            return arPose;
        }

        /// <summary>
        /// ��ȡԴ����6dof����
        /// </summary>
        /// <returns>6dofԴ����</returns>
        public float[] GetOriginSixDofData()
        {
            if (!isARPoseServiceRuning)
            {
                return arSixDofData;
            }
            arSixDofData = androidJavaClass.CallStatic<float[]>("getPose");
            return arSixDofData;
        }
    }
}
