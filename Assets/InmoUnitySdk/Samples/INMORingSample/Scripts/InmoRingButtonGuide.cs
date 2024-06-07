using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace inmo.unity.sdk
{
    public class InmoRingButtonGuide : MonoBehaviour
    {
        //界面的提示字符串
        private string[] _tips;

        //界面的提示文本框
        [SerializeField]
        private Text _tipsText;

        //单选框
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

        //指环特殊指南页面引用
        [SerializeField]
        private GameObject _specialGuide;

        private void Awake()
        {
            //初始化提示字符串，以备使用
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
            //展示第一条提示
            _tipsText.text = _tips[0];
        }

        private void Update()
        {
            //监听回车键，映射指环的中间键（确认按钮）
            if (Input.GetKeyDown(KeyCode.Return))
            {
                _comfirmClickToggle.isOn = true;
            }

            //监听ESC键，映射指环的返回键（返回按钮）
            if (_comfirmClickToggle.isOn && Input.GetKeyDown(KeyCode.Escape))
            {
                _backClickToggle.isOn = true;
            }

            //监听箭头键，映射指环的箭头按钮
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

            //最后监听Esc键，打开指环特殊指南
            if (_rightArrowToggle.isOn && Input.GetKeyDown(KeyCode.Escape))
            {
                gameObject.SetActive(false);
                _specialGuide.SetActive(true);
            }
        }

        private void LateUpdate()
        {
            //根据状态，展示对应的提示字符串
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
