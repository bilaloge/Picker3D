using Commands.Level;
using Data.UnityObjects;
using Data.ValueObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
        public class LevelManager : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables
        [SerializeField] private Transform levelHolder;
        [SerializeField] private byte totalLevelCount;

        #endregion

        #region Private Variables

        private OnLevelLoaderCommand _levelLoaderCommand;
        private OnLevelDestroyerCommand _levelDestroyerCommand;

        private byte _currentLevel;
        private LevelData _levelData;

        #endregion

        #endregion
        private void Awake()
        {
            _levelData = GetLevelData();
            _currentLevel = GetActiveLevel();

            Init();
        }
        private void Init()
        {
            _levelLoaderCommand = new OnLevelLoaderCommand(levelHolder);
            _levelDestroyerCommand = new OnLevelDestroyerCommand(levelHolder);
        }
        private LevelData GetLevelData()
        {
            return Resources.Load<CD_Level>(path: "Data/CD_Level").Levels(_currentLevel);
        }
        private byte GetActiveLevel()
        {
            return _currentLevel;
        }
    }

}
