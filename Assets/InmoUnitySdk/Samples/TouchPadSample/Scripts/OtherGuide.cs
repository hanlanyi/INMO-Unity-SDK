using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
namespace inmo.unity.sdk
{
    public class OtherGuide : MonoBehaviour
    {
        //按钮被点击的log文本
        [SerializeField] private Text _LogClick;

        //按钮被选中的log文本
        [SerializeField] private Text _LogSelect;

        //默认选中的按钮
        [SerializeField] private Button _selectedButton;

        private void OnEnable()
        {
            //选中默认按钮，并更改log文本
            _selectedButton.Select();
            _LogSelect.text = EventSystem.current.currentSelectedGameObject.name + " is selected!";
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if(SceneManager.GetActiveScene().name.Equals("INMORingSampleScene"))
                {
                    SceneManager.LoadScene("TouchPadSampleScene");
                }
                else if (SceneManager.GetActiveScene().name.Equals("TouchPadSampleScene"))
                {
                    SceneManager.LoadScene("ARServiceSample");
                }
            }

            //监听任意键，更新被选中的按钮文本
            else if (Input.anyKeyDown)
            {
                _LogSelect.text = EventSystem.current.currentSelectedGameObject.name + " is selected!";
            }
        }

        //按钮的点击事件
        public void ButtonClick(string id)
        {
            switch (id)
            {
                case "A":
                    _LogClick.text = "Button A clicked!";
                    break;
                case "B":
                    _LogClick.text = "Button B clicked!";
                    break;
                case "C":
                    _LogClick.text = "Button C clicked!";
                    break;
                case "D":
                    _LogClick.text = "Button D clicked!";
                    break;
                case "E":
                    _LogClick.text = "Button E clicked!";
                    break;
            }
        }


    }
}
