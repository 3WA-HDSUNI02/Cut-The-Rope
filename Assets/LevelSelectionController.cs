using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectionController : MonoBehaviour
{
    [SerializeField]
    private GameObject _levelButtonPrefab;
    [SerializeField]
    private RectTransform _levelSelectionContent;

    private List<Level> _levels = new List<Level>();

    private VerticalLayoutGroup _verticalLayoutGroup;

    private void Awake()
    {
        _verticalLayoutGroup = _levelSelectionContent.GetComponent<VerticalLayoutGroup>();
    }

    public struct Level
    {
        public string Name;
        public int BuildIndex;
    }

    private void Start()
    {
        float contentHeight = _verticalLayoutGroup.padding.top + _verticalLayoutGroup.padding.bottom;

        // Get scenes from asset files
        foreach(EditorBuildSettingsScene buildSettingsScene in EditorBuildSettings.scenes)
        {
            string scenePath = buildSettingsScene.path;

            // Only add scenes containing relevant string (only levels)
            if(scenePath.Contains("Level_"))
            {
                string sceneName = System.IO.Path.GetFileNameWithoutExtension(scenePath);
                int buildIndex = SceneUtility.GetBuildIndexByScenePath(scenePath);

                Level level = new Level();
                level.Name = sceneName;
                level.BuildIndex = buildIndex;

                _levels.Add(level);
            }
        }

        // Do nothing if no scenes
        if (_levels.Count == 0)
        {
            Debug.LogError("LevelSelectionController needs a list of level Scenes");
            return;
        }

        // Create a Button for each level scene and initialize it with scene data
        foreach(Level level in _levels)
        {
            GameObject levelButtonGO = Instantiate(_levelButtonPrefab, _levelSelectionContent);
            LevelButtonController levelButtonController = levelButtonGO.GetComponent<LevelButtonController>();
            levelButtonController.Init(level.BuildIndex, level.Name);
            
            RectTransform _buttonRectTranform = levelButtonGO.GetComponent<RectTransform>();
            contentHeight += _buttonRectTranform.rect.height;
            contentHeight += _verticalLayoutGroup.spacing;
        }

        _levelSelectionContent.sizeDelta = new Vector2(_levelSelectionContent.rect.width, contentHeight);
    }
}
