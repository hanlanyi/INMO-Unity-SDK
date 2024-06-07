using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace inmo.unity.sdk
{
    public class InmoRingButtonGuide : MonoBehaviour
    {
        //�������ʾ�ַ���
        private string[] _tips;

        //�������ʾ�ı���
        [SerializeField]
        private Text _tipsText;

        //��ѡ��
        [SerializeField]
        private Toggle _comfirmClickToggle;
        [SerializeField]
        private Toggle _backClickToggle;
        [SerializeField]
        private Toggle _upArrowToggle;
        [SerializeField]
        private Toggle _downArrowToggle;
        [SerializeField]
        private Toggle _leftArrowToggle;
        [SerializeField]
        private Toggle _rightArrowToggle;

        //ָ������ָ��ҳ������
        [SerializeField]
        private GameObject _specialGuide;

        private void Awake()
        {
            //��ʼ����ʾ�ַ������Ա�ʹ��
            _tips = new string[] {
                Language.GetInstance().GetText(26),
                Language.GetInstance().GetText(27),
                Language.GetInstance().GetText(28),
                Language.GetInstance().GetText(29),
                Language.GetInstance().GetText(30),
                Language.GetInstance().GetText(31),
                Language.GetInstance().GetText(32)
            };
        }

        private void Start()
        {
            //չʾ��һ����ʾ
            _tipsText.text = _tips[0];
        }

        private void Update()
        {
            //�����س�����ӳ��ָ�����м����ȷ�ϰ�ť��
            if (Input.GetKeyDown(KeyCode.Return))
            {
                _comfirmClickToggle.isOn = true;
            }

            //����ESC����ӳ��ָ���ķ��ؼ������ذ�ť��
            if (_comfirmClickToggle.isOn && Input.GetKeyDown(KeyCode.Escape))
            {
                _backClickToggle.isOn = true;
            }

            //������ͷ����ӳ��ָ���ļ�ͷ��ť
            if (_backClickToggle.isOn && Input.GetKeyDown(KeyCode.UpArrow))
            {
                _upArrowToggle.isOn = true;
            }
            if (_upArrowToggle.isOn && Input.GetKeyDown(KeyCode.DownArrow))
            {
                _downArrowToggle.isOn = true;
            }
            if (_downArrowToggle.isOn && Input.GetKeyDown(KeyCode.LeftArrow))
            {
                _leftArrowToggle.isOn = true;
            }
            if (_leftArrowToggle.isOn && Input.GetKeyDown(KeyCode.RightArrow))
            {
                _rightArrowToggle.isOn = true;
            }

            //������Esc������ָ������ָ��
            if (_rightArrowToggle.isOn && Input.GetKeyDown(KeyCode.Escape))
            {
                gameObject.SetActive(false);
                _specialGuide.SetActive(true);
            }
        }

        private void LateUpdate()
        {
            //����״̬��չʾ��Ӧ����ʾ�ַ���
            if (_comfirmClickToggle.isOn)
            {
                _tipsText.text = _tips[1];
            }

            if (_backClickToggle.isOn)
            {
                _tipsText.text = _tips[2];
            }

            if (_upArrowToggle.isOn)
            {
                _tipsText.text = _tips[3];
            }

            if (_downArrowToggle.isOn)
            {
                _tipsText.text = _tips[4];
            }

            if (_leftArrowToggle.isOn)
            {
                _tipsText.text = _tips[5];
            }
            if (_rightArrowToggle.isOn)
            {
                _tipsText.text = _tips[6];
            }
        }
    }
}
