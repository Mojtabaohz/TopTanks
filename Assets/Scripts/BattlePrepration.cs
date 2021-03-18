using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BattlePrepration : MonoBehaviour
{
    [SerializeField]
    private Button battleButton;

    private void Start()
    {
        battleButton.onClick.AddListener(PrepareBattleScene);
    }

    void PrepareBattleScene()
    {
        SceneManager.LoadScene("PlayScene");
    }
}
