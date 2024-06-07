using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace inmo.unity.sdk
{
    /// <summary>
    /// 提供视觉跟踪功能的类
    /// </summary>
    public class ARPoseService
    {
        public struct ARPose
        {
            public Vector3 position;
            public Quaternion rotation;
        }

        /// <summary>
        /// 眼镜姿态
        /// </summary>
        private ARPose arPose;

        /// <summary>
        /// 安卓对象
        /// </summary>
        private AndroidJavaObject androidJavaObject;

        /// <summary>
        /// 安卓类
        /// </summary>
        private AndroidJavaClass androidJavaClass;

        /// <summary>
        /// ARService是否在运行,及是否正在视觉跟踪
        /// </summary>
        public bool isARPoseServiceRuning;

        /// <summary>
        /// float数组类型的6dof源数据
        /// </summary>
        private float[] arSixDofData;

        /// <summary>
        /// 创建arservice对象。将arcamera的field of view设置为最合适的13.9
        /// </summary>
        /// <param name="camera">场景里实现AR效果的Camera</param>
        /// <param name="fov">ARCamera的field of view，推荐设置为13.9</param>
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
        /// 获取眼镜在Unity世界坐标系下的姿态
        /// </summary>
        /// <returns>已转换到Unity左手坐标系姿态数据</returns>
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
        /// 获取源数据姿态
        /// </summary>
        /// <returns>未进行坐标系转换的姿态</returns>
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
        /// 获取源数据6dof数组
        /// </summary>
        /// <returns>6dof源数据</returns>
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
