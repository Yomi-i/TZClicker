using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Currency : MonoBehaviour
{
    private const string MoneyKey = "money";
    private const string MoneyMultiplierKey = "moneyMultiplier";
    private const string LevelKey = "level";
    private const string UpgradeKey = "upgrade";


    [SerializeField] private int _moneyMultiplier;
    [SerializeField] private int _upgradeCost;
    [SerializeField] private TMP_Text _moneyMultiplierText;
    [SerializeField] private TMP_Text _moneyText;
    [SerializeField] private TMP_Text _levelText;
    [SerializeField] private TMP_Text _upgradeText;


    private int _money;
    private int _level;
    private int _upgrade;


    public Button upgradeButton;

    private void Start()
    {
        LoadData();
        UpdateUI();
        UpdateUpgradeCost();
    }

    void Update()
    {
        if (_money >= _upgradeCost)
        {
            upgradeButton.enabled = true;
        }
        else
        {
            upgradeButton.enabled = false;
        }
    }

    private void LoadData()
    {
        _money = PlayerPrefs.GetInt(MoneyKey, 0);
        _moneyMultiplier = PlayerPrefs.GetInt(MoneyMultiplierKey, 1);
        _level = PlayerPrefs.GetInt(LevelKey, 1);
        _upgrade = PlayerPrefs.GetInt(UpgradeKey, 5);
    }


    private void SaveData()
    {
        PlayerPrefs.SetInt(MoneyKey, _money);
        PlayerPrefs.SetInt(MoneyMultiplierKey, _moneyMultiplier);
        PlayerPrefs.SetInt(LevelKey, _level);
    }


    private void UpdateUI()
    {
        _moneyText.text = _money.ToString();
        _moneyMultiplierText.text = $"+{_moneyMultiplier}";
        _levelText.text = $"LVL {_level}";
        _upgradeText.text = $"Upgrade {_upgradeCost}";
    }


    public void AddMoney()
    {
        _money += _moneyMultiplier;
        SaveData();
        UpdateUI();
    }


    public void IncreaseMultiplier()
    {
        _money -= _upgradeCost;
        _moneyMultiplier++;
        _level = _moneyMultiplier;
        UpdateUpgradeCost();
        SaveData();
        UpdateUI();
    }


    private void UpdateUpgradeCost()
    {
        if (_level != 1)
        {
            _upgradeCost = _upgrade * _level;
            SaveData();
            UpdateUI();
        }
    }
}
