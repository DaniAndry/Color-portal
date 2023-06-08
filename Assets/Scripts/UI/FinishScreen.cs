using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinishScreen : MonoBehaviour
{
    [SerializeField] private StepCounter _stepCounter;
    [SerializeField] private TextMeshProUGUI _string;

    private int _needStepCount;
    private string[] WinStrings = new string[]
    { "���� �����!",
"����� �������!",
"�����������!",
"������ �����!",
"����� ������!",
"�� ������!",
"������ ����� !",
"��� � �����!",
"������!",
"������ �����������!",
"�� ��������!",
"���������� ����������!",
"����������!",
"�������������� ����������!",
"�� �����������!",
"����������� �����!",
"��������� ��!",
"������ ������ ����!",
"������ ����������!"
    };

    private string[] LoseStrings = new string[]
    { "����� ���� �������!",
   "�� ������ �����!",
   "�������, �� ����� �����!",
   "��� ������� � �����!",
   "����� ��������",
   "������ � ������������!",
   "�� �� ������ ����",
    };

    private void OnEnable()
    {
        _needStepCount = 9;
        SelectString();
    }

    private void SelectString()
    {
        if (_stepCounter.StepCount <= _needStepCount)
        {
            _string.text = WinStrings[Random.Range(0, WinStrings.Length)];
        }
        else
        {
            _string.text = LoseStrings[Random.Range(0, LoseStrings.Length)];
        }
    }
}
