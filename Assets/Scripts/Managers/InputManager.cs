using Assets.Scripts.Data.UnityObjects;
using Assets.Scripts.Data.ValueObjects;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Managers
{
    public class InputManager : MonoBehaviour
    {
        #region Self Variables

        #region Private Variables

        private InputData _data;
        private bool _isAvaibleForTouch, _isFirstTimeTouchTaken, _isTouching;

        private float _currentVelocity;
        private Vector3 _moveVector;
        private Vector2? _mousePosition;

        #endregion

        #endregion

        private void Awake()
        {
            _data = GetInputData();
        }
        private InputData GetInputData()
        {
            return Resources.Load<CD_Input>("Data/CD_Input").Data;
        }
        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            CoreGameSignals.Instance.onReset += OnReset;
            InputSignals.Instance.onEnableInput += OnEnableInput;
            InputSignals.Instance.onDisableInput += OnDisableInput;
        }
        
        private void OnDisableInput()
        {
            _isAvaibleForTouch = false;
        }
        private void OnEnableInput()
        {
            _isAvaibleForTouch = true;
        }
        private void OnReset()
        {
            _isAvaibleForTouch = false;
            _isFirstTimeTouchTaken = false;
            _isTouching = false;
        }

        private void OnDisable()
        {
            UnSubscribeEvents();
        }

        private void UnSubscribeEvents()
        {
            CoreGameSignals.Instance.onReset -= OnReset;
            InputSignals.Instance.onEnableInput -= OnEnableInput;
            InputSignals.Instance.onDisableInput -= OnDisableInput;
        }

        private void Update()
        {
            if (! _isAvaibleForTouch) return;

            if (Input.GetMouseButtonUp(0) && !isPointerOverUIElement())
            {
                _isTouching = false;
                InputSignals.Instance.onInputReleased?.Invoke();
                Debug.LogWarning("Executed--->OnInputReleased");
            }
            if (Input.GetMouseButtonDown(0) && !isPointerOverUIElement())
            {
                _isTouching = true;
                InputSignals.Instance.onInputTaken?.Invoke();
                Debug.LogWarning("Executed--->OnInputTaken");
                if (!_isFirstTimeTouchTaken)
                {
                    _isFirstTimeTouchTaken=true;
                    InputSignals.Instance.onFirstTouchTaken?.Invoke();
                    Debug.LogWarning("Executed--->OnFirstTouchTaken");
                }
                _mousePosition = (Vector2)Input.mousePosition;
            }
            if (Input.GetMouseButton(0) && !isPointerOverUIElement())
            {
                if (_isTouching)
                {
                    if(_mousePosition != null)
                    {
                        Vector2 mouseDeltaPosition = (Vector2)Input.mousePosition - _mousePosition.Value;
                        if (mouseDeltaPosition.x > _data.HorizontalInputSpeed)
                        {
                            _moveVector.x = _data.HorizontalInputSpeed / 10f * mouseDeltaPosition.x;
                        }
                        else if (mouseDeltaPosition.x < _data.HorizontalInputSpeed)
                        {
                            _moveVector.x = -_data.HorizontalInputSpeed /10f * mouseDeltaPosition.x;
                        }
                        else//parmaðý kaldýrýdýðýnda yavaþ yavaþ ortaya(sýfýr noktasýna) gitsin.tak diye gitmesin
                        {
                            _moveVector.x = Mathf.SmoothDamp(-_moveVector.x, 0f, ref _currentVelocity, _data.ClampSpeed);
                        }

                        _mousePosition = (Vector2)Input.mousePosition;
                        InputSignals.Instance.onInputDragged?.Invoke(new Keys.HorizontalInputParams()
                        {
                            HorizontalValue = _moveVector.x,
                            ClampValues = _data.ClampValues,
                        });
                    }
                }
            }
        }
        private bool isPointerOverUIElement()
        {
            PointerEventData eventData = new PointerEventData(EventSystem.current);
            eventData.position = (Vector2)Input.mousePosition;
            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventData, results);
            return results.Count > 0;
        }
    }
}