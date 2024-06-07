using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace inmo.unity.sdk
{
    public class MulTexts
    {
        public string text1;
        public string text2;
        public string text3;
        public string text4;
        public string text5;
        public string text6;
        public string text7;
        public string text8;
        public string text9;
        public string text10;
        public string text11;
        public string text12;
        public string text13;
        public string text14;
        public string text15;
        public string text16;
        public string text17;
        public string text18;
        public string text19;
        public string text20;
        public string text21;
        public string text22;
        public string text23;
        public string text24;
        public string text25;
        public string text26;
        public string text27;
        public string text28;
        public string text29;
        public string text30;
        public string text31;
        public string text32;
        public string text33;
        public string text34;
        public string text35;
        public string text36;
        public string text37;
        public string text38;
        public string text39;
        public string text40;
    }

    public enum LanguageType
    {
        English,
        Chinese
    }

    public class Language
    {
        private List<string> _englishText;
        private List<string> _chineseText;

        private static Language _instance;

        private LanguageType currentType;

        public static Language GetInstance()
        {
            if(_instance == null)
            {
                _instance = new Language();
            }
            return _instance;
        }

        private Language()
        {
            currentType = LanguageType.Chinese;
            _englishText = new List<string>();
            _chineseText = new List<string>();
            TextAsset english = Resources.Load<TextAsset>("Language/English");
            TextAsset chinese = Resources.Load<TextAsset>("Language/Chinese");
            MulTexts englishMulTexts = JsonUtility.FromJson<MulTexts>(english.text);
            MulTexts chineseMulTexts = JsonUtility.FromJson<MulTexts>(chinese.text);
            ToList(englishMulTexts,_englishText);
            ToList(chineseMulTexts,_chineseText);
        }

        public string GetText(int id)
        {
            switch (currentType)
            {
                case LanguageType.English:
                    return _englishText[id];
                case LanguageType.Chinese:
                    return _chineseText[id];
            }
            return null;
        }

        private void ToList(MulTexts mulTexts,List<string> strs)
        {
            strs.Add(mulTexts.text1);
            strs.Add(mulTexts.text2);
            strs.Add(mulTexts.text3);
            strs.Add(mulTexts.text4);
            strs.Add(mulTexts.text5);
            strs.Add(mulTexts.text6);
            strs.Add(mulTexts.text7);
            strs.Add(mulTexts.text8);
            strs.Add(mulTexts.text9);
            strs.Add(mulTexts.text10);
            strs.Add(mulTexts.text11);
            strs.Add(mulTexts.text12);
            strs.Add(mulTexts.text13);
            strs.Add(mulTexts.text14);
            strs.Add(mulTexts.text15);
            strs.Add(mulTexts.text16);
            strs.Add(mulTexts.text17);
            strs.Add(mulTexts.text18);
            strs.Add(mulTexts.text19);
            strs.Add(mulTexts.text20);
            strs.Add(mulTexts.text21);
            strs.Add(mulTexts.text22);
            strs.Add(mulTexts.text23);
            strs.Add(mulTexts.text24);
            strs.Add(mulTexts.text25);
            strs.Add(mulTexts.text26);
            strs.Add(mulTexts.text27);
            strs.Add(mulTexts.text28);
            strs.Add(mulTexts.text29);
            strs.Add(mulTexts.text30);
            strs.Add(mulTexts.text31);
            strs.Add(mulTexts.text32);
            strs.Add(mulTexts.text33);
            strs.Add(mulTexts.text34);
            strs.Add(mulTexts.text35);
            strs.Add(mulTexts.text36);
            strs.Add(mulTexts.text37);
            strs.Add(mulTexts.text38);
            strs.Add(mulTexts.text39);
            strs.Add(mulTexts.text40);
        }
    }
}
