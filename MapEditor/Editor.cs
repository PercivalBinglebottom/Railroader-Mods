using Railloader;
using Serilog;
using UnityEngine;

namespace MapEditor
{
    class Editor : MonoBehaviour
    {
        private Serilog.ILogger logger = Log.ForContext<Editor>();
        private Settings Settings
        {
            get => SingletonPluginBase<EditorMod>.Shared?.Settings ?? new Settings();
        }

        public Editor()
        {
        }

        public void OnEnable()
        {
            logger.Debug("Editor OnEnable()");
            var nodeHelpers = GetComponentInChildren<NodeHelpers>();
            if (nodeHelpers == null)
            {
                var go = new GameObject("NodeHelpers", typeof(NodeHelpers));
                go.transform.parent = transform;
            }
        }

        public void OnDisable()
        {
            logger.Debug("Editor OnDisable()");
        }

        public void Update()
        {
            var nodeHelpers = GetComponentInChildren<NodeHelpers>(true);
            if (nodeHelpers && nodeHelpers.isActiveAndEnabled != Settings.ShowNodeHelpers)
            {
                logger.Debug("Setting NodeHelpers active: {ShowNodeHelpers}", Settings.ShowNodeHelpers);
                nodeHelpers.gameObject.SetActive(Settings.ShowNodeHelpers);
            }
        }
    }
}