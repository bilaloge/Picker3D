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
        public void Execute(byte levelIndex)// son k�s�m hari� prefab in clonunu olu�turmaya yar�yor
        {
            /*var levelObject = */
            Object.Instantiate(original: Resources.Load<GameObject>(path: $"Prefabs/LevelPrefabs/Level {levelIndex}"), _levelHolder, worldPositionStays: true);
            //levelObject.transform.SetParent(_levelHolder); ya _levelholder,wordpos... yaz�caks�n, ya da yorum sat�r�ndakileri. olu�turulan objeleri LevelHolder�n alt�na �ocuk olarak atamaya yar�yor
        }
    }
}