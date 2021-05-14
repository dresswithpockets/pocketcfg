using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PocketCfg.HudEditor.Hud
{
    public class HealthPanel : HudPanel
    {
        private int _health;
        private int _maxHealth;

        public int MaxHealth
        {
            get => _maxHealth;
            set
            {
                _maxHealth = value;
                Dirty = true;
            }
        }

        public int Health
        {
            get => _health;
            set
            {
                _health = value;
                Dirty = true;
            }
        }

        private void Awake()
        {
            AddProperty(this, e => e.Health);
            AddProperty(this, e => e.MaxHealth);
        }

        protected override void Think()
        {
            Renderer.size = new Vector2(1f, Mathf.Clamp01(_health / (float) MaxHealth));
            
            // TODO: load and use HealthDeathWarningColor
        }
    }
}
