using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{

    //private InputField inputField;

    void Start()
    {
        //Debug.Log(this);
        //inputField = GetComponent<InputField>();
    }

    //public void InputLogger()
    //{

    //    string inputValue = inputField.text;
    //    Debug.Log(inputValue);
    //}

    public void InitInputField()
    {

        // 値をリセット
        InputField inputField = GetComponent<InputField>();
        inputField.text = "";
    }

    public void setInputField(string value)
    {
        InputField inputField = GetComponent<InputField>();
        inputField.text = value;
    }

    public string getInputField()
    {
        InputField inputField = GetComponent<InputField>();
        return inputField.text;
    }

    public void setActivateInputField()
    {
        InputField inputField = GetComponent<InputField>();
        inputField.ActivateInputField();
    }
}