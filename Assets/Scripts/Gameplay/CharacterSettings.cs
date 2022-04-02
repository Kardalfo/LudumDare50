using System;
using System.Collections.Generic;
using Diseases;

namespace Gameplay
{
    [Serializable]
    public class CharacterSettings
    {
        public List<Disease> diseases;
        public int triesAmount;
        public int tutorialPrize;
    }
}