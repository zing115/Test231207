using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestProject1.Models
{
  public partial class BankDTO
  {
    public string BankNo { get; set; } = null!;
    public string BankNo1 { get; set; } = null!;
    public string BankNo2 { get; set; } = null!;
    public string BankNo3 { get; set; } = null!;
    public string BankNo4 { get; set; } = null!;

    public string? UniqueCodeNullable { get; set; }
    public string? UniqueCodeNullable1 { get; set; }
    public string? UniqueCodeNullable2 { get; set; }
    public string? UniqueCodeNullable3 { get; set; }
  }
}
