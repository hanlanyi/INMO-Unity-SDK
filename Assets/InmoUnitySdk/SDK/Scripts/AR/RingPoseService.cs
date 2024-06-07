using UnityEngine;
namespace inmo.unity.sdk{
    /// <summary>
    /// �ṩָ����̬����
    /// </summary>
    public class RingPoseService
    {
        /// <summary>
        /// ��׿����
        /// </summary>
        private AndroidJavaObject androidJavaObject;

        /// <summary>
        /// ��׿��
        /// </summary>
        private AndroidJavaClass androidJavaClass;

        /// <summary>
        /// 3dof�����Ƿ���
        /// </summary>
        public bool isRingThreeDofServiceRuning;

        /// <summary>
        /// float�������͵�3dofԴ����
        /// </summary>
        private float[] ringThreeDofData;

        /// <summary>
        /// ���ת������Ԫ��
        /// </summary>
        private Quaternion transformRingThreeDof;

        /// <summary>
        /// ָ������̬
        /// </summary>
        private Quaternion ringPose;

        /// <summary>
        /// ����ʱ����Ԫ������
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
        /// ��ȡָ����Unity��������ϵ�µ���̬
        /// </summary>
        /// <returns>��ת����Unity��������ϵ��̬����</returns>
        public Quaternion GetRingPose()
        {
            if (!isRingThreeDofServiceRuning)
            {
                return Quaternion.identity;
            }
            //ʹ��AndroidJavaClass���þ�̬���ط�����ȡ���õ�����
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
        /// ����3dof����
        /// </summary>
        public void ResetRingPose()
        {
            inverseRingThreeDof = Quaternion.Inverse(transformRingThreeDof);
        }

        /// <summary>
        /// ��ȡָ��Դ������̬
        /// </summary>
        /// <returns>δ��������ϵת����ָ����̬</returns>
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
        /// ��ȡָ��3dof��������
        /// </summary>
        /// <returns>3dofԴ����</returns>
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
