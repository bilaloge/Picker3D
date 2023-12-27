using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Commands.Level
{
    public class OnLevelLoaderCommand
    {
        private Transform _levelHolder;

        public OnLevelLoaderCommand(Transform levelHolder)
        {
            _levelHolder = levelHolder;
        }
        public void Execute()
        {
            if (_levelHolder.transform.childCount <= 0)
                return;
            Object.Destroy(_levelHolder.transform.GetChild(0).gameObject);
        }
    }
}