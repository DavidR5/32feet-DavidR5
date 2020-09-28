﻿//-----------------------------------------------------------------------
// <copyright file="BluetoothRemoteGATTServer.cs" company="In The Hand Ltd">
//   Copyright (c) 2018-20 In The Hand Ltd, All rights reserved.
//   This source code is licensed under the MIT License - see License.txt
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InTheHand.Bluetooth
{
    public sealed partial class BluetoothRemoteGATTServer
    {
        internal BluetoothRemoteGATTServer(BluetoothDevice device)
        {
            Device = device;
            PlatformInit();
        }

        private void Device_GattServerDisconnected(object sender, EventArgs e)
        {
            Device.OnGattServerDisconnected();
        }

        public BluetoothDevice Device { get; private set; }

        public bool Connected { get { return GetConnected(); } }

        public Task ConnectAsync()
        {
            return PlatformConnect();
        }

        public void Disconnect()
        {
            PlatformDisconnect();
            Device.OnGattServerDisconnected();
        }

        public Task<GattService> GetPrimaryServiceAsync(BluetoothUuid service)
        {
            return PlatformGetPrimaryService(service);
        }

        public Task<List<GattService>> GetPrimaryServicesAsync(BluetoothUuid? service = null)
        {
            return PlatformGetPrimaryServices(service);
        }

        public Task<short> ReadRssi()
        {
            return PlatformReadRssi();
        }
    }
}
