using System;
using System.Collections.Generic;

class Program
{
    static List<Note> notes = new List<Note>();
    static int currentDateIndex = 0;
    static int selectedNoteIndex = 0;

    static void Main(string[] args)
    {
        InitializeNotes();

        while (true)
        {
            Console.Clear();
            DisplayMenu();

            ConsoleKeyInfo keyInfo = Console.ReadKey();
            HandleKeyPress(keyInfo.Key);
        }
    }
    static void InitializeNotes()
    {
        notes.Add(new Note("Заметка 1", "Сходить в магазин", new DateTime(2023, 10, 17)));
        notes.Add(new Note("Заметка 2", "Сходить в магазин", new DateTime(2023, 10, 17)));
        notes.Add(new Note("Заметка 1", "Забронировать номер в отеле в Турции", new DateTime(2023, 10, 18)));
        notes.Add(new Note("Заметка 2", "Посетить музей", new DateTime(2023, 10, 18)));
        notes.Add(new Note("Заметка 1", "Навестить родителей", new DateTime(2023, 10, 25)));
    }
    static void DisplayMenu()
    {
        Console.WriteLine("Ежедневник");

        DateTime currentDate = notes[currentDateIndex].Date;
        Console.WriteLine($"Дата: {currentDate.ToShortDateString()}\n");

        for (int i = 0; i < notes.Count; i++)
        {
            if (notes[i].Date.Date == currentDate.Date)
            {
                string noteTitle = (i == selectedNoteIndex) ? $"> {notes[i].Title}" : notes[i].Title;
                Console.WriteLine(noteTitle);
            }
        }
    }
    static void HandleKeyPress(ConsoleKey key)
    {
        switch (key)
        {
            case ConsoleKey.LeftArrow:
                ChangeDate(-1);
                break;

            case ConsoleKey.RightArrow:
                ChangeDate(1);
                break;

            case ConsoleKey.UpArrow:
                ChangeNoteSelection(-1);
                break;

            case ConsoleKey.DownArrow:
                ChangeNoteSelection(1);
                break;

            case ConsoleKey.Enter:
                DisplayNoteDetails();
                break;
        }
    }
    static void ChangeDate(int increment)
    {
        currentDateIndex += increment;
        if (currentDateIndex < 0)
            currentDateIndex = notes.Count - 1;
        else if (currentDateIndex >= notes.Count)
            currentDateIndex = 0;

        selectedNoteIndex = 0;
    }

    static void ChangeNoteSelection(int increment)
    {
        selectedNoteIndex += increment;
        if (selectedNoteIndex < 0)
            selectedNoteIndex = notes.Count - 1;
        else if (selectedNoteIndex >= notes.Count)
            selectedNoteIndex = 0;
    }
    static void DisplayNoteDetails()
    {
        Console.Clear();
        Console.WriteLine("Полная информация о заметке\n");

        Note selectedNote = notes[selectedNoteIndex];
        Console.WriteLine($"Название: {selectedNote.Title}");
        Console.WriteLine($"Описание: {selectedNote.Description}");
        Console.WriteLine($"Дата: {selectedNote.Date.ToShortDateString()}");
        Console.WriteLine($"Когда выполнить: {selectedNote.DueDate.ToShortDateString()}");
        Console.WriteLine("\nНажмите Enter для продолжения...");
        Console.ReadLine();
    }

}