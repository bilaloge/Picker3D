
using Assets.Scripts.Signals;
using DG.Tweening;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Scripts.Controllers.UI
{
    public class LevelPanelController :MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private List<Image> stageImage= new List<Image>();
        [SerializeField] private List<TextMeshProUGUI> levelTexts = new List<TextMeshProUGUI>();
        #endregion


        #endregion
        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            UISignals.instance.onSetLevelValue += OnSetLevelValue;
            UISignals.instance.onSetStageColor += OnSetStageColor;
        }

        private void OnSetLevelValue(byte levelValue)
        {
            var additionalValue = ++levelValue;
            levelTexts[0].text = additionalValue.ToString();
            additionalValue++;
            levelTexts[1].text = additionalValue.ToString();
        }
        private void OnSetStageColor(byte stageValue)
        {
            stageImage[stageValue].DOColor(new Color(0.5529412f, 0.5529412f, 0.227451f), 0.5f);
        }
        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        private void UnsubscribeEvents()
        {
            UISignals.instance.onSetLevelValue -= OnSetLevelValue;
            UISignals.instance.onSetStageColor -= OnSetStageColor;
        }
    }
}
