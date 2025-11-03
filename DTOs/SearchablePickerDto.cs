using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongManager.Desktop.DTOs
{
    public sealed record class SearchablePickerDto
    {
        public int Id { get; set; }
        public string DisplayText { get; set; } = string.Empty;
    }
}
