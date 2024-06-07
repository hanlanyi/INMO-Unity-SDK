using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Air2 Glass Left Touch Pad Guide
/// Air2�۾�������ָ��
/// </summary>
namespace inmo.unity.sdk {
    public class LeftTouchPadGuide : MonoBehaviour
    {
        //ScrollView�ڵ�Content
        [SerializeField]
        private RectTransform _scrollviewContentRT;

        //ҳ��ָʾ���ı�
        [SerializeField]
        private Text _indicateText;

        //ҳ������
        [SerializeField]
        private int _pageCount;

        //����ָ������
        [SerializeField]
        private GameObject _otherGuide;

        //��ǰչʾ��ҳ���±�ֵ
        private int currentIndex = 0;

        private void Update()
        {
            //�����Ҵ����廬����ҳ����
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                currentIndex++;
            }

            //�����Ҵ����廬����ҳ���һ�
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                currentIndex--;
            }

            //����˫���Ҵ����壬������ָ��
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                gameObject.SetActive(false);
                _otherGuide.SetActive(true);
            }
        }

        //ƽ�����л�ҳ��
        private Vector2 currentVelocity;
        private void LateUpdate()
        {
            if (currentIndex < 0)
            {
                currentIndex = 0;
            }

            if(currentIndex >= _pageCount)
            {
                currentIndex = _pageCount - 1;
            }

            _indicateText.text = string.Format("{0}/{1}", currentIndex + 1, _pageCount);

            _scrollviewContentRT.anchoredPosition = Vector2.SmoothDamp(
                _scrollviewContentRT.anchoredPosition, 
                new Vector2(currentIndex * -400, 0), 
                ref currentVelocity,0.5f);
        }


    }
}
