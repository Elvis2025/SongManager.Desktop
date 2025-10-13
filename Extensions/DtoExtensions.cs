using AutoMapper;
using SongManager.Desktop.DTOs;
using SongManager.Desktop.Models;
using SongManager.Desktop.UsesCases.Exceptions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongManager.Desktop.Extensions;

public static class DtoExtensions
{
    private static readonly IMapper mapper = SongManagerApp.CreateInstance<IMapper>();


    public static T Map<T>(this object source) where T : IBaseEntity, new()
    {
        try
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            return mapper.Map<T>(source);
        }
        catch (Exception e)
        {
            CrashLog.Write(e, "DtoExtensions.Map");
            throw new(e.Message)!;
        }
    }
    public static List<T> Map<T>(this IEnumerable source)
    {
        try
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            return mapper.Map<List<T>>(source);
        }
        catch (Exception e)
        {
            CrashLog.Write(e, "DtoExtensions.Map");
            throw new(e.Message)!;
        }
    }

}
