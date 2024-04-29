using System;
using UnityEngine;

namespace Assets.Scripts.Data.ValueObjects
{
    [Serializable]
    public struct PlayerData
    {
        public PlayerMovementData MovementData;
        public PlayerMashData MashData;
        public PlayerForceData ForceData;
    }
    [Serializable]
    public struct PlayerMovementData
    {
        public float ForwardSpeed;
        public float SidewaySpeed;
    }
    [Serializable]
    public struct PlayerMashData
    {
        public float ScaleCounter;
    }
    [Serializable]
    public struct PlayerForceData
    {
        public Vector3 ForceParameter;
    }
}