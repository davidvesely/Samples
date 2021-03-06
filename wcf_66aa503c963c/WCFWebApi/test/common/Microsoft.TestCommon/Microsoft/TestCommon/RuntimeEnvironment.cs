﻿// <copyright>
//   Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>

namespace Microsoft.TestCommon
{
    using System;
    using Microsoft.Win32;

    public static class RuntimeEnvironment
    {
        private const string NetFx40FullSubKey = @"SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full";
        private const string Version = "Version";

        static RuntimeEnvironment()
        {
            object runtimeVersion = Registry.LocalMachine.OpenSubKey(RuntimeEnvironment.NetFx40FullSubKey).GetValue(RuntimeEnvironment.Version);
            string versionFor40String = runtimeVersion as string;
            if (versionFor40String != null)
            {
                VersionFor40 = new Version(versionFor40String);
            }
        }

        private static Version VersionFor40;

        public static bool IsVersion45Installed
        {
            get
            {
                return VersionFor40.Major > 4 || (VersionFor40.Major == 4 && VersionFor40.Minor >= 5);
            }
        }
    }
}
