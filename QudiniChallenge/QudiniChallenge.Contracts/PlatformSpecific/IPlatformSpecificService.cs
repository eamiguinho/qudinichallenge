using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QudiniChallenge.Contracts.PlatformSpecific
{
    public interface IPlatformSpecificService
    {
        bool HasInternetConnection();
        string MD5Parse(string s);
    }
}
