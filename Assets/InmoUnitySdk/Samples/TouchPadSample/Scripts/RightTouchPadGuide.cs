using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Air2 Glass Left Touch Pad Guide
/// Air2�۾�������ָ��
/// </summary>
namespace inmo.unity.sdk
{
    public class RightTouchPadGuide : MonoBehaviour
    {
        //�������ʾ�ַ���
        private string[] _tips;

        //�������ʾ�ı���
        [SerializeField]
        private Text _tipsText;

        //��ѡ��
        [SerializeField]
        private Toggle _singleClickToggle;
        [SerializeField]
        private Toggle _doubleClickToggle;
        [SerializeField]
        private Toggle _upScrollToggle;
        [SerializeField]
        private Toggle _downScrollToggle;
        [SerializeField]
        private Toggle _forwardScrollToggle;
        [SerializeField]
        private Toggle _backScrollToggle;

        //������ָ��ҳ������
        [SerializeField]
        private GameObject _leftTouchPadGuide;

        private void Awake()
        {
            //��ʼ����ʾ�ַ������Ա�ʹ��
            _tips = new string[] {
            Language.GetInstance().GetText(1),
            Language.GetInstance().GetText(2),
            Language.GetInstance().GetText(3),
            Language.GetInstance().GetText(4),
            Language.GetInstance().GetText(5),
            Language.GetInstance().GetText(6),
            Language.GetInstance().GetText(7),
        };
        }

        private void Start()
        {
            //չʾ��һ����ʾ
            _tipsText.text = _tips[0];
        }

        private void Update()
        {
            //�����س�����ӳ�䵥���Ҵ����壨ȷ�ϰ�ť��
            if (Input.GetKeyDown(KeyCode.Return))
            {
                _singleClickToggle.isOn = true;
            }

            //����ESC����ӳ��˫���Ҵ����壨���ذ�ť��
            if (_singleClickToggle.isOn && Input.GetKeyDown(KeyCode.Escape))
            {
                _doubleClickToggle.isOn = true;
            }

            //������ͷ����ӳ�䵥ָ���Ҵ������ϻ���
            if (_doubleClickToggle.isOn && Input.GetKeyDown(KeyCode.UpArrow))
            {
                _upScrollToggle.isOn = true;
            }
            if (_upScrollToggle.isOn && Input.GetKeyDown(KeyCode.DownArrow))
            {
                _downScrollToggle.isOn = true;
            }
            if (_downScrollToggle.isOn && Input.GetKeyDown(KeyCode.LeftArrow))
            {
                _forwardScrollToggle.isOn = true;
            }
            if (_forwardScrollToggle.isOn && Input.GetKeyDown(KeyCode.RightArrow))
            {
                _backScrollToggle.isOn = true;
            }

            //������Esc������������ָ��
            if (_backScrollToggle.isOn && Input.GetKeyDown(KeyCode.Escape))
            {
                gameObject.SetActive(false);
                _leftTouchPadGuide.SetActive(true);
            }
        }

        private void LateUpdate()
        {
            //����״̬��չʾ��Ӧ����ʾ�ַ���
            if (_singleClickToggle.isOn)
            {
                _tipsText.text = _tips[1];
            }

            if (_doubleClickToggle.isOn)
            {
                _tipsText.text = _tips[2];
            }

            if (_upScrollToggle.isOn)
            {
                _tipsText.text = _tips[3];
            }

            if (_downScrollToggle.isOn)
            {
                _tipsText.text = _tips[4];
            }

            if (_forwardScrollToggle.isOn)
            {
                _tipsText.text = _tips[5];
            }

            if (_backScrollToggle.isOn)
            {
                _tipsText.text = _tips[6];
            }

            
        }
    }
}
