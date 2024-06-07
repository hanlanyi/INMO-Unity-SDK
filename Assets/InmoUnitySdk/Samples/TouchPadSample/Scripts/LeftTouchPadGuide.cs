using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Air2 Glass Left Touch Pad Guide
/// Air2眼镜左触摸板指南
/// </summary>
namespace inmo.unity.sdk {
    public class LeftTouchPadGuide : MonoBehaviour
    {
        //ScrollView内的Content
        [SerializeField]
        private RectTransform _scrollviewContentRT;

        //页面指示器文本
        [SerializeField]
        private Text _indicateText;

        //页面总数
        [SerializeField]
        private int _pageCount;

        //其他指南引用
        [SerializeField]
        private GameObject _otherGuide;

        //当前展示的页面下标值
        private int currentIndex = 0;

        private void Update()
        {
            //监听右触摸板滑动，页面左滑
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                currentIndex++;
            }

            //监听右触摸板滑动，页面右滑
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                currentIndex--;
            }

            //监听双击右触摸板，打开其他指南
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                gameObject.SetActive(false);
                _otherGuide.SetActive(true);
            }
        }

        //平滑的切换页面
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
