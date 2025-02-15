using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
/*
 * ��ư�� �������� ��ǲ�ʵ带 Ȱ��ȭ

��ư�� �ؽ�Ʈ�� ��ǲ�ʵ��� �ؽ�Ʈ�� �ű�
 */
public class DataCell : MonoBehaviour
{
    public TextMeshProUGUI buttonText;

    public TMP_InputField inputField;

    public string CellText => buttonText.text;

    private void Awake()
    {
        inputField.gameObject.SetActive(false);
    }
    public void ActiveInputFiled()
    {
        inputField.gameObject.SetActive(true);
        inputField.text = CellText;
    }

    public void InputEnd()
    {
        buttonText.text = inputField.text;
        inputField.gameObject.SetActive(false);
    }
   

}
