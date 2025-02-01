using NUnit.Framework;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibSvnSharp.Demo.Services
{
    internal class SVNService
    {
        private string host;
        private string port;

        public void Connect()
        {
            var RemoteUriTrunk = @"https://svn.apache.org/repos/asf/subversion/trunk";
            try
            {
                using (SvnClient sc = new SvnClient())
                {
                    Uri targetUri = new Uri(RemoteUriTrunk);
                    var target = SvnTarget.FromUri(targetUri);
                    Collection<SvnInfoEventArgs> info;
                    bool result = sc.GetInfo(target, new SvnInfoArgs { ThrowOnError = false }, out info);
                    Assert.That(result, Is.False);
                    Assert.That(info, Is.Empty);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}