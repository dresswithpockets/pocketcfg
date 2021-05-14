using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using UnityEngine;

namespace PocketCfg.HudEditor.Hud
{
    public class HudPanel : MonoBehaviour
    {
        protected SpriteRenderer Renderer;
        protected bool Dirty;
        public List<PropertyInfo> Properties { get; } = new List<PropertyInfo>();

        private void Start()
        {
            Renderer = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            if (!Dirty) return;
            Think();
            Dirty = false;
        }

        protected virtual void Think()
        {
        }

        protected virtual void AddProperty<TBase, T>(TBase entry, Func<TBase, T> expression)
        {
            var properties = typeof(TBase).GetProperties().Where(p => p.CanRead);
            Properties.AddRange(properties);
        }
    }
}