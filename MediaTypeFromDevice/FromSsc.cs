// /***************************************************************************
// Aaru Data Preservation Suite
// ----------------------------------------------------------------------------
//
// Filename       : FromSsc.cs
// Author(s)      : Natalia Portillo <claunia@claunia.com>
//
// Component      : Aaru common types.
//
// --[ License ] --------------------------------------------------------------
//
//     Permission is hereby granted, free of charge, to any person obtaining a
//     copy of this software and associated documentation files (the
//     "Software"), to deal in the Software without restriction, including
//     without limitation the rights to use, copy, modify, merge, publish,
//     distribute, sublicense, and/or sell copies of the Software, and to
//     permit persons to whom the Software is furnished to do so, subject to
//     the following conditions:
//
//     The above copyright notice and this permission notice shall be included
//     in all copies or substantial portions of the Software.
//
//     THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS
//     OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
//     MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
//     IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY
//     CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
//     TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE
//     SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//
// ----------------------------------------------------------------------------
// Copyright © 2011-2022 Natalia Portillo
// ****************************************************************************/

using System;
using Aaru.Console;

namespace Aaru.CommonTypes
{
    public static partial class MediaTypeFromDevice
    {
        /// <summary>Gets the media type from an SCSI Streaming Commands compliant device</summary>
        /// <param name="scsiPeripheralType">Peripheral type</param>
        /// <param name="vendor">Vendor string</param>
        /// <param name="model">Model string</param>
        /// <param name="mediumType">Medium type from MODE SENSE</param>
        /// <param name="densityCode">Density code from MODE SENSE</param>
        /// <param name="blocks">Number of blocks in media</param>
        /// <param name="blockSize">Size of a block in bytes</param>
        /// <returns>Media type</returns>
        public static MediaType GetFromSsc(byte scsiPeripheralType, string vendor, string model, byte mediumType,
                                           byte densityCode, ulong blocks, uint blockSize)
        {
            switch(mediumType)
            {
                case 0x00:
                    switch(densityCode)
                    {
                        case 0x04:
                            AaruConsole.DebugWriteLine("Media detection",
                                                       "SCSI medium type is {0:X2}h, density code is {1:X2}h, setting media type to QIC-11.",
                                                       mediumType, densityCode);

                            return MediaType.QIC11;
                        case 0x05:
                            AaruConsole.DebugWriteLine("Media detection",
                                                       "SCSI medium type is {0:X2}h, density code is {1:X2}h, setting media type to QIC-24.",
                                                       mediumType, densityCode);

                            return MediaType.QIC24;
                        case 0x09:
                            AaruConsole.DebugWriteLine("Media detection",
                                                       "SCSI medium type is {0:X2}h, density code is {1:X2}h, setting media type to IBM 3490.",
                                                       mediumType, densityCode);

                            return MediaType.IBM3490;
                        case 0x0F:
                            AaruConsole.DebugWriteLine("Media detection",
                                                       "SCSI medium type is {0:X2}h, density code is {1:X2}h, setting media type to QIC-120.",
                                                       mediumType, densityCode);

                            return MediaType.QIC120;
                        case 0x10:
                            AaruConsole.DebugWriteLine("Media detection",
                                                       "SCSI medium type is {0:X2}h, density code is {1:X2}h, setting media type to QIC-150.",
                                                       mediumType, densityCode);

                            return MediaType.QIC150;
                        case 0x13:
                            AaruConsole.DebugWriteLine("Media detection",
                                                       "SCSI medium type is {0:X2}h, density code is {1:X2}h, setting media type to DDS.",
                                                       mediumType, densityCode);

                            return MediaType.DDS1;
                        case 0x24:
                            AaruConsole.DebugWriteLine("Media detection",
                                                       "SCSI medium type is {0:X2}h, density code is {1:X2}h, setting media type to DDS-2.",
                                                       mediumType, densityCode);

                            return MediaType.DDS2;
                        case 0x25:
                            AaruConsole.DebugWriteLine("Media detection",
                                                       "SCSI medium type is {0:X2}h, density code is {1:X2}h, setting media type to DDS-3.",
                                                       mediumType, densityCode);

                            return MediaType.DDS3;
                        case 0x26:
                            AaruConsole.DebugWriteLine("Media detection",
                                                       "SCSI medium type is {0:X2}h, density code is {1:X2}h, setting media type to DDS-4.",
                                                       mediumType, densityCode);

                            return MediaType.DDS4;
                        case 0x28:
                            AaruConsole.DebugWriteLine("Media detection",
                                                       "SCSI medium type is {0:X2}h, density code is {1:X2}h, setting media type to IBM 3490E.",
                                                       mediumType, densityCode);

                            return MediaType.IBM3490E;
                        case 0x40:
                            if(model.ToLowerInvariant().StartsWith("ult", StringComparison.Ordinal))
                            {
                                AaruConsole.DebugWriteLine("Media detection",
                                                           "SCSI medium type is {0:X2}h, density code is {1:X2}h, drive model starts with \"ult\" setting media type to LTO.",
                                                           mediumType, densityCode);

                                return MediaType.LTO;
                            }

                            if(model.ToLowerInvariant().StartsWith("sdz", StringComparison.Ordinal))
                            {
                                AaruConsole.DebugWriteLine("Media detection",
                                                           "SCSI medium type is {0:X2}h, density code is {1:X2}h, drive model starts with \"sdz\" setting media type to Super AIT.",
                                                           mediumType, densityCode);

                                return MediaType.SAIT1;
                            }

                            break;

                        case 0x41:
                        {
                            if(model.ToLowerInvariant().StartsWith("ult", StringComparison.Ordinal))
                            {
                                AaruConsole.DebugWriteLine("Media detection",
                                                           "SCSI medium type is {0:X2}h, density code is {1:X2}h, drive model starts with \"ult\" setting media type to LTO-2.",
                                                           mediumType, densityCode);

                                return MediaType.LTO2;
                            }

                            break;
                        }

                        case 0x42:
                        {
                            if(model.ToLowerInvariant().StartsWith("ult", StringComparison.Ordinal))
                            {
                                AaruConsole.DebugWriteLine("Media detection",
                                                           "SCSI medium type is {0:X2}h, density code is {1:X2}h, drive model starts with \"ult\" setting media type to LTO-2.",
                                                           mediumType, densityCode);

                                return MediaType.LTO2;
                            }

                            if(vendor.ToLowerInvariant() == "stk")
                            {
                                AaruConsole.DebugWriteLine("Media detection",
                                                           "SCSI medium type is {0:X2}h, density code is {1:X2}h, drive manufacturer is StorageTek, setting media type to T9840A.",
                                                           mediumType, densityCode);

                                return MediaType.T9840A;
                            }

                            break;
                        }

                        case 0x43:
                        {
                            if(vendor.ToLowerInvariant() == "stk")
                            {
                                AaruConsole.DebugWriteLine("Media detection",
                                                           "SCSI medium type is {0:X2}h, density code is {1:X2}h, drive manufacturer is StorageTek, setting media type to T9940A.",
                                                           mediumType, densityCode);

                                return MediaType.T9940A;
                            }

                            break;
                        }

                        case 0x44:
                        {
                            if(model.ToLowerInvariant().StartsWith("ult", StringComparison.Ordinal))
                            {
                                AaruConsole.DebugWriteLine("Media detection",
                                                           "SCSI medium type is {0:X2}h, density code is {1:X2}h, drive model starts with \"ult\" setting media type to LTO-3.",
                                                           mediumType, densityCode);

                                return MediaType.LTO3;
                            }

                            if(vendor.ToLowerInvariant() == "stk")
                            {
                                AaruConsole.DebugWriteLine("Media detection",
                                                           "SCSI medium type is {0:X2}h, density code is {1:X2}h, drive manufacturer is StorageTek, setting media type to T9940B.",
                                                           mediumType, densityCode);

                                return MediaType.T9940B;
                            }

                            break;
                        }

                        case 0x45:
                        {
                            if(vendor.ToLowerInvariant() == "stk")
                            {
                                AaruConsole.DebugWriteLine("Media detection",
                                                           "SCSI medium type is {0:X2}h, density code is {1:X2}h, drive manufacturer is StorageTek, setting media type to T9840C.",
                                                           mediumType, densityCode);

                                return MediaType.T9840C;
                            }

                            break;
                        }

                        case 0x46:
                        {
                            if(model.ToLowerInvariant().StartsWith("ult", StringComparison.Ordinal))
                            {
                                AaruConsole.DebugWriteLine("Media detection",
                                                           "SCSI medium type is {0:X2}h, density code is {1:X2}h, drive model starts with \"ult\" setting media type to LTO-4.",
                                                           mediumType, densityCode);

                                return MediaType.LTO4;
                            }

                            if(vendor.ToLowerInvariant() == "stk")
                            {
                                AaruConsole.DebugWriteLine("Media detection",
                                                           "SCSI medium type is {0:X2}h, density code is {1:X2}h, drive manufacturer is StorageTek, setting media type to T9840D.",
                                                           mediumType, densityCode);

                                return MediaType.T9840D;
                            }

                            break;
                        }

                        case 0x4A:
                        {
                            if(vendor.ToLowerInvariant() == "stk")
                            {
                                AaruConsole.DebugWriteLine("Media detection",
                                                           "SCSI medium type is {0:X2}h, density code is {1:X2}h, drive manufacturer is StorageTek, setting media type to T10000A.",
                                                           mediumType, densityCode);

                                return MediaType.T10000A;
                            }

                            break;
                        }

                        case 0x4B:
                        {
                            if(vendor.ToLowerInvariant() == "stk")
                            {
                                AaruConsole.DebugWriteLine("Media detection",
                                                           "SCSI medium type is {0:X2}h, density code is {1:X2}h, drive manufacturer is StorageTek, setting media type to T10000B.",
                                                           mediumType, densityCode);

                                return MediaType.T10000B;
                            }

                            break;
                        }

                        case 0x4C:
                        {
                            if(vendor.ToLowerInvariant() == "stk")
                            {
                                AaruConsole.DebugWriteLine("Media detection",
                                                           "SCSI medium type is {0:X2}h, density code is {1:X2}h, drive manufacturer is StorageTek, setting media type to T10000C.",
                                                           mediumType, densityCode);

                                return MediaType.T10000C;
                            }

                            break;
                        }

                        case 0x4D:
                        {
                            if(vendor.ToLowerInvariant() == "stk")
                            {
                                AaruConsole.DebugWriteLine("Media detection",
                                                           "SCSI medium type is {0:X2}h, density code is {1:X2}h, drive manufacturer is StorageTek, setting media type to T10000D.",
                                                           mediumType, densityCode);

                                return MediaType.T10000D;
                            }

                            break;
                        }

                        case 0x58:
                        {
                            if(model.ToLowerInvariant().StartsWith("ult", StringComparison.Ordinal))
                            {
                                AaruConsole.DebugWriteLine("Media detection",
                                                           "SCSI medium type is {0:X2}h, density code is {1:X2}h, drive model starts with \"ult\" setting media type to LTO-5.",
                                                           mediumType, densityCode);

                                return MediaType.LTO5;
                            }

                            break;
                        }

                        // Used by some HP drives for all generations
                        case 0x8C:
                        {
                            AaruConsole.DebugWriteLine("Media detection",
                                                       "SCSI medium type is {0:X2}h, density code is {1:X2}h, setting media type to DDS.",
                                                       mediumType, densityCode);

                            return MediaType.DDS1;
                        }
                    }

                    break;
                case 0x01:
                {
                    switch(densityCode)
                    {
                        case 0x44:
                        {
                            if(model.ToLowerInvariant().StartsWith("ult", StringComparison.Ordinal))
                            {
                                AaruConsole.DebugWriteLine("Media detection",
                                                           "SCSI medium type is {0:X2}h, density code is {1:X2}h, drive model starts with \"ult\" setting media type to WORM LTO-3.",
                                                           mediumType, densityCode);

                                return MediaType.LTO3WORM;
                            }

                            break;
                        }

                        case 0x46:
                        {
                            if(model.ToLowerInvariant().StartsWith("ult", StringComparison.Ordinal))
                            {
                                AaruConsole.DebugWriteLine("Media detection",
                                                           "SCSI medium type is {0:X2}h, density code is {1:X2}h, drive model starts with \"ult\" setting media type to WORM LTO-4.",
                                                           mediumType, densityCode);

                                return MediaType.LTO4WORM;
                            }

                            break;
                        }

                        case 0x58:
                        {
                            if(model.ToLowerInvariant().StartsWith("ult", StringComparison.Ordinal))
                            {
                                AaruConsole.DebugWriteLine("Media detection",
                                                           "SCSI medium type is {0:X2}h, density code is {1:X2}h, drive model starts with \"ult\" setting media type to WORM LTO-5.",
                                                           mediumType, densityCode);

                                return MediaType.LTO5WORM;
                            }

                            break;
                        }
                    }
                }

                    break;
                case 0x18:
                {
                    switch(densityCode)
                    {
                        case 0x00:
                        {
                            if(model.ToLowerInvariant().StartsWith("ult", StringComparison.Ordinal))
                            {
                                AaruConsole.DebugWriteLine("Media detection",
                                                           "SCSI medium type is {0:X2}h, density code is {1:X2}h, drive model starts with \"ult\" setting media type to LTO.",
                                                           mediumType, densityCode);

                                return MediaType.LTO;
                            }

                            break;
                        }

                        case 0x40:
                        {
                            AaruConsole.DebugWriteLine("Media detection",
                                                       "SCSI medium type is {0:X2}h, density code is {1:X2}h, setting media type to LTO.",
                                                       mediumType, densityCode);

                            return MediaType.LTO;
                        }
                    }
                }

                    break;
                case 0x28:
                {
                    switch(densityCode)
                    {
                        case 0x00:
                        {
                            if(model.ToLowerInvariant().StartsWith("ult", StringComparison.Ordinal))
                            {
                                AaruConsole.DebugWriteLine("Media detection",
                                                           "SCSI medium type is {0:X2}h, density code is {1:X2}h, drive model starts with \"ult\" setting media type to LTO-2.",
                                                           mediumType, densityCode);

                                return MediaType.LTO2;
                            }

                            break;
                        }

                        case 0x42:
                        {
                            AaruConsole.DebugWriteLine("Media detection",
                                                       "SCSI medium type is {0:X2}h, density code is {1:X2}h, setting media type to LTO-2.",
                                                       mediumType, densityCode);

                            return MediaType.LTO2;
                        }
                    }
                }

                    break;
                case 0x33:
                {
                    switch(densityCode)
                    {
                        case 0x00:
                        case 0x25:
                        {
                            if(model.ToLowerInvariant().StartsWith("dat", StringComparison.Ordinal))
                            {
                                AaruConsole.DebugWriteLine("Media detection",
                                                           "SCSI medium type is {0:X2}h, density code is {1:X2}h, drive model starts with \"ult\" setting media type to DDS-3.",
                                                           mediumType, densityCode);

                                return MediaType.DDS3;
                            }

                            break;
                        }
                    }
                }

                    break;
                case 0x34:
                {
                    switch(densityCode)
                    {
                        case 0x00:
                        case 0x26:
                        {
                            if(model.ToLowerInvariant().StartsWith("dat", StringComparison.Ordinal))
                            {
                                AaruConsole.DebugWriteLine("Media detection",
                                                           "SCSI medium type is {0:X2}h, density code is {1:X2}h, drive model starts with \"ult\" setting media type to DDS-4.",
                                                           mediumType, densityCode);

                                return MediaType.DDS4;
                            }

                            break;
                        }
                    }
                }

                    break;
                case 0x35:
                {
                    switch(densityCode)
                    {
                        case 0x00:
                        case 0x47:
                        {
                            if(model.ToLowerInvariant().StartsWith("dat", StringComparison.Ordinal))
                            {
                                AaruConsole.DebugWriteLine("Media detection",
                                                           "SCSI medium type is {0:X2}h, density code is {1:X2}h, drive model starts with \"ult\" setting media type to DAT72.",
                                                           mediumType, densityCode);

                                return MediaType.DAT72;
                            }

                            break;
                        }
                    }
                }

                    break;
                case 0x38:
                {
                    switch(densityCode)
                    {
                        case 0x00:
                        case 0x44:
                        {
                            if(model.ToLowerInvariant().StartsWith("ult", StringComparison.Ordinal))
                            {
                                AaruConsole.DebugWriteLine("Media detection",
                                                           "SCSI medium type is {0:X2}h, density code is {1:X2}h, drive model starts with \"ult\" setting media type to LTO-3.",
                                                           mediumType, densityCode);

                                return MediaType.LTO3;
                            }

                            break;
                        }
                    }
                }

                    break;
                case 0x3C:
                {
                    switch(densityCode)
                    {
                        case 0x00:
                        case 0x44:
                        {
                            if(model.ToLowerInvariant().StartsWith("ult", StringComparison.Ordinal))
                            {
                                AaruConsole.DebugWriteLine("Media detection",
                                                           "SCSI medium type is {0:X2}h, density code is {1:X2}h, drive model starts with \"ult\" setting media type to WORM LTO-3.",
                                                           mediumType, densityCode);

                                return MediaType.LTO3WORM;
                            }

                            break;
                        }
                    }
                }

                    break;
                case 0x48:
                {
                    switch(densityCode)
                    {
                        case 0x00:
                        case 0x46:
                        {
                            if(model.ToLowerInvariant().StartsWith("ult", StringComparison.Ordinal))
                            {
                                AaruConsole.DebugWriteLine("Media detection",
                                                           "SCSI medium type is {0:X2}h, density code is {1:X2}h, drive model starts with \"ult\" setting media type to LTO-4.",
                                                           mediumType, densityCode);

                                return MediaType.LTO4;
                            }

                            break;
                        }
                    }
                }

                    break;
                case 0x4C:
                {
                    switch(densityCode)
                    {
                        case 0x00:
                        case 0x46:
                        {
                            if(model.ToLowerInvariant().StartsWith("ult", StringComparison.Ordinal))
                            {
                                AaruConsole.DebugWriteLine("Media detection",
                                                           "SCSI medium type is {0:X2}h, density code is {1:X2}h, drive model starts with \"ult\" setting media type to WORM LTO-4.",
                                                           mediumType, densityCode);

                                return MediaType.LTO4WORM;
                            }

                            break;
                        }
                    }
                }

                    break;
                case 0x50:
                {
                    switch(densityCode)
                    {
                        case 0x00:
                        case 0x24:
                        {
                            if(model.ToLowerInvariant().StartsWith("dat", StringComparison.Ordinal))
                            {
                                AaruConsole.DebugWriteLine("Media detection",
                                                           "SCSI medium type is {0:X2}h, density code is {1:X2}h, drive model starts with \"ult\" setting media type to DDS-2.",
                                                           mediumType, densityCode);

                                return MediaType.DDS2;
                            }

                            break;
                        }
                    }
                }

                    break;
                case 0x58:
                {
                    switch(densityCode)
                    {
                        case 0x00:
                        case 0x58:
                        {
                            if(model.ToLowerInvariant().StartsWith("ult", StringComparison.Ordinal))
                            {
                                AaruConsole.DebugWriteLine("Media detection",
                                                           "SCSI medium type is {0:X2}h, density code is {1:X2}h, drive model starts with \"ult\" setting media type to LTO-5.",
                                                           mediumType, densityCode);

                                return MediaType.LTO5;
                            }

                            break;
                        }
                    }
                }

                    break;
                case 0x5C:
                {
                    switch(densityCode)
                    {
                        case 0x00:
                        case 0x58:
                        {
                            if(model.ToLowerInvariant().StartsWith("ult", StringComparison.Ordinal))
                            {
                                AaruConsole.DebugWriteLine("Media detection",
                                                           "SCSI medium type is {0:X2}h, density code is {1:X2}h, drive model starts with \"ult\" setting media type to WORM LTO-5.",
                                                           mediumType, densityCode);

                                return MediaType.LTO5WORM;
                            }

                            break;
                        }
                    }
                }

                    break;
                case 0x68:
                {
                    switch(densityCode)
                    {
                        case 0x00:
                        case 0x5A:
                        {
                            if(model.ToLowerInvariant().StartsWith("ult", StringComparison.Ordinal))
                            {
                                AaruConsole.DebugWriteLine("Media detection",
                                                           "SCSI medium type is {0:X2}h, density code is {1:X2}h, drive model starts with \"ult\" setting media type to LTO-6.",
                                                           mediumType, densityCode);

                                return MediaType.LTO6;
                            }

                            break;
                        }
                    }
                }

                    break;
                case 0x6C:
                {
                    switch(densityCode)
                    {
                        case 0x00:
                        case 0x5A:
                        {
                            if(model.ToLowerInvariant().StartsWith("ult", StringComparison.Ordinal))
                            {
                                AaruConsole.DebugWriteLine("Media detection",
                                                           "SCSI medium type is {0:X2}h, density code is {1:X2}h, drive model starts with \"ult\" setting media type to WORM LTO-6.",
                                                           mediumType, densityCode);

                                return MediaType.LTO6WORM;
                            }

                            break;
                        }
                    }
                }

                    break;
                case 0x78:
                {
                    switch(densityCode)
                    {
                        case 0x00:
                        case 0x5C:
                        {
                            if(model.ToLowerInvariant().StartsWith("ult", StringComparison.Ordinal))
                            {
                                AaruConsole.DebugWriteLine("Media detection",
                                                           "SCSI medium type is {0:X2}h, density code is {1:X2}h, drive model starts with \"ult\" setting media type to LTO-7.",
                                                           mediumType, densityCode);

                                return MediaType.LTO7;
                            }

                            break;
                        }
                    }
                }

                    break;
                case 0x7C:
                {
                    switch(densityCode)
                    {
                        case 0x00:
                        case 0x5C:
                        {
                            if(model.ToLowerInvariant().StartsWith("ult", StringComparison.Ordinal))
                            {
                                AaruConsole.DebugWriteLine("Media detection",
                                                           "SCSI medium type is {0:X2}h, density code is {1:X2}h, drive model starts with \"ult\" setting media type to WORM LTO-7.",
                                                           mediumType, densityCode);

                                return MediaType.LTO7WORM;
                            }

                            break;
                        }
                    }
                }

                    break;
                case 0x81:
                {
                    switch(densityCode)
                    {
                        case 0x00:
                        {
                            if(model.ToLowerInvariant().StartsWith("exb", StringComparison.Ordinal))
                            {
                                AaruConsole.DebugWriteLine("Media detection",
                                                           "SCSI medium type is {0:X2}h, density code is {1:X2}h, drive model starts with \"exb\" setting media type to 15m Exatape.",
                                                           mediumType, densityCode);

                                return MediaType.Exatape15m;
                            }

                            if(vendor.ToLowerInvariant() == "ibm")
                            {
                                AaruConsole.DebugWriteLine("Media detection",
                                                           "SCSI medium type is {0:X2}h, density code is {1:X2}h, drive manufacturer is IBM, setting media type to IBM 3592.",
                                                           mediumType, densityCode);

                                return MediaType.IBM3592;
                            }

                            if(model.ToLowerInvariant().StartsWith("vxa", StringComparison.Ordinal))
                            {
                                AaruConsole.DebugWriteLine("Media detection",
                                                           "SCSI medium type is {0:X2}h, density code is {1:X2}h, drive model starts with \"vxa\" setting media type to VXA.",
                                                           mediumType, densityCode);

                                return MediaType.VXA1;
                            }

                            break;
                        }

                        case 0x14:
                        case 0x15:
                        case 0x27:
                        case 0x8C:
                        case 0x90:
                        {
                            if(model.ToLowerInvariant().StartsWith("exb", StringComparison.Ordinal))
                            {
                                AaruConsole.DebugWriteLine("Media detection",
                                                           "SCSI medium type is {0:X2}h, density code is {1:X2}h, drive model starts with \"exb\" setting media type to 15m Exatape.",
                                                           mediumType, densityCode);

                                return MediaType.Exatape15m;
                            }

                            break;
                        }

                        case 0x29:
                        case 0x2A:
                        {
                            if(vendor.ToLowerInvariant() == "ibm")
                            {
                                AaruConsole.DebugWriteLine("Media detection",
                                                           "SCSI medium type is {0:X2}h, density code is {1:X2}h, drive manufacturer is IBM, setting media type to IBM 3592.",
                                                           mediumType, densityCode);

                                return MediaType.IBM3592;
                            }

                            break;
                        }

                        case 0x80:
                        {
                            if(model.ToLowerInvariant().StartsWith("vxa", StringComparison.Ordinal))
                            {
                                AaruConsole.DebugWriteLine("Media detection",
                                                           "SCSI medium type is {0:X2}h, density code is {1:X2}h, drive model starts with \"vxa\" setting media type to VXA.",
                                                           mediumType, densityCode);

                                return MediaType.VXA1;
                            }

                            break;
                        }
                    }
                }

                    break;
                case 0x82:
                {
                    switch(densityCode)
                    {
                        case 0x00:
                        {
                            if(model.ToLowerInvariant().StartsWith("exb", StringComparison.Ordinal))
                            {
                                AaruConsole.DebugWriteLine("Media detection",
                                                           "SCSI medium type is {0:X2}h, density code is {1:X2}h, drive model starts with \"exb\" setting media type to 28m Exatape.",
                                                           mediumType, densityCode);

                                return MediaType.Exatape28m;
                            }

                            if(vendor.ToLowerInvariant() == "ibm")
                            {
                                AaruConsole.DebugWriteLine("Media detection",
                                                           "SCSI medium type is {0:X2}h, density code is {1:X2}h, drive manufacturer is IBM, setting media type to IBM 3592.",
                                                           mediumType, densityCode);

                                return MediaType.IBM3592;
                            }

                            break;
                        }

                        case 0x0A:
                        {
                            if(model.ToLowerInvariant().StartsWith("dlt", StringComparison.Ordinal))
                            {
                                AaruConsole.DebugWriteLine("Media detection",
                                                           "SCSI medium type is {0:X2}h, density code is {1:X2}h, drive model starts with \"dlt\" setting media type to CompactTape.",
                                                           mediumType, densityCode);

                                return MediaType.CompactTapeI;
                            }

                            break;
                        }

                        case 0x14:
                        case 0x15:
                        case 0x27:
                        case 0x8C:
                        case 0x90:
                        {
                            if(model.ToLowerInvariant().StartsWith("exb", StringComparison.Ordinal))
                            {
                                AaruConsole.DebugWriteLine("Media detection",
                                                           "SCSI medium type is {0:X2}h, density code is {1:X2}h, drive model starts with \"exb\" setting media type to 28m Exatape.",
                                                           mediumType, densityCode);

                                return MediaType.Exatape28m;
                            }

                            break;
                        }

                        case 0x16:
                        {
                            if(model.ToLowerInvariant().StartsWith("dlt", StringComparison.Ordinal))
                            {
                                AaruConsole.DebugWriteLine("Media detection",
                                                           "SCSI medium type is {0:X2}h, density code is {1:X2}h, drive model starts with \"dlt\" setting media type to CompactTape II.",
                                                           mediumType, densityCode);

                                return MediaType.CompactTapeII;
                            }

                            break;
                        }

                        case 0x29:
                        case 0x2A:
                        {
                            if(vendor.ToLowerInvariant() == "ibm")
                            {
                                AaruConsole.DebugWriteLine("Media detection",
                                                           "SCSI medium type is {0:X2}h, density code is {1:X2}h, drive manufacturer is IBM, setting media type to IBM 3592.",
                                                           mediumType, densityCode);

                                return MediaType.IBM3592;
                            }

                            break;
                        }

                        case 0x81:
                        {
                            if(model.ToLowerInvariant().StartsWith("vxa", StringComparison.Ordinal))
                            {
                                AaruConsole.DebugWriteLine("Media detection",
                                                           "SCSI medium type is {0:X2}h, density code is {1:X2}h, drive model starts with \"vxa\" setting media type to VXA 2.",
                                                           mediumType, densityCode);

                                return MediaType.VXA2;
                            }

                            break;
                        }

                        case 0x82:
                        {
                            if(model.ToLowerInvariant().StartsWith("vxa", StringComparison.Ordinal))
                            {
                                AaruConsole.DebugWriteLine("Media detection",
                                                           "SCSI medium type is {0:X2}h, density code is {1:X2}h, drive model starts with \"vxa\" setting media type to VXA 3.",
                                                           mediumType, densityCode);

                                return MediaType.VXA3;
                            }

                            break;
                        }
                    }
                }

                    break;
                case 0x83:
                {
                    switch(densityCode)
                    {
                        case 0x00:
                        {
                            if(model.ToLowerInvariant().StartsWith("exb", StringComparison.Ordinal))
                            {
                                AaruConsole.DebugWriteLine("Media detection",
                                                           "SCSI medium type is {0:X2}h, density code is {1:X2}h, drive model starts with \"exb\" setting media type to 54m Exatape.",
                                                           mediumType, densityCode);

                                return MediaType.Exatape54m;
                            }

                            if(model.ToLowerInvariant().StartsWith("dlt", StringComparison.Ordinal))
                            {
                                AaruConsole.DebugWriteLine("Media detection",
                                                           "SCSI medium type is {0:X2}h, density code is {1:X2}h, drive model starts with \"dlt\" setting media type to DLTtape III.",
                                                           mediumType, densityCode);

                                return MediaType.DLTtapeIII;
                            }

                            break;
                        }

                        case 0x14:
                        case 0x15:
                        case 0x27:
                        case 0x8C:
                        case 0x90:
                        {
                            if(model.ToLowerInvariant().StartsWith("exb", StringComparison.Ordinal))
                            {
                                AaruConsole.DebugWriteLine("Media detection",
                                                           "SCSI medium type is {0:X2}h, density code is {1:X2}h, drive model starts with \"exb\" setting media type to 54m Exatape.",
                                                           mediumType, densityCode);

                                return MediaType.Exatape54m;
                            }

                            break;
                        }

                        case 0x17:
                        case 0x18:
                        case 0x19:
                        case 0x80:
                        case 0x81:
                        {
                            if(model.ToLowerInvariant().StartsWith("dlt", StringComparison.Ordinal))
                            {
                                AaruConsole.DebugWriteLine("Media detection",
                                                           "SCSI medium type is {0:X2}h, density code is {1:X2}h, drive model starts with \"dlt\" setting media type to DLTtape III.",
                                                           mediumType, densityCode);

                                return MediaType.DLTtapeIII;
                            }

                            break;
                        }
                    }
                }

                    break;
                case 0x84:
                {
                    switch(densityCode)
                    {
                        case 0x00:
                        {
                            if(model.ToLowerInvariant().StartsWith("exb", StringComparison.Ordinal))
                            {
                                AaruConsole.DebugWriteLine("Media detection",
                                                           "SCSI medium type is {0:X2}h, density code is {1:X2}h, drive model starts with \"exb\" setting media type to 80m Exatape.",
                                                           mediumType, densityCode);

                                return MediaType.Exatape80m;
                            }

                            if(model.ToLowerInvariant().StartsWith("dlt", StringComparison.Ordinal))
                            {
                                AaruConsole.DebugWriteLine("Media detection",
                                                           "SCSI medium type is {0:X2}h, density code is {1:X2}h, drive model starts with \"dlt\" setting media type to DLTtape IIIxt.",
                                                           mediumType, densityCode);

                                return MediaType.DLTtapeIIIxt;
                            }

                            break;
                        }

                        case 0x14:
                        case 0x15:
                        case 0x27:
                        case 0x8C:
                        case 0x90:
                        {
                            if(model.ToLowerInvariant().StartsWith("exb", StringComparison.Ordinal))
                            {
                                AaruConsole.DebugWriteLine("Media detection",
                                                           "SCSI medium type is {0:X2}h, density code is {1:X2}h, drive model starts with \"exb\" setting media type to 80m Exatape.",
                                                           mediumType, densityCode);

                                return MediaType.Exatape80m;
                            }

                            break;
                        }

                        case 0x19:
                        case 0x80:
                        case 0x81:
                        {
                            if(model.ToLowerInvariant().StartsWith("dlt", StringComparison.Ordinal))
                            {
                                AaruConsole.DebugWriteLine("Media detection",
                                                           "SCSI medium type is {0:X2}h, density code is {1:X2}h, drive model starts with \"dlt\" setting media type to DLTtape IIIxt.",
                                                           mediumType, densityCode);

                                return MediaType.DLTtapeIIIxt;
                            }

                            break;
                        }
                    }
                }

                    break;
                case 0x85:
                {
                    switch(densityCode)
                    {
                        case 0x00:
                        {
                            if(model.ToLowerInvariant().StartsWith("exb", StringComparison.Ordinal))
                            {
                                AaruConsole.DebugWriteLine("Media detection",
                                                           "SCSI medium type is {0:X2}h, density code is {1:X2}h, drive model starts with \"exb\" setting media type to 106m Exatape.",
                                                           mediumType, densityCode);

                                return MediaType.Exatape106m;
                            }

                            if(model.ToLowerInvariant().StartsWith("dlt", StringComparison.Ordinal)  ||
                               model.ToLowerInvariant().StartsWith("sdlt", StringComparison.Ordinal) ||
                               model.ToLowerInvariant().StartsWith("superdlt", StringComparison.Ordinal))
                            {
                                AaruConsole.DebugWriteLine("Media detection",
                                                           "SCSI medium type is {0:X2}h, density code is {1:X2}h, drive model starts with \"dlt\" setting media type to DLTtape IV.",
                                                           mediumType, densityCode);

                                return MediaType.DLTtapeIV;
                            }

                            if(model.ToLowerInvariant().StartsWith("stt", StringComparison.Ordinal))
                            {
                                AaruConsole.DebugWriteLine("Media detection",
                                                           "SCSI medium type is {0:X2}h, density code is {1:X2}h, drive model starts with \"stt\" setting media type to Travan 5.",
                                                           mediumType, densityCode);

                                return MediaType.Travan5;
                            }

                            break;
                        }

                        case 0x14:
                        case 0x15:
                        case 0x27:
                        case 0x8C:
                        case 0x90:
                        {
                            if(model.ToLowerInvariant().StartsWith("exb", StringComparison.Ordinal))
                            {
                                AaruConsole.DebugWriteLine("Media detection",
                                                           "SCSI medium type is {0:X2}h, density code is {1:X2}h, drive model starts with \"exb\" setting media type to 106m Exatape.",
                                                           mediumType, densityCode);

                                return MediaType.Exatape106m;
                            }

                            break;
                        }

                        case 0x1A:
                        case 0x1B:
                        case 0x40:
                        case 0x41:
                        case 0x82:
                        case 0x83:
                        case 0x84:
                        case 0x85:
                        case 0x86:
                        case 0x87:
                        case 0x88:
                        case 0x89:
                        {
                            if(model.ToLowerInvariant().StartsWith("dlt", StringComparison.Ordinal)  ||
                               model.ToLowerInvariant().StartsWith("sdlt", StringComparison.Ordinal) ||
                               model.ToLowerInvariant().StartsWith("superdlt", StringComparison.Ordinal))
                            {
                                AaruConsole.DebugWriteLine("Media detection",
                                                           "SCSI medium type is {0:X2}h, density code is {1:X2}h, drive model starts with \"dlt\" setting media type to DLTtape IV.",
                                                           mediumType, densityCode);

                                return MediaType.DLTtapeIV;
                            }

                            break;
                        }

                        case 0x46:
                        {
                            if(model.ToLowerInvariant().StartsWith("stt", StringComparison.Ordinal))
                            {
                                AaruConsole.DebugWriteLine("Media detection",
                                                           "SCSI medium type is {0:X2}h, density code is {1:X2}h, drive model starts with \"stt\" setting media type to Travan 5.",
                                                           mediumType, densityCode);

                                return MediaType.Travan5;
                            }

                            break;
                        }
                    }
                }

                    break;
                case 0x86:
                {
                    switch(densityCode)
                    {
                        case 0x00:
                        case 0x90:
                        {
                            if(model.ToLowerInvariant().StartsWith("exb", StringComparison.Ordinal))
                            {
                                AaruConsole.DebugWriteLine("Media detection",
                                                           "SCSI medium type is {0:X2}h, density code is {1:X2}h, drive model starts with \"exb\" setting media type to 160m Exatape XL.",
                                                           mediumType, densityCode);

                                return MediaType.Exatape160mXL;
                            }

                            if(model.ToLowerInvariant().StartsWith("dlt", StringComparison.Ordinal)  ||
                               model.ToLowerInvariant().StartsWith("sdlt", StringComparison.Ordinal) ||
                               model.ToLowerInvariant().StartsWith("superdlt", StringComparison.Ordinal))
                            {
                                AaruConsole.DebugWriteLine("Media detection",
                                                           "SCSI medium type is {0:X2}h, density code is {1:X2}h, drive model starts with \"dlt\" setting media type to SuperDLT.",
                                                           mediumType, densityCode);

                                return MediaType.SDLT1;
                            }

                            break;
                        }

                        case 0x8C:
                        {
                            if(model.ToLowerInvariant().StartsWith("exb", StringComparison.Ordinal))
                            {
                                AaruConsole.DebugWriteLine("Media detection",
                                                           "SCSI medium type is {0:X2}h, density code is {1:X2}h, drive model starts with \"exb\" setting media type to 160m Exatape XL.",
                                                           mediumType, densityCode);

                                return MediaType.Exatape160mXL;
                            }

                            break;
                        }

                        case 0x91:
                        case 0x92:
                        case 0x93:
                        {
                            if(model.ToLowerInvariant().StartsWith("dlt", StringComparison.Ordinal)  ||
                               model.ToLowerInvariant().StartsWith("sdlt", StringComparison.Ordinal) ||
                               model.ToLowerInvariant().StartsWith("superdlt", StringComparison.Ordinal))
                            {
                                AaruConsole.DebugWriteLine("Media detection",
                                                           "SCSI medium type is {0:X2}h, density code is {1:X2}h, drive model starts with \"dlt\" setting media type to SuperDLT.",
                                                           mediumType, densityCode);

                                return MediaType.SDLT1;
                            }

                            break;
                        }
                    }
                }

                    break;
                case 0x87:
                {
                    switch(densityCode)
                    {
                        case 0x00:
                        case 0x4A:
                        {
                            if(model.ToLowerInvariant().StartsWith("dlt", StringComparison.Ordinal)  ||
                               model.ToLowerInvariant().StartsWith("sdlt", StringComparison.Ordinal) ||
                               model.ToLowerInvariant().StartsWith("superdlt", StringComparison.Ordinal))
                            {
                                AaruConsole.DebugWriteLine("Media detection",
                                                           "SCSI medium type is {0:X2}h, density code is {1:X2}h, drive model starts with \"dlt\" setting media type to SuperDLT 2.",
                                                           mediumType, densityCode);

                                return MediaType.SDLT2;
                            }

                            break;
                        }
                    }
                }

                    break;
                case 0x90:
                {
                    switch(densityCode)
                    {
                        case 0x00:
                        case 0x50:
                        case 0x98:
                        case 0x99:
                        {
                            if(model.ToLowerInvariant().StartsWith("dlt", StringComparison.Ordinal)  ||
                               model.ToLowerInvariant().StartsWith("sdlt", StringComparison.Ordinal) ||
                               model.ToLowerInvariant().StartsWith("superdlt", StringComparison.Ordinal))
                            {
                                AaruConsole.DebugWriteLine("Media detection",
                                                           "SCSI medium type is {0:X2}h, density code is {1:X2}h, drive model starts with \"dlt\" setting media type to VStape I.",
                                                           mediumType, densityCode);

                                return MediaType.VStapeI;
                            }

                            break;
                        }
                    }
                }

                    break;
                case 0x95:
                {
                    if(model.ToLowerInvariant().StartsWith("stt", StringComparison.Ordinal))
                    {
                        AaruConsole.DebugWriteLine("Media detection",
                                                   "SCSI medium type is {0:X2}h, density code is {1:X2}h, drive model starts with \"stt\" setting media type to Travan 7.",
                                                   mediumType, densityCode);

                        return MediaType.Travan7;
                    }
                }

                    break;
                case 0xB6:
                {
                    switch(densityCode)
                    {
                        case 0x45:
                            // HP Colorado tapes have a different capacity but return same density code at least in Seagate drives
                            AaruConsole.DebugWriteLine("Media detection",
                                                       "SCSI medium type is {0:X2}h, density code is {1:X2}h, setting media type to Travan 4.",
                                                       mediumType, densityCode);

                            return MediaType.Travan4;
                    }
                }

                    break;
                case 0xB7:
                {
                    switch(densityCode)
                    {
                        case 0x47:
                            AaruConsole.DebugWriteLine("Media detection",
                                                       "SCSI medium type is {0:X2}h, density code is {1:X2}h, setting media type to Travan 5.",
                                                       mediumType, densityCode);

                            return MediaType.Travan5;
                    }
                }

                    break;
                case 0xC1:
                {
                    switch(densityCode)
                    {
                        case 0x00:
                        case 0x14:
                        case 0x15:
                        case 0x8C:
                        case 0x90:
                        {
                            if(model.ToLowerInvariant().StartsWith("exb", StringComparison.Ordinal))
                            {
                                AaruConsole.DebugWriteLine("Media detection",
                                                           "SCSI medium type is {0:X2}h, density code is {1:X2}h, drive model starts with \"exb\" setting media type to 22m Exatape.",
                                                           mediumType, densityCode);

                                return MediaType.Exatape22m;
                            }

                            break;
                        }
                    }
                }

                    break;
                case 0xC2:
                {
                    switch(densityCode)
                    {
                        case 0x00:
                        case 0x14:
                        case 0x15:
                        case 0x27:
                        case 0x8C:
                        case 0x90:
                        {
                            if(model.ToLowerInvariant().StartsWith("exb", StringComparison.Ordinal))
                            {
                                AaruConsole.DebugWriteLine("Media detection",
                                                           "SCSI medium type is {0:X2}h, density code is {1:X2}h, drive model starts with \"exb\" setting media type to 40m Exatape.",
                                                           mediumType, densityCode);

                                return MediaType.Exatape40m;
                            }

                            break;
                        }
                    }
                }

                    break;
                case 0xC3:
                {
                    switch(densityCode)
                    {
                        case 0x00:
                        case 0x14:
                        case 0x15:
                        case 0x27:
                        case 0x8C:
                        case 0x90:
                        {
                            if(model.ToLowerInvariant().StartsWith("exb", StringComparison.Ordinal))
                            {
                                AaruConsole.DebugWriteLine("Media detection",
                                                           "SCSI medium type is {0:X2}h, density code is {1:X2}h, drive model starts with \"exb\" setting media type to 76m Exatape.",
                                                           mediumType, densityCode);

                                return MediaType.Exatape76m;
                            }

                            break;
                        }
                    }
                }

                    break;
                case 0xC4:
                {
                    switch(densityCode)
                    {
                        case 0x00:
                        case 0x14:
                        case 0x15:
                        case 0x27:
                        case 0x8C:
                        case 0x90:
                        {
                            if(model.ToLowerInvariant().StartsWith("exb", StringComparison.Ordinal))
                            {
                                AaruConsole.DebugWriteLine("Media detection",
                                                           "SCSI medium type is {0:X2}h, density code is {1:X2}h, drive model starts with \"exb\" setting media type to 112m Exatape.",
                                                           mediumType, densityCode);

                                return MediaType.Exatape112m;
                            }

                            break;
                        }
                    }
                }

                    break;
                case 0xD1:
                {
                    switch(densityCode)
                    {
                        case 0x00:
                        case 0x27:
                        case 0x28:
                        {
                            if(model.ToLowerInvariant().StartsWith("exb", StringComparison.Ordinal))
                            {
                                AaruConsole.DebugWriteLine("Media detection",
                                                           "SCSI medium type is {0:X2}h, density code is {1:X2}h, drive model starts with \"exb\" setting media type to 22m Exatape AME.",
                                                           mediumType, densityCode);

                                return MediaType.Exatape22mAME;
                            }

                            break;
                        }
                    }
                }

                    break;
                case 0xD2:
                {
                    switch(densityCode)
                    {
                        case 0x00:
                        case 0x27:
                        case 0x28:
                        {
                            if(model.ToLowerInvariant().StartsWith("exb", StringComparison.Ordinal))
                            {
                                AaruConsole.DebugWriteLine("Media detection",
                                                           "SCSI medium type is {0:X2}h, density code is {1:X2}h, drive model starts with \"exb\" setting media type to 170m Exatape.",
                                                           mediumType, densityCode);

                                return MediaType.Exatape170m;
                            }

                            break;
                        }
                    }
                }

                    break;
                case 0xD3:
                {
                    switch(densityCode)
                    {
                        case 0x00:
                        case 0x27:
                        case 0x28:
                        {
                            if(model.ToLowerInvariant().StartsWith("exb", StringComparison.Ordinal))
                            {
                                AaruConsole.DebugWriteLine("Media detection",
                                                           "SCSI medium type is {0:X2}h, density code is {1:X2}h, drive model starts with \"exb\" setting media type to 125m Exatape.",
                                                           mediumType, densityCode);

                                return MediaType.Exatape125m;
                            }

                            break;
                        }
                    }
                }

                    break;
                case 0xD4:
                {
                    switch(densityCode)
                    {
                        case 0x00:
                        case 0x27:
                        case 0x28:
                        {
                            if(model.ToLowerInvariant().StartsWith("exb", StringComparison.Ordinal))
                            {
                                AaruConsole.DebugWriteLine("Media detection",
                                                           "SCSI medium type is {0:X2}h, density code is {1:X2}h, drive model starts with \"exb\" setting media type to 45m Exatape.",
                                                           mediumType, densityCode);

                                return MediaType.Exatape45m;
                            }

                            break;
                        }
                    }
                }

                    break;
                case 0xD5:
                {
                    switch(densityCode)
                    {
                        case 0x00:
                        case 0x27:
                        case 0x28:
                        {
                            if(model.ToLowerInvariant().StartsWith("exb", StringComparison.Ordinal))
                            {
                                AaruConsole.DebugWriteLine("Media detection",
                                                           "SCSI medium type is {0:X2}h, density code is {1:X2}h, drive model starts with \"exb\" setting media type to 225m Exatape.",
                                                           mediumType, densityCode);

                                return MediaType.Exatape225m;
                            }

                            break;
                        }
                    }
                }

                    break;
                case 0xD6:
                {
                    switch(densityCode)
                    {
                        case 0x00:
                        case 0x27:
                        case 0x28:
                        {
                            if(model.ToLowerInvariant().StartsWith("exb", StringComparison.Ordinal))
                            {
                                AaruConsole.DebugWriteLine("Media detection",
                                                           "SCSI medium type is {0:X2}h, density code is {1:X2}h, drive model starts with \"exb\" setting media type to 150m Exatape.",
                                                           mediumType, densityCode);

                                return MediaType.Exatape150m;
                            }

                            break;
                        }
                    }
                }

                    break;
                case 0xD7:
                {
                    switch(densityCode)
                    {
                        case 0x00:
                        case 0x27:
                        case 0x28:
                        {
                            if(model.ToLowerInvariant().StartsWith("exb", StringComparison.Ordinal))
                            {
                                AaruConsole.DebugWriteLine("Media detection",
                                                           "SCSI medium type is {0:X2}h, density code is {1:X2}h, drive model starts with \"exb\" setting media type to 75m Exatape.",
                                                           mediumType, densityCode);

                                return MediaType.Exatape75m;
                            }

                            break;
                        }
                    }
                }

                    break;
            }

            return MediaType.Unknown;
        }
    }
}