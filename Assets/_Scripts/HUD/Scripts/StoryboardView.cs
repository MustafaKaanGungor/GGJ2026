using System.Collections.Generic;
using UnityEngine;

public class StoryboardView : MonoBehaviour
{
    [SerializeField] private GameObject[] startStoryboards;
    [SerializeField] private GameObject[] endStoryboards;
    [SerializeField] private bool isWorkingOnStartStoryboards;

    private Queue<GameObject> _startStoryboardQueue;
    private Queue<GameObject> _endStoryboardQueue;
    private GameObject _lastActiveStoryboard;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isWorkingOnStartStoryboards = true;
        _startStoryboardQueue = new Queue<GameObject>(startStoryboards);
        _endStoryboardQueue = new Queue<GameObject>(endStoryboards);
        ProcessBoards();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ProcessBoards();
        }
    }

    void ProcessBoards()
    {
        if (isWorkingOnStartStoryboards)
        {
            if (_startStoryboardQueue.Count == 0)
            {
                _lastActiveStoryboard.gameObject.SetActive(false);
                return;
            }

            if (_lastActiveStoryboard != null) _lastActiveStoryboard.SetActive(false);

            var storyBoard = _startStoryboardQueue.Dequeue();
            storyBoard.SetActive(true);
            _lastActiveStoryboard = storyBoard;
        }
        else
        {
            if (_endStoryboardQueue.Count == 0)
            {
                _lastActiveStoryboard.gameObject.SetActive(false);
                return;
            }

            if (_lastActiveStoryboard != null) _lastActiveStoryboard.SetActive(false);

            var storyboard = _endStoryboardQueue.Dequeue();
            storyboard.SetActive(true);
            _lastActiveStoryboard = storyboard;
        }
    }
}