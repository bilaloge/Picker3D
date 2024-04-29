using Assets.Scripts.Signals;
using Cinemachine;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class CameraManager : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables
        [SerializeField] private CinemachineVirtualCamera virtualCamera;

        #endregion

        #region Private Variables

        private Vector3 _firstposition;

        #endregion

        #endregion

        private void Start ()
        {
            Init();
        }

        private void Init()
        {
            _firstposition = transform.position;
        }
        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            CameraSignals.instance.onSetCameraTarget += OnSetCameraTarget;
            CoreGameSignals.Instance.onReset += OnReset;
        }

       

        private void OnSetCameraTarget()
        {
            //var player = FindObjectOfType<PlayerManager>().transform;
            //virtualCamera.Follow = player;
            //virtualCamera.LookAt = player;
        }
        private void OnReset()
        {
            transform.position = _firstposition;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }
        private void UnsubscribeEvents()
        {
            CameraSignals.instance.onSetCameraTarget -= OnSetCameraTarget;
            CoreGameSignals.Instance.onReset -= OnReset;
        }
    }
}
