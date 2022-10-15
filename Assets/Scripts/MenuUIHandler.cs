using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] private InputField NameInputField;

    public void StartGame()
    {
        MenuManager.Instance.currentPlayer = NameInputField.text;

        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        MenuManager.Instance.Save();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
