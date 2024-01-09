using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Commands.Level
{
    public class OnLevelLoaderCommand
    {
        private Transform _levelHolder;

        internal OnLevelLoaderCommand(Transform levelHolder)
        {
            _levelHolder = levelHolder;
        }
        internal void Execute(byte levelIndex)// son kýsým hariç prefab in clonunu oluþturmaya yarýyor
        {
            /*var levelObject = */Object.Instantiate(original: Resources.Load<GameObject>(path: $"Prefabs/LevelPrefabs/Level {levelIndex}"), _levelHolder, worldPositionStays: true);
            //levelObject.transform.SetParent(_levelHolder); ya _levelholder,wordpos... yazýcaksýn, ya da yorum satýrýndakileri.
        }
    }
}