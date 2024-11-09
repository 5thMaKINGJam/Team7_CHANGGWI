using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class TalkManager : MonoBehaviour
{
    public GameObject TalkPanel;  
    public Text dialogueText;  
    public Button optionButton1;  
    public Button optionButton2;  
    public GameObject optionPanel;  // ������ �г� (��ư�� ��ġ�� ��)

    private string[] dialogueLines;  // ��ȭ ����
    private int currentLine = 0;  // ���� ��ȭ �� ��ȣ

    private bool isChoosing = false;  // ������ ȭ���� ǥ�� ������ Ȯ��

    // ��ȭ ���� �Լ�
    public void StartDialogue(string[] lines)
    {
        dialogLines = lines;
        currentLine = 0;
        dialoguePanel.SetActive(true);  // ��ȭâ Ȱ��ȭ
        optionPanel.SetActive(false);  // ������ �����
        DisplayNextDialogue();  // ù ��° ��ȭ ���
    }

    // ��ȭ ������ ���
    void DisplayNextDialogue()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            ShowNextDialog();
        }
        else
        {
            EndDialogue();  // ��ȭ ��
        }
    }

    void ShowNextDialog()
    {
        // ��� �迭�� ���� �����ϸ� ����
        if (currentLineIndex < dialogLines.Length - 1)
        {
            currentLineIndex++;
            dialogText.text = dialogLines[currentLineIndex];
        }
        else
        {
            dialogText.text = "��"; // ��簡 ���� �� ó�� (Ȥ�� �ٸ� ����)
        }
    }

    // �������� ǥ���ϴ� �Լ�
    public void ShowChoices(string choice1, string choice2, System.Action choice1Action, System.Action choice2Action)
    {
        isChoosing = true;
        optionPanel.SetActive(true);  // ������ �г��� ǥ��

        // ��ư�� �������� ����
        optionButton1.GetComponentInChildren<Text>().text = choice1;
        optionButton2.GetComponentInChildren<Text>().text = choice2;

        // ������ ��ư�� Ŭ�� �̺�Ʈ�� ����
        optionButton1.onClick.RemoveAllListeners();
        optionButton1.onClick.AddListener(() => { choice1Action.Invoke(); });
        optionButton2.onClick.RemoveAllListeners();
        optionButton2.onClick.AddListener(() => { choice2Action.Invoke(); });
    }

    // ��ȭ ������
    void EndDialogue()
    {
        dialoguePanel.SetActive(false);  // ��ȭâ �����
        optionPanel.SetActive(false);  // ������ �����
        // ��ȭ ���� �� ó���� �ڵ� (��: ���� ����, �� ��ȯ ��)
    }
}
public GameObject dialoguePanel;  // ��ȭâ
public Text dialogueText;  // ��ȭ �ؽ�Ʈ
public Button nextButton;  // "����" ��ư
public Button optionButton1;  // ������ ��ư 1
public Button optionButton2;  // ������ ��ư 2
public GameObject optionPanel;  // ������ �г� (��ư�� ��ġ�� ��)

private string[] dialogueLines;  // ��ȭ ����
private int currentLine = 0;  // ���� ��ȭ �� ��ȣ

private bool isChoosing = false;  // ������ ȭ���� ǥ�� ������ Ȯ��

// ��ȭ ���� �Լ�
public void StartDialogue(string[] lines)
{
    dialogueLines = lines;
    currentLine = 0;
    dialoguePanel.SetActive(true);  // ��ȭâ Ȱ��ȭ
    optionPanel.SetActive(false);  // ������ �����
    DisplayNextDialogue();  // ù ��° ��ȭ ���
}

// ��ȭ ������ ���
void DisplayNextDialogue()
{
    if (currentLine < dialogueLines.Length)
    {
        dialogueText.text = dialogueLines[currentLine];  // ���� ��ȭ �ؽ�Ʈ ���
        currentLine++;  // ���� ��ȭ�� �̵�
    }
    else
    {
        EndDialogue();  // ��ȭ ��
    }
}

// �������� ǥ���ϴ� �Լ�
public void ShowChoices(string choice1, string choice2, System.Action choice1Action, System.Action choice2Action)
{
    isChoosing = true;
    optionPanel.SetActive(true);  // ������ �г��� ǥ��

    // ��ư�� �������� ����
    optionButton1.GetComponentInChildren<Text>().text = choice1;
    optionButton2.GetComponentInChildren<Text>().text = choice2;

    // ������ ��ư�� Ŭ�� �̺�Ʈ�� ����
    optionButton1.onClick.RemoveAllListeners();
    optionButton1.onClick.AddListener(() => { choice1Action.Invoke(); });
    optionButton2.onClick.RemoveAllListeners();
    optionButton2.onClick.AddListener(() => { choice2Action.Invoke(); });
}

// ��ȭ ������
void EndDialogue()
{
    dialoguePanel.SetActive(false);  // ��ȭâ �����
    optionPanel.SetActive(false);  // ������ �����
                                   // ��ȭ ���� �� ó���� �ڵ� (��: ���� ����, �� ��ȯ ��)
}
}

}
