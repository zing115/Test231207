
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json;
using TestProject1.Models;

namespace TestProject1;

[TestClass]
public class UnitTest1
{
  [TestMethod]
  public void TestMethod1()
  {
    var sb = new StringBuilder();
    {
      var a = new TestModel00();
      string? BankNo = a.GetType().GetProperties().FirstOrDefault(get => get.Name == nameof(BankNo))?.CustomAttributes.FirstOrDefault()?.AttributeType.Name;
      string? UniqueCodeNullable = a.GetType().GetProperties().FirstOrDefault(get => get.Name == nameof(UniqueCodeNullable))?.CustomAttributes.FirstOrDefault()?.AttributeType.Name;
      a.SetStringColumnsNullToEmpty();
      sb.AppendLine(JsonSerializer.Serialize(a));
    }
    {
      var a = new BankData();
      string? BankNo = a.GetType().GetProperties().FirstOrDefault(get => get.Name == nameof(BankNo))?.CustomAttributes.FirstOrDefault()?.AttributeType.Name;
      string? UniqueCodeNullable = a.GetType().GetProperties().FirstOrDefault(get => get.Name == nameof(UniqueCodeNullable))?.CustomAttributes.FirstOrDefault()?.AttributeType.Name;
      a.SetStringColumnsNullToEmpty();
      sb.AppendLine(JsonSerializer.Serialize(a));
    }
    {
      var a = new BankDTO();
      string? BankNo = a.GetType().GetProperties().FirstOrDefault(get => get.Name == nameof(BankNo))?.CustomAttributes.FirstOrDefault()?.AttributeType.Name;
      string? UniqueCodeNullable = a.GetType().GetProperties().FirstOrDefault(get => get.Name == nameof(UniqueCodeNullable))?.CustomAttributes.FirstOrDefault()?.AttributeType.Name;
      a.SetStringColumnsNullToEmpty();
      sb.AppendLine(JsonSerializer.Serialize(a));
    }
    {
      var a = new TestModel();
      string? BankNo = a.GetType().GetProperties().FirstOrDefault(get => get.Name == nameof(BankNo))?.CustomAttributes.FirstOrDefault()?.AttributeType.Name;
      string? UniqueCodeNullable = a.GetType().GetProperties().FirstOrDefault(get => get.Name == nameof(UniqueCodeNullable))?.CustomAttributes.FirstOrDefault()?.AttributeType.Name;
      a.SetStringColumnsNullToEmpty();
      sb.AppendLine(JsonSerializer.Serialize(a));
    }
    Assert.Inconclusive(@$"

{sb}

");

  }

}

public static class ObjectExtension
{
  /// <summary>
  /// 類別裡的 string? 欄位, 如果其值為 null 則設定為 "" String.Empty 空字串
  /// </summary>
  /// <param name="model"></param>
  /// <param name="defaultNullToEmptyValue"></param>
  public static void SetStringColumnsNullToEmpty<T>(this T model, string defaultNullToEmptyValue = "")
  {
    if (model is not null)
    {
      foreach (var propertyInfo in model.GetType().GetProperties())
      {
        var fieldName = propertyInfo.Name;
        string? NullableAttribute = model.GetType().GetProperties().FirstOrDefault(get => get.Name == fieldName)?.CustomAttributes.FirstOrDefault(e => e.AttributeType.Name == "NullableAttribute")?.AttributeType.Name;
        if (propertyInfo.GetValue(model) is null // 值為 null
          && propertyInfo.PropertyType.Name.ToLower() == typeof(string).Name.ToLower() // 型別為 string
          && NullableAttribute == nameof(NullableAttribute) // string? => "NullableAttribute"
        )
        {
          propertyInfo.SetValue(model, defaultNullToEmptyValue);
        }
      }
    }
  }
}

public partial class TestModel00
{
  public string? UniqueCodeNullable { get; set; }
  public string BankNo { get; set; } = null!;
}

public partial class TestModel
{
  public string? UniqueNo { get; set; }

  public long Seq { get; set; }

  public string CaseNo { get; set; } = null!;

  public string CaseBNo { get; set; } = null!;

  public string? EstatesCustTypeCode { get; set; }

  public string? EstateOwnerTypeCode { get; set; }
  public string CaseBNo00 { get; set; } = null!;
  public string CaseBNo01 { get; set; } = null!;
  public string CaseBNo02 { get; set; } = null!;
  //public string EstatesCustTypeCode01 { get; set; }
  public string? EstatesCustTypeCode02 { get; set; }
  public string? EstatesCustTypeCode03 { get; set; }
  //public string? EstatesCustTypeCode04 { get; set; }
  public string? EstatesCustTypeCode00 { get; set; }
  //public string? EstatesCustTypeCode05 { get; set; }
}
