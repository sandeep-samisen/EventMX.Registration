﻿using System.Globalization;
using EventMX.Registration.Application.TodoLists.Queries.ExportTodos;
using CsvHelper.Configuration;

namespace EventMX.Registration.Infrastructure.Files.Maps;

public class TodoItemRecordMap : ClassMap<TodoItemRecord>
{
    public TodoItemRecordMap()
    {
        AutoMap(CultureInfo.InvariantCulture);

        Map(m => m.Done).Convert(c => c.Value.Done ? "Yes" : "No");
    }
}