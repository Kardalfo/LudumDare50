using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Characters
{
    [Serializable]
    public class TrySettings
    {
        [SerializeField] private int diseasesAmount;
        [SerializeField] private int minTries;
        [SerializeField] private int maxTries;

        public int DiseaseAmount => diseasesAmount;
        

        public int GetRandomTriesAmount()
        {
            var triesAmount = Random.Range(minTries, maxTries);
            return triesAmount;
        }
    }
}