using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinTail
{
    public static class Common
    {
        public const string STR_MyActorSystem = "MyActorSystem";
        public const string AkkaActorSystemPath = "akka://" + Common.STR_MyActorSystem + "/";
        public const string AkkaActorSystemUserPath = AkkaActorSystemPath + "user/";
    }
}
