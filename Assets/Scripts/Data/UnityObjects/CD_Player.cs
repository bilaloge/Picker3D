﻿

using Assets.Scripts.Data.ValueObjects;
using UnityEngine;

namespace Assets.Scripts.Data.UnityObjects
{
    [CreateAssetMenu(fileName = "CD_Player", menuName = "Picker3D/CD_Player", order = 0)]
    public class CD_Player : ScriptableObject
    {
        public PlayerData Data;
    }
}
