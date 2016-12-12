using System;
using System.ComponentModel;

namespace Bandwidth.Net.Iris
{
  internal sealed class DefaultDateTimeAttribute : DefaultValueAttribute
  {
    public DefaultDateTimeAttribute()
      : base(default(DateTime))
    {
    }
  }
}
