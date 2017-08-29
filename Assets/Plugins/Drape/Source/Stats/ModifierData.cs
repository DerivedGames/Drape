﻿using Drape.Slug;
namespace Drape
{
    [System.Serializable]
    public class ModifierData : BaseStatData
    {
        public string stat;
        public int rawFlat;
        public float rawFactor;
        public int finalFlat;
        public float finalFactor;

        public ModifierData(string name, string stat) : this(name.ToSlug(), name, stat, 0, 0, 0, 0) { }

        public ModifierData(
            string name,
            string stat,
            int rawFlat,
            float rawFactor,
            int finalFlat,
            float finalFactor
        ) : this(name.ToSlug(), name, stat, rawFlat, rawFactor, finalFlat, finalFactor) { }

        public ModifierData(
            string code,
            string name, 
            string stat,
            int rawFlat,
            float rawFactor,
            int finalFlat,
            float finalFactor
        ) : base(code, name, 0)
        {
            this.stat = stat;
            this.rawFlat = rawFlat;
            this.rawFactor = rawFactor;
            this.finalFlat = finalFlat;
            this.finalFactor = finalFactor;
        }
    }
}