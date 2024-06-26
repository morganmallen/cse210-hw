using System;
using System.Collections.Generic;

public class Scripture {
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text) {
        _reference = reference;
        _words = new List<Word>();

        string[] wordArray = text.Split(' ');
        foreach (string word in wordArray) {
            _words.Add(new Word(word));
        }
    }

    public void HideRandomWords(int numberToHide) {
        Random rand = new Random();
        int hiddenCount = 0;
        List<int> availableIndexes = new List<int>();

        for (int i = 0; i < _words.Count; i++) {
            if (!_words[i].IsHidden()) {
                availableIndexes.Add(i);
            }
        }

        for (int i = availableIndexes.Count - 1; i > 0; i--) {
            int j = rand.Next(i + 1);
            int temp = availableIndexes[i];
            availableIndexes[i] = availableIndexes[j];
            availableIndexes[j] = temp;
        }

        while (hiddenCount < numberToHide && availableIndexes.Count > 0) {
            int index = availableIndexes[0];
            _words[index].Hide();
            availableIndexes.RemoveAt(0);
            hiddenCount++;
        }
    }

    public string GetDisplayText() {
        List<string> displayWords = new List<string>();
        foreach (Word word in _words) {
            displayWords.Add(word.GetDisplayText());
        }
        return $"{_reference.GetDisplayText()} {string.Join(" ", displayWords)}";
    }

    public bool IsCompletelyHidden() {
        foreach (Word word in _words) {
            if (!word.IsHidden()) {
                return false;
            }
        }
        return true;
    }
}
