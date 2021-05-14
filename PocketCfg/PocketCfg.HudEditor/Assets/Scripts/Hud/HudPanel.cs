using UnityEngine;

namespace PocketCfg.HudEditor.Hud
{
    public class HudPanel : MonoBehaviour
    {
        protected SpriteRenderer Renderer;
        protected bool Dirty;

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
    }
}