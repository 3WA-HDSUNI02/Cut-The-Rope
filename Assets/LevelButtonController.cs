using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using TMPro;

public class LevelButtonController : ButtonBase, IPointerClickHandler
{
    private int _buildIndex = -1;
    private string _sceneName;

    [SerializeField]
    private TextMeshProUGUI _buttonTextMesh;

    public void Init(int buildIndex, string sceneName)
    {
        _buildIndex = buildIndex;
        _sceneName = sceneName;

        if(!string.IsNullOrEmpty(_sceneName))
            _buttonTextMesh.text = _sceneName.Replace("_", " ");
    }

    #region IPointer Interfaces Methods
    public void OnPointerClick(PointerEventData eventData)
    {
        if (_buildIndex == -1)
        {
            Debug.LogError("LevelButtonController:: BuildIndex has a value of -1");
            return;
        }

        Debug.Log($"Load scene {_sceneName} with buildindex {_buildIndex}");
        SceneManager.LoadScene(_buildIndex);
    }
    #endregion
}
