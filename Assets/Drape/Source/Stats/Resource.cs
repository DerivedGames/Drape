﻿using System.Collections.Generic;
using Drape.Interfaces;
using Drape.Slug;

namespace Drape
{
    public class Resource : BaseStat<Resource, ResourceData>, IStat, IUpdatable
    {
        private float _qty;
        public IStat Capacity { get; private set; }
        public IStat Output { get; private set; }

        public Resource(ResourceData data, IRegistry registry) : base(data, registry)
        {
            _qty = data.value;
            this.Capacity = registry.Get<IStat>(data.capacity);
            this.Output = registry.Get<IStat>(data.output);
        }

        public override float Value { get { return _qty; } }

        public void Update(float deltaTime)
        {
            float produced = Output.Value * deltaTime;
            float newValue = _qty + produced;
            _qty = newValue > Capacity.Value ? Capacity.Value : newValue;
        }

        public void DisposeAll()
        {
            Dispose(-1);
        }

        public void Dispose(float value = 0) 
        {
            _qty = value < 0 ? 0 : _qty - value;
            if (_qty < 0) {
                _qty = 0;
            }
        }
        
        public void Restore(float value = 0)
        {
            float cap = Capacity.Value;
            _qty = value < 0 ? cap : _qty + value;
            if (_qty > cap) {
                _qty = cap;
            }
        }

        public void RestoreAll()
        {
            Restore(-1);
        }
    }
}