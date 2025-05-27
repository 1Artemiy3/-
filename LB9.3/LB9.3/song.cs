using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

public class Song
{
    public string Title { get; set; } = "";
    public string Author { get; set; } = "";
    public string Composer { get; set; } = "";
    public int Year { get; set; }
    public string Lyrics { get; set; } = "";
    public List<string> Performers { get; set; } = new();

    public override string ToString() =>
        $"Назва: {Title}\nАвтор: {Author}\nКомпозитор: {Composer}\nРік: {Year}\nВиконавці: {string.Join(", ", Performers)}\n";
}

public class SongManager
{
    private List<Song> songs = new();

    public void AddSong()
    {
        var song = new Song();
        Console.Write("Назва: "); song.Title = Console.ReadLine() ?? "";
        Console.Write("Автор: "); song.Author = Console.ReadLine() ?? "";
        Console.Write("Композитор: "); song.Composer = Console.ReadLine() ?? "";

        Console.Write("Рік: ");
        if (int.TryParse(Console.ReadLine(), out int year))
        {
            song.Year = year;
        }
        else
        {
            Console.WriteLine("Некоректний рік. Встановлено значення за замовчуванням (0).");
            song.Year = 0;
        }

        Console.Write("Текст: "); song.Lyrics = Console.ReadLine() ?? "";

        Console.WriteLine("Виконавці (Enter для завершення):");
        string p;
        while (!string.IsNullOrEmpty(p = Console.ReadLine()))
        {
            song.Performers.Add(p);
        }

        songs.Add(song);
        Console.WriteLine("Додано!");
    }

    public void DeleteSong()
    {
        ShowAll();
        Console.Write($"Номер для видалення (1-{songs.Count}): ");
        if (int.TryParse(Console.ReadLine(), out int i) && i > 0 && i <= songs.Count)
        {
            songs.RemoveAt(i - 1);
            Console.WriteLine("Видалено!");
        }
    }

    public void EditSong()
    {
        ShowAll();

        Console.Write($"Номер для редагування (1-{songs.Count}): ");
        if (int.TryParse(Console.ReadLine(), out int i) && i > 0 && i <= songs.Count)
        {
            var s = songs[i - 1];
            Console.Write($"Назва ({s.Title}): "); var t = Console.ReadLine(); if (!string.IsNullOrEmpty(t)) s.Title = t;
            Console.Write($"Автор ({s.Author}): "); t = Console.ReadLine(); if (!string.IsNullOrEmpty(t)) s.Author = t;
            Console.Write($"Композитор ({s.Composer}): "); t = Console.ReadLine(); if (!string.IsNullOrEmpty(t)) s.Composer = t;
            Console.Write($"Рік ({s.Year}): "); if (int.TryParse(Console.ReadLine(), out int y)) s.Year = y;
            Console.WriteLine("Змінено!");
        }
    }

    public void Search()
    {
        Console.WriteLine("1-Назва 2-Автор 3-Композитор 4-Рік 5-Виконавець");
        var choice = Console.ReadLine();
        List<Song> results = choice switch
        {
            "1" => GetSearchResults(s => s.Title),
            "2" => GetSearchResults(s => s.Author),
            "3" => GetSearchResults(s => s.Composer),
            "4" => GetYearResults(),
            "5" => GetPerformerResults(),
            _ => new()
        };
        ShowResults(results);
    }

    private List<Song> GetSearchResults(Func<Song, string> selector)
    {
        Console.Write("Пошук: ");
        var term = Console.ReadLine() ?? "";
        return songs.Where(s => selector(s).Contains(term, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    private List<Song> GetYearResults()
    {
        Console.Write("Рік: ");
        return int.TryParse(Console.ReadLine(), out int year) ? songs.Where(s => s.Year == year).ToList() : new();
    }

    private List<Song> GetPerformerResults()
    {
        Console.Write("Виконавець: ");
        var term = Console.ReadLine() ?? "";
        return songs.Where(s => s.Performers.Any(p => p.Contains(term, StringComparison.OrdinalIgnoreCase))).ToList();
    }

    public void ShowByPerformer()
    {
        Console.Write("Виконавець: ");
        var performer = Console.ReadLine() ?? "";
        var results = songs.Where(s => s.Performers.Any(p => p.Contains(performer, StringComparison.OrdinalIgnoreCase))).ToList();
        Console.WriteLine($"Пісні {performer}:");
        results.ForEach(s => Console.WriteLine($"- {s.Title} ({s.Year})"));
    }

    public void ShowAll()
    {
        if (!songs.Any()) { Console.WriteLine("Пусто!"); return; }
        for (int i = 0; i < songs.Count; i++)
            Console.WriteLine($"{i + 1}. {songs[i]}");
    }

    private void ShowResults(List<Song> results)
    {
        if (results.Any()) results.ForEach(Console.WriteLine);
        else Console.WriteLine("Не знайдено!");
    }

    public void Save()
    {
        Console.Write("Файл (songs.json): ");
        var file = Console.ReadLine();
        if (string.IsNullOrEmpty(file)) file = "songs.json";
        try
        {
            File.WriteAllText(file, JsonSerializer.Serialize(songs, new JsonSerializerOptions { WriteIndented = true }));
            Console.WriteLine("Збережено!");
        }
        catch (Exception e) { Console.WriteLine($"Помилка: {e.Message}"); }
    }

    public void Load()
    {
        Console.Write("Файл (songs.json): ");
        var file = Console.ReadLine();
        if (string.IsNullOrEmpty(file)) file = "songs.json";
        try
        {
            if (File.Exists(file))
            {
                songs = JsonSerializer.Deserialize<List<Song>>(File.ReadAllText(file)) ?? new();
                Console.WriteLine($"Завантажено {songs.Count} пісень!");
            }
            else Console.WriteLine("Файл не знайдено!");
        }
        catch (Exception e) { Console.WriteLine($"Помилка: {e.Message}"); }
    }

    public void Run()
    {

        songs.Add(new Song { Title = "Hate You", Author = "Jim Yosef", Composer = "Jim Yosef", Year = 2018, Performers = new() { "Jim Yosef", "RIELL" } });

        while (true)
        {
            Console.Clear();
            Console.WriteLine($"=== ПІСНІ ({songs.Count}) ===");
            Console.WriteLine("1-Додати\n 2-Видалити\n 3-Змінити\n 4-Пошук\n 5-Всі\n 6-За виконавцем\n 7-Зберегти\n 8-Завантажити\n 0-Вихід");

            switch (Console.ReadLine())
            {
                case "1": AddSong(); break;
                case "2": DeleteSong(); break;
                case "3": EditSong(); break;
                case "4": Search(); break;
                case "5": ShowAll(); break;
                case "6": ShowByPerformer(); break;
                case "7": Save(); break;
                case "8": Load(); break;
                case "0": return;
            }
            Console.ReadKey();
        }
    }
}
