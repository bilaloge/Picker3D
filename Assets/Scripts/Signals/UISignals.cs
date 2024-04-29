using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Signals
{
    public class UISignals : MonoBehaviour
    {
        #region Singlton

        public static UISignals instance;

        private void Awake()
        {
            if(instance !=null && instance != this)
            {
                Destroy(gameObject);
                return;
            }
            instance = this;
        }

        #endregion

        public UnityAction<byte> onSetStageColor = delegate { };
        public UnityAction<byte> onSetLevelValue = delegate { };
        public UnityAction onPlay = delegate { };
    }
}
