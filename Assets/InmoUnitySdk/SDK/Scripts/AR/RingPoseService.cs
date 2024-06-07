using UnityEngine;
namespace inmo.unity.sdk{
    /// <summary>
    /// 提供指环姿态的类
    /// </summary>
    public class RingPoseService
    {
        /// <summary>
        /// 安卓对象
        /// </summary>
        private AndroidJavaObject androidJavaObject;

        /// <summary>
        /// 安卓类
        /// </summary>
        private AndroidJavaClass androidJavaClass;

        /// <summary>
        /// 3dof服务是否开启
        /// </summary>
        public bool isRingThreeDofServiceRuning;

        /// <summary>
        /// float数组类型的3dof源数据
        /// </summary>
        private float[] ringThreeDofData;

        /// <summary>
        /// 完成转换的四元数
        /// </summary>
        private Quaternion transformRingThreeDof;

        /// <summary>
        /// 指环的姿态
        /// </summary>
        private Quaternion ringPose;

        /// <summary>
        /// 重置时的四元数的逆
        /// </summary>
        private Quaternion inverseRingThreeDof;

        public RingPoseService()
        {
            ringPose = Quaternion.identity;
            inverseRingThreeDof = Quaternion.identity;
            androidJavaObject = new AndroidJavaObject("com.inmolens.nativetools.RingThreeDofUtils");
            androidJavaClass = new AndroidJavaClass("com.inmolens.nativetools.RingThreeDofUtils");
            androidJavaObject.Call("init");
        }

        public void Start()
        {
            isRingThreeDofServiceRuning = androidJavaObject.Call<bool>("startRingThreeDof");
        }

        public void Stop()
        {
            isRingThreeDofServiceRuning = false;
            androidJavaObject.Call("stopRingThreeDof");
        }

        public void Pause()
        {
            androidJavaObject.Call("pauseRingThreeDof");
        }

        public void Resume()
        {
            androidJavaObject.Call("resumeRingThreeDof");
        }

        /// <summary>
        /// 获取指环在Unity世界坐标系下的姿态
        /// </summary>
        /// <returns>已转换到Unity左手坐标系姿态数据</returns>
        public Quaternion GetRingPose()
        {
            if (!isRingThreeDofServiceRuning)
            {
                return Quaternion.identity;
            }
            //使用AndroidJavaClass调用静态本地方法获取更好的性能
            ringThreeDofData = androidJavaClass.CallStatic<float[]>("getRingThreeData");
            transformRingThreeDof[0] = -ringThreeDofData[0];
            transformRingThreeDof[1] = -ringThreeDofData[2];
            transformRingThreeDof[2] = -ringThreeDofData[1];
            transformRingThreeDof[3] = ringThreeDofData[3];
            if (inverseRingThreeDof != Quaternion.identity)
            {
                ringPose = inverseRingThreeDof * transformRingThreeDof;
            }else
            {
                ringPose = transformRingThreeDof;
            }

            return ringPose;
        }

        /// <summary>
        /// 重置3dof数据
        /// </summary>
        public void ResetRingPose()
        {
            inverseRingThreeDof = Quaternion.Inverse(transformRingThreeDof);
        }

        /// <summary>
        /// 获取指环源数据姿态
        /// </summary>
        /// <returns>未进行坐标系转换的指环姿态</returns>
        public Quaternion GetOriginRingPose()
        {
            if (!isRingThreeDofServiceRuning)
            {
                return Quaternion.identity;
            }

            ringThreeDofData = androidJavaClass.CallStatic<float[]>("getRingThreeData");
            transformRingThreeDof[0] = ringThreeDofData[0];
            transformRingThreeDof[1] = ringThreeDofData[1];
            transformRingThreeDof[2] = ringThreeDofData[2];
            transformRingThreeDof[3] = ringThreeDofData[3];
            if (inverseRingThreeDof != Quaternion.identity)
            {
                ringPose = inverseRingThreeDof * transformRingThreeDof;
            }
            else
            {
                ringPose = transformRingThreeDof;
            }
            return ringPose;
        }

        /// <summary>
        /// 获取指环3dof数组数据
        /// </summary>
        /// <returns>3dof源数据</returns>
        public float[] GetRingThreeDofData()
        {
            if (!isRingThreeDofServiceRuning)
            {
                return ringThreeDofData;
            }

            ringThreeDofData = androidJavaClass.CallStatic<float[]>("getRingThreeData");
            return ringThreeDofData;
        }
    }
}
