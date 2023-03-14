using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class TeacherManager : MonoBehaviour
{
    [SerializeField] string initialPassword;
    string currentPassword;
    [SerializeField] TMP_InputField passwordField;
    [SerializeField] TMP_InputField newPasswordField;
    [SerializeField] UnityEvent correctEvent;

    private void Awake()
    {
        if (Password.LoadPassword() == null)
        {
            Password.ChangePassword(initialPassword);
        }
    }

    public void ChangePassword()
    {
        if (newPasswordField.text == null || newPasswordField.text == "")
            return;
        string newPassword = newPasswordField.text;
        Password.ChangePassword(newPassword);
    }
    public void SetPassword(string newPassword)
    {
        Password.ChangePassword(newPassword);
    }

    public void VerificatePassword()
    {
        if (passwordField.text == null || passwordField.text == "")
            return;
        string correctPassword = Password.LoadPassword();
        string enterPassword = passwordField.text;
        if (correctPassword == enterPassword)
        {
            correctEvent.Invoke();
        }
    }

}
