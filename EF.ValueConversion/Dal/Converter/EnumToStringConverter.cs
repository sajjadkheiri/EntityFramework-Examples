using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EF.ValueConversion;

public class EmployeeTypeEnumToStringConverter : ValueConverter<EmployeeTypeEnum, string>
{
    public EmployeeTypeEnumToStringConverter() : base(x => x.ToString(), c => (EmployeeTypeEnum)int.Parse(c))
    {
    }
}
