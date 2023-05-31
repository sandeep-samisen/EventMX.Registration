using System.Globalization;
using CsvHelper;
using EventMX.Registration.Application.Common.Interfaces;
using EventMX.Registration.Infrastructure.Files.Maps;

namespace EventMX.Registration.Infrastructure.Files;

public class CsvFileBuilder : ICsvFileBuilder
{
    //public byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records)
    //{
    //    using var memoryStream = new MemoryStream();
    //    using (var streamWriter = new StreamWriter(memoryStream))
    //    {
    //        using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);

    //        csvWriter.Context.RegisterClassMap<TodoItemRecordMap>();
    //        csvWriter.WriteRecords(records);
    //    }

    //    return memoryStream.ToArray();
    //}
}
