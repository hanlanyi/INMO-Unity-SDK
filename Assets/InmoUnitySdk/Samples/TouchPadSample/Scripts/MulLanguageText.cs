using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace inmo.unity.sdk {
    public class MulLanguageText : MonoBehaviour
    {
        [SerializeField] private int _id;

        private void OnEnable()
        {
            Text _text = GetComponent<Text>();
            _text.text = Language.GetInstance().GetText(_id);
        }
    }
}
