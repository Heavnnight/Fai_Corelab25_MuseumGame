using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class NoteController : MonoBehaviour
{
    [Header("Input")]
    [SerializeField] private KeyCode closeKey = KeyCode.Mouse1;
    [SerializeField] private KeyCode nextKey = KeyCode.RightArrow;
    [SerializeField] private KeyCode prevKey = KeyCode.LeftArrow;

    [Header("Player (optional like in tutorial)")]
    [SerializeField] private GameObject player;

    [Header("UI")]
    [SerializeField] private GameObject noteCanvas;
    [SerializeField] private TMP_Text noteTextUI;
    [SerializeField] private Button nextButton;
    [SerializeField] private Button prevButton;
    [SerializeField] private TMP_Text pageCounter;

    [Header("Pages (Text only)")]
    [TextArea] public List<string> pages = new List<string>();

    [Header("Events")]
    [SerializeField] private UnityEvent openEvent;

    private bool isOpen = false;
    private int pageIndex = 0;
    private MonoBehaviour[] cachedControlScripts;

    void Awake()
    {
        // Link buttons if they exist
        if (nextButton) nextButton.onClick.AddListener(NextPage);
        if (prevButton) prevButton.onClick.AddListener(PrevPage);

        // Automatically find and cache player control scripts
        if (player)
        {
            var names = new HashSet<string>{
                "FirstPersonLook","FirstPersonMovement","FirstPersonController",
                "StarterAssetsInputs","PlayerInput"
            };
            cachedControlScripts = player.GetComponentsInChildren<MonoBehaviour>(true)
                                         .Where(mb => mb && names.Contains(mb.GetType().Name))
                                         .ToArray();
        }
    }

    public void ShowNote(int startPage = 0)
    {
        pageIndex = Mathf.Clamp(startPage, 0, Mathf.Max(0, pages.Count - 1));
        if (noteCanvas) noteCanvas.SetActive(true);
        openEvent?.Invoke();
        TogglePlayer(false);
        isOpen = true;
        RefreshUI();

       
        Time.timeScale = 0f;
    }

    private void CloseNote()
    {
        if (noteCanvas) noteCanvas.SetActive(false);
        TogglePlayer(true);
        isOpen = false;

        
        Time.timeScale = 1f;
    }

    private void TogglePlayer(bool enable)
    {
        if (cachedControlScripts != null)
            foreach (var mb in cachedControlScripts) mb.enabled = enable;

        Cursor.lockState = enable ? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = !enable;
    }

    private void RefreshUI()
    {
        // Update text
        if (noteTextUI)
            noteTextUI.text = (pages.Count > 0) ? pages[pageIndex] : "";

        // Update page counter
        if (pageCounter)
            pageCounter.text = (pages.Count > 0) ? $"{pageIndex + 1} / {pages.Count}" : "";

        // Enable/disable buttons
        bool hasPrev = pageIndex > 0;
        bool hasNext = pageIndex < pages.Count - 1;
        if (prevButton) prevButton.interactable = hasPrev;
        if (nextButton) nextButton.interactable = hasNext;
    }

    public void NextPage()
    {
        if (pageIndex < pages.Count - 1)
        {
            pageIndex++;
            RefreshUI();
        }
    }

    public void PrevPage()
    {
        if (pageIndex > 0)
        {
            pageIndex--;
            RefreshUI();
        }
    }

    void Update()
    {
        if (!isOpen) return;

        if (Input.GetKeyDown(closeKey)) CloseNote();
        if (Input.GetKeyDown(nextKey)) NextPage();
        if (Input.GetKeyDown(prevKey)) PrevPage();
    }
}
