using System;
using Enums;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

namespace Data.ValueObject
{
    [Serializable]
    public class MiniGameData
    {
        public Vector3 cubeScale;

        public GameObject cubePrefab;

        public float indexMaxFactor = 100.0f;

        public float colliderSize = 2.0f;

        public float colliderCenter = 0.5f;

        public int maxMoneyValue = Enum.GetValues(typeof(CollectableTypes)).Length;
    }
}

