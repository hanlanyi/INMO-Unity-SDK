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
        //��ť�������log�ı�
        [SerializeField] private Text _LogClick;

        //��ť��ѡ�е�log�ı�
        [SerializeField] private Text _LogSelect;

        //Ĭ��ѡ�еİ�ť
        [SerializeField] private Button _selectedButton;

        private void OnEnable()
        {
            //ѡ��Ĭ�ϰ�ť��������log�ı�
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

            //��������������±�ѡ�еİ�ť�ı�
            else if (Input.anyKeyDown)
            {
                _LogSelect.text = EventSystem.current.currentSelectedGameObject.name + " is selected!";
            }
        }

        //��ť�ĵ���¼�
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
