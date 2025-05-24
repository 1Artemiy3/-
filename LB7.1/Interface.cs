using System;

public interface IContainer<TElement>
{
    // Кількість елементів у контейнері
    int Count { get; }

    // Індексатор контейнера
    object this[int index] { get; set; }

    
    void Add(TElement element);

    // Видалити елемент з контейнеру
    void Delete(TElement element);
}

public interface IFileContainer<TElement> : IContainer<TElement>
{
  
    void Save(string fileName);

    // Завантажити дані з текстового файлу до контейнера
    void Load(string fileName);

    
    bool IsDataSaved { get; }
}