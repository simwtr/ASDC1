using System;
using System.IO;

public class Record
{
    public int Id { get; set; }  // уникальный ключевой поле
    public string Name { get; set; }
    public int Age { get; set; }
    public bool IsActive { get; set; }
    public double Salary { get; set; }

    public Record()
    {
        Id = 0;
        Name = "";
        Age = 0;
        IsActive = false;
        Salary = 0.0;
    }

    public Record(Record other)
    {
        Id = other.Id;
        Name = other.Name;
        Age = other.Age;
        IsActive = other.IsActive;
        Salary = other.Salary;
    }

    public Record clone()
    {
        return new Record(this);
    }

    public bool Equals(Record other)
    {
        if (other == null) return false;
        return Id == other.Id && Name == other.Name && Age == other.Age && IsActive == other.IsActive && Salary == other.Salary;
    }

    public void WriteToStream(TextWriter stream)
    {
        stream.WriteLine($"ID: {Id}, Имя: {Name}, Возраст: {Age}, Активен: {IsActive}, Зарплата: {Salary}");
    }

    public static Record ReadFromStream(TextReader stream)
    {
        var record = new Record();
        var fields = stream.ReadLine().Split(';');
        record.Id = int.Parse(fields[0]);
        record.Name = fields[1];
        record.Age = int.Parse(fields[2]);
        record.IsActive = bool.Parse(fields[3]);
        record.Salary = double.Parse(fields[4]);
        return record;
    }
}

class Program {
    static void Main() {
        var records = new Record[50];

        using (var file = new StreamReader("records.txt"))
        {
            for (int i = 0; i < 50; i++)
            {
                records[i] = Record.ReadFromStream(file);
            }
        }

        foreach (var record in records)
        {
            record.WriteToStream(Console.Out);
        }
    }
}
