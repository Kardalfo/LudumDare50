using System;
using System.Collections.Generic;
using Diseases;

namespace Gameplay
{
    [Serializable]
    public class CharacterSettings
    {
        public List<DiseaseType> diseasesTypes;
        public int triesAmount;
        public int tutorialPrize;
    }
}