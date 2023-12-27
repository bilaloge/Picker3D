using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Commands.Level
{
        public class OnLevelDestroyerCommand
    {
        private Transform _levelHolder;

        public OnLevelDestroyerCommand(Transform levelHolder)
        {
            _levelHolder = levelHolder;
        }
        public void Execute(byte levelIndex)// son kýsým hariç prefab in clonunu oluþturmaya yarýyor
        {
            /*var levelObject = */
            Object.Instantiate(original: Resources.Load<GameObject>(path: $"Prefabs/LevelPrefabs/Level {levelIndex}"), _levelHolder, worldPositionStays: true);
            //levelObject.transform.SetParent(_levelHolder); ya _levelholder,wordpos... yazýcaksýn, ya da yorum satýrýndakileri. oluþturulan objeleri LevelHolderýn altýna çocuk olarak atamaya yarýyor
        }
    }
}