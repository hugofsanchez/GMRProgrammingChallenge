using UnityEngine;

public class DataInitializer : MonoBehaviour
{
    public GameObject _mainScreenEventManager;

    private DataManager _dataManager;

    void Start()
    {
        _dataManager = DataManager.Instance;
        _dataManager.StartLoadingData(_mainScreenEventManager);
    }
}
