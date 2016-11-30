using System.IO;
using System.Text;

namespace Bandwidth.Net.Iris
{
  internal class Utf8StringWriter : StringWriter
  {
    public override Encoding Encoding => Encoding.UTF8;
  }
}
