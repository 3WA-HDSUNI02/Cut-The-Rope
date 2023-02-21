using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    #region Singleton
    private static EventManager _instance;
    public static EventManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("EventManager");
                _instance = go.AddComponent<EventManager>();
            }
            return _instance;
        }
    }
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    #endregion

    #region Actions
    public UnityAction<HingeJoint2D> onChainBreak;
    public UnityAction onCandyOutOfBounds;
    #endregion

    #region Methods
    public void OnChainBreak(HingeJoint2D lastJoint)
    {
        if (onChainBreak != null)
            onChainBreak(lastJoint);
    }

    public void OnCandyOutOfBounds()
    {
        if (onCandyOutOfBounds != null)
            onCandyOutOfBounds();
    }
    #endregion
}
