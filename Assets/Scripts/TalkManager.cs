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
    public GameObject optionPanel;  // 선택지 패널 (버튼이 위치한 곳)

    private string[] dialogueLines;  // 대화 내용
    private int currentLine = 0;  // 현재 대화 줄 번호

    private bool isChoosing = false;  // 선택지 화면을 표시 중인지 확인

    // 대화 시작 함수
    public void StartDialogue(string[] lines)
    {
        dialogLines = lines;
        currentLine = 0;
        dialoguePanel.SetActive(true);  // 대화창 활성화
        optionPanel.SetActive(false);  // 선택지 숨기기
        DisplayNextDialogue();  // 첫 번째 대화 출력
    }

    // 대화 내용을 출력
    void DisplayNextDialogue()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            ShowNextDialog();
        }
        else
        {
            EndDialogue();  // 대화 끝
        }
    }

    void ShowNextDialog()
    {
        // 대사 배열의 끝에 도달하면 종료
        if (currentLineIndex < dialogLines.Length - 1)
        {
            currentLineIndex++;
            dialogText.text = dialogLines[currentLineIndex];
        }
        else
        {
            dialogText.text = "끝"; // 대사가 끝난 후 처리 (혹은 다른 동작)
        }
    }

    // 선택지를 표시하는 함수
    public void ShowChoices(string choice1, string choice2, System.Action choice1Action, System.Action choice2Action)
    {
        isChoosing = true;
        optionPanel.SetActive(true);  // 선택지 패널을 표시

        // 버튼에 선택지를 설정
        optionButton1.GetComponentInChildren<Text>().text = choice1;
        optionButton2.GetComponentInChildren<Text>().text = choice2;

        // 선택지 버튼의 클릭 이벤트를 설정
        optionButton1.onClick.RemoveAllListeners();
        optionButton1.onClick.AddListener(() => { choice1Action.Invoke(); });
        optionButton2.onClick.RemoveAllListeners();
        optionButton2.onClick.AddListener(() => { choice2Action.Invoke(); });
    }

    // 대화 끝내기
    void EndDialogue()
    {
        dialoguePanel.SetActive(false);  // 대화창 숨기기
        optionPanel.SetActive(false);  // 선택지 숨기기
        // 대화 끝난 후 처리할 코드 (예: 게임 진행, 씬 전환 등)
    }
}
public GameObject dialoguePanel;  // 대화창
public Text dialogueText;  // 대화 텍스트
public Button nextButton;  // "다음" 버튼
public Button optionButton1;  // 선택지 버튼 1
public Button optionButton2;  // 선택지 버튼 2
public GameObject optionPanel;  // 선택지 패널 (버튼이 위치한 곳)

private string[] dialogueLines;  // 대화 내용
private int currentLine = 0;  // 현재 대화 줄 번호

private bool isChoosing = false;  // 선택지 화면을 표시 중인지 확인

// 대화 시작 함수
public void StartDialogue(string[] lines)
{
    dialogueLines = lines;
    currentLine = 0;
    dialoguePanel.SetActive(true);  // 대화창 활성화
    optionPanel.SetActive(false);  // 선택지 숨기기
    DisplayNextDialogue();  // 첫 번째 대화 출력
}

// 대화 내용을 출력
void DisplayNextDialogue()
{
    if (currentLine < dialogueLines.Length)
    {
        dialogueText.text = dialogueLines[currentLine];  // 현재 대화 텍스트 출력
        currentLine++;  // 다음 대화로 이동
    }
    else
    {
        EndDialogue();  // 대화 끝
    }
}

// 선택지를 표시하는 함수
public void ShowChoices(string choice1, string choice2, System.Action choice1Action, System.Action choice2Action)
{
    isChoosing = true;
    optionPanel.SetActive(true);  // 선택지 패널을 표시

    // 버튼에 선택지를 설정
    optionButton1.GetComponentInChildren<Text>().text = choice1;
    optionButton2.GetComponentInChildren<Text>().text = choice2;

    // 선택지 버튼의 클릭 이벤트를 설정
    optionButton1.onClick.RemoveAllListeners();
    optionButton1.onClick.AddListener(() => { choice1Action.Invoke(); });
    optionButton2.onClick.RemoveAllListeners();
    optionButton2.onClick.AddListener(() => { choice2Action.Invoke(); });
}

// 대화 끝내기
void EndDialogue()
{
    dialoguePanel.SetActive(false);  // 대화창 숨기기
    optionPanel.SetActive(false);  // 선택지 숨기기
                                   // 대화 끝난 후 처리할 코드 (예: 게임 진행, 씬 전환 등)
}
}

}
