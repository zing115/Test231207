
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1;

[TestClass]
public class UnitTest2
{
  [TestMethod]
  public void Test_231208_NullableAttribute_()
  {
    // 使用 pi.CustomAttributes.Any(x => x.AttributeType.Name == "NullableAttribute");
    var sb = new StringBuilder();
    sb.AppendLine();

    var a = new TestModel_1();
    sb.AppendLine($"------");
    sb.AppendLine($"{a.GetType().Name} -> ");
    sb.Append($"{a.GetType().GetProperties().FirstOrDefault(x => x.Name == nameof(a.Field_1))?.Name}: ");
    var a_Field_1_CustomAttributes = a.GetType().GetProperties().FirstOrDefault(x => x.Name == nameof(a.Field_1))?.CustomAttributes;
    sb.Append($"NullableAttribute: {a.GetType().GetProperties().FirstOrDefault(x => x.Name == nameof(a.Field_1))?.CustomAttributes.Any(x => x.AttributeType.Name == "NullableAttribute")}");
    sb.Append($" // string Field_1 ");
    sb.AppendLine();
    sb.Append($"{a.GetType().GetProperties().FirstOrDefault(x => x.Name == nameof(a.Field_2_Nullable))?.Name}: ");
    var a_Field_2_CustomAttributes = a.GetType().GetProperties().FirstOrDefault(x => x.Name == nameof(a.Field_2_Nullable))?.CustomAttributes;
    sb.Append($"NullableAttribute: {a.GetType().GetProperties().FirstOrDefault(x => x.Name == nameof(a.Field_2_Nullable))?.CustomAttributes.Any(x => x.AttributeType.Name == "NullableAttribute")}");
    sb.Append($" // string? Field_2_Nullable ");
    sb.AppendLine();

    var b = new TestModel_2();
    sb.AppendLine($"------");
    sb.AppendLine($"{b.GetType().Name} -> ");
    sb.Append($"{b.GetType().GetProperties().FirstOrDefault(x => x.Name == nameof(b.Field_1))?.Name}: ");
    var b_Field_1_CustomAttributes = b.GetType().GetProperties().FirstOrDefault(x => x.Name == nameof(b.Field_1))?.CustomAttributes;
    sb.Append($"NullableAttribute: {b.GetType().GetProperties().FirstOrDefault(x => x.Name == nameof(b.Field_1))?.CustomAttributes.Any(x => x.AttributeType.Name == "NullableAttribute")}");
    sb.Append($" // 一樣的 string Field_1 在 string 欄位數量不同時, NullableAttribute 會有不同的判斷結果");
    sb.AppendLine();
    sb.Append($"{b.GetType().GetProperties().FirstOrDefault(x => x.Name == nameof(b.Field_2_Nullable))?.Name}: ");
    var b_Field_2_CustomAttributes = b.GetType().GetProperties().FirstOrDefault(x => x.Name == nameof(b.Field_2_Nullable))?.CustomAttributes;
    sb.Append($"NullableAttribute: {b.GetType().GetProperties().FirstOrDefault(x => x.Name == nameof(b.Field_2_Nullable))?.CustomAttributes.Any(x => x.AttributeType.Name == "NullableAttribute")}");
    sb.Append($" // 一樣的 string? Field_2_Nullable 在 string 欄位數量不同時, NullableAttribute 會有不同的判斷結果");
    sb.AppendLine();
    sb.Append($"{b.GetType().GetProperties().FirstOrDefault(x => x.Name == nameof(b.Field_3_Nullable))?.Name}: ");
    var b_Field_3_CustomAttributes = b.GetType().GetProperties().FirstOrDefault(x => x.Name == nameof(b.Field_3_Nullable))?.CustomAttributes;
    sb.Append($"NullableAttribute: {b.GetType().GetProperties().FirstOrDefault(x => x.Name == nameof(b.Field_3_Nullable))?.CustomAttributes.Any(x => x.AttributeType.Name == "NullableAttribute")}");
    sb.Append($" // TestModel_2 多了一個 string 欄位會有這樣奇怪的問題");
    sb.AppendLine();
    sb.AppendLine(@$"------
不同 model class 的 string 欄位的 `數量` 會讓 
pi.CustomAttributes.Any(x => x.AttributeType.Name == ""NullableAttribute"") 的判斷出現奇怪問題
就是 `反向` 的結果
TestModel_1 
Field_1          => False
Field_2_Nullable => True
TestModel_2
Field_1          => True
Field_2_Nullable => False
Field_3_Nullable => False
");

    Assert.Inconclusive(@$"{sb}");
  }

}

public class TestModel_1
{
  public string Field_1 { get; set; } = null!;
  public string? Field_2_Nullable { get; set; }
}

public class TestModel_2
{
  public string Field_1 { get; set; } = null!;
  public string? Field_2_Nullable { get; set; }
  public string? Field_3_Nullable { get; set; }
}

