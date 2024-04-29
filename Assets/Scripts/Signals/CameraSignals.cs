using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Signals
{
    public class CameraSignals : MonoBehaviour
    {
        #region Singleton

        public static CameraSignals instance;
        private void Awake()
        {
            if (instance != null && instance != this)
            {
                Destroy(gameObject);
                return;
            }
            instance = this;
        }
        #endregion

        public UnityAction onSetCameraTarget = delegate { };
    }
}
