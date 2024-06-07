using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Air2 Glass Left Touch Pad Guide
/// Air2眼镜左触摸板指南
/// </summary>
namespace inmo.unity.sdk
{
    public class RightTouchPadGuide : MonoBehaviour
    {
        //界面的提示字符串
        private string[] _tips;

        //界面的提示文本框
        [SerializeField]
        private Text _tipsText;

        //单选框
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

        //左触摸板指南页面引用
        [SerializeField]
        private GameObject _leftTouchPadGuide;

        private void Awake()
        {
            //初始化提示字符串，以备使用
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
            //展示第一条提示
            _tipsText.text = _tips[0];
        }

        private void Update()
        {
            //监听回车键，映射单击右触摸板（确认按钮）
            if (Input.GetKeyDown(KeyCode.Return))
            {
                _singleClickToggle.isOn = true;
            }

            //监听ESC键，映射双击右触摸板（返回按钮）
            if (_singleClickToggle.isOn && Input.GetKeyDown(KeyCode.Escape))
            {
                _doubleClickToggle.isOn = true;
            }

            //监听箭头键，映射单指在右触摸板上滑动
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

            //最后监听Esc键，打开左触摸板指南
            if (_backScrollToggle.isOn && Input.GetKeyDown(KeyCode.Escape))
            {
                gameObject.SetActive(false);
                _leftTouchPadGuide.SetActive(true);
            }
        }

        private void LateUpdate()
        {
            //根据状态，展示对应的提示字符串
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
