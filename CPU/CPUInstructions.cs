using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBoyEmu.CPU
{
    public partial class CPUmain
    {
         private void rotateRightNoCarry()
        {
            throw new NotImplementedException();
        }

        private void loadMemoryToRegister8(ref byte register, ushort address)
        {
             register = ReadMemory(address);
        }

        private void addToRegisterHL(Register register)
        {
            throw new NotImplementedException();
        }

        private void loadRegisterToMemory(Register stackPointer)
        {
            ushort address = ReadNextTwoValues();
            WriteMemory(address, stackPointer.Low);
            WriteMemory(address + 1, stackPointer.High);
        }

        private void rotateLeftNoCarry()
        {
            throw new NotImplementedException();
        }

        private void loadToRegister8(ref byte register)
        {
            register = ReadNextValue();
        }

        private void decrementRegister8(ref byte register)
        {
            register--;
            //Flags
        }

        private void decrementRegister16(Register register)
        {
            IncrementCycles(4);
            register.Value--;
        }

        private void incrementRegister8(ref byte register)
        {
            register++;
            //Flags
        }

        private void incrementRegister16(Register register)
        {
            IncrementCycles(4);
            register.Value++;
        }

        private void loadToMemory8(ushort address, byte value)
        {
            WriteMemory(address, value); 
        }

        private void loadToRegister16(Register register)
        {
            register.Value = ReadNextTwoValues();
        }

    }
}
