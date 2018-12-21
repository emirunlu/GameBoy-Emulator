using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBoyEmu.Memory
{
    public abstract class MBController
    {
        protected byte[] data;
        protected byte[] cartridge;
        protected byte[] ramBank;

        public byte CurrentRomBank { get; set; }
        public byte CurrentRamBank { get; set; }
        protected BankModes BankMode { get; set; }
        public bool ExternalRamEnabled { get; set; }

        protected enum BankModes
        {
            Rom = 0,
            Ram = 1
        }
        protected MBController(Stream fileStream)
        {
            cartridge = new byte[fileStream.Length];
            fileStream.Read(cartridge, 0x0, cartridge.Length);

            data = new byte[64 * 1024];
            ramBank = new byte[32 * 1024];

            CurrentRomBank = 1;
            CurrentRamBank = 0;

            BankMode = BankModes.Rom;
            ExternalRamEnabled = false;
        }
        public virtual byte this[int address] 
        { 
            get {
                return cartridge[0];
            } 

            set
            {
                return;
            }
        }
    }
}
