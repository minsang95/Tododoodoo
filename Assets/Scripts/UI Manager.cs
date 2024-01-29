using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{   // UI
    [SerializeField] private GameObject MainScreen;
    [SerializeField] private GameObject Options;
    [SerializeField] private GameObject ResultScreen;
    [SerializeField] private GameObject Pause;
    [SerializeField] private GameObject GameExit;
    [SerializeField] private GameObject PlayScreen;
    [SerializeField] private GameObject PlayerUpgrade;
    [SerializeField] private GameObject GameOver;
    // 오디오믹서, 볼륨조절 슬라이드
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider masterVolume_slider;
    [SerializeField] private Slider bgm_slider;
    [SerializeField] private Slider sfx_slider;

    public static UIManager Instance;

    private void Awake()
    {
        Instance = this;

        masterVolume_slider = masterVolume_slider.GetComponent<Slider>();
        bgm_slider = bgm_slider.GetComponent<Slider>();
        sfx_slider = sfx_slider.GetComponent<Slider>();

        masterVolume_slider.onValueChanged.AddListener(SetMasterVolume);
        bgm_slider.onValueChanged.AddListener(SetBgmVolume);
        sfx_slider.onValueChanged.AddListener(SetSfxVolume);
    }
    private void Start()
    {// 볼륨, 볼륨 슬라이더 셋팅 PlayerPrefs 저장값으로 초기화
        masterVolume_slider.value = PlayerPrefs.GetFloat("MasterVolume");
        bgm_slider.value = PlayerPrefs.GetFloat("BgmVolume");
        sfx_slider.value = PlayerPrefs.GetFloat("SfxVolume");

        audioMixer.SetFloat("Master", Mathf.Log10(PlayerPrefs.GetFloat("MasterVolume")) * 20);
        audioMixer.SetFloat("BGM", Mathf.Log10(PlayerPrefs.GetFloat("BgmVolume")) * 20);
        audioMixer.SetFloat("SFX", Mathf.Log10(PlayerPrefs.GetFloat("SfxVolume")) * 20);
    }
    // 볼륨 조절 및 셋팅값 저장
    public void SetMasterVolume(float value)
    {
        audioMixer.SetFloat("Master", Mathf.Log10(value) * 20);
        PlayerPrefs.SetFloat("MasterVolume", value);
    }
    public void SetBgmVolume(float value)
    {
        audioMixer.SetFloat("BGM", Mathf.Log10(value) * 20);
        PlayerPrefs.SetFloat("BgmVolume", value);
    }
    public void SetSfxVolume(float value)
    {
        audioMixer.SetFloat("SFX", Mathf.Log10(value) * 20);
        PlayerPrefs.SetFloat("SfxVolume", value);
    }
    // UI 활성화 버튼 메서드
    public void OnClickGameStartBtn()
    {
        MainScreen.SetActive(false);
        PlayScreen.SetActive(true);
        GameManager.Instance.currentState = GameManager.State.Ready;
    }
    public void OnClickOptionsBtn()
    {
        Options.SetActive(true);
    }
    public void OnClickOptionsExitBtn()
    {
        Options.SetActive(false);
    }
    public void OnClickGameExitCheckBtn()
    {
        Pause.SetActive(false);
        GameExit.SetActive(true);
    }
    public void OnClickMainScreenBtn()
    {
        SceneManager.LoadScene("UI");
        Time.timeScale = 1.0f;
    }
    public void OnClickCancelBtn()
    {
        GameExit.SetActive(false);
        Pause.SetActive(true);
    }
    public void OnClickPlayContinueBtn()
    {
        Pause.SetActive(false);
        Time.timeScale = 1.0f;
    }
    public void OnClickResultScreenExitBtn()
    {
        SceneManager.LoadScene("UI");
        Time.timeScale = 1.0f;
    }
    public void OnClickUpgradeBtn()
    {
        PlayerUpgrade.SetActive(false);
        Time.timeScale = 1.0f;
    }
    public void OnClickGameExitBtn()
    {
        GameOver.SetActive(false);
        PlayScreen.SetActive(false);
        ResultScreen.SetActive(true);
    }
    public void OnClickPause()
    {
        Time.timeScale = 0;
        Pause.SetActive(true);
    }
    public void OnClickGameOverBtn() // 게임오버 테스트용 버튼 메서드
    {
        Time.timeScale = 0;
        GameOver.SetActive(true);
    }
    public void OnClickPlayerUpgradeBtn() // 플레이어 업그레이드 테스트용 버튼 메서드
    {
        Time.timeScale = 0;
        PlayerUpgrade.SetActive(true);
    }
}
