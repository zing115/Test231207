using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestProject1.Models
{
  public partial class BankData
  {
    public string? UniqueCodeNullable { get; set; }
    public string BankNo { get; set; } = null!;

  }
}
