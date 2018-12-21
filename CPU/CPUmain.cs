using GameBoyEmu.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBoyEmu.CPU
{
    [Serializable]
    public partial class CPUmain
    {
        public Register AF { get; private set; }
        public Register BC { get; private set; }
        public Register DE { get; private set; }
        public Register HL { get; private set; }
        public Register StackPointer { get; private set; }
        public ushort ProgramCounter { get; private set; }
        public MBController Memory { get; private set; }
        public bool isHalted { get; private set; }
        public int CyclesExecuted { get; private set; }

        public readonly byte FlagZ = 1 << 7;    // Zero Flag
        public readonly byte FlagN = 1 << 6;    // Add/Sub Flag
        public readonly byte FlagH = 1 << 5;    // Half Carry Flag            
        public readonly byte FlagC = 1 << 4;    // Carry Flag
        

        public CPUmain() { }
        public void ProcessOPCode()
        {
            int opCode;

            if (isHalted)
            {
                opCode = 0x76;
                IncrementCycles(4);
            }
            else
            {
                opCode = ReadNextValue();
            }

            switch (opCode)
            {
                case 0x00: // NOP
                    break;
                case 0x01: loadToRegister16(BC); // LD BC RG 16-bit
                    break;
                case 0x02: loadToMemory8(BC.Value, AF.High); // LD BC MEM 8-bit
                    break;
                case 0x03: incrementRegister16(BC); // Increment BC
                    break;
                case 0x04: incrementRegister8(ref BC.High); // Increment 8-bit high
                    break;
                case 0x05: decrementRegister8(ref BC.High); // Decrement 8-bit high
                    break;
                case 0x06: loadToRegister8(ref BC.High); // LD BC RG 8-bit
                    break;
                case 0x07: rotateLeftNoCarry(); // RL No carry
                    break;
                case 0x08: loadRegisterToMemory(StackPointer); // LD RG to MEM
                    break;
                case 0x09: addToRegisterHL(BC); // ADD HL to RG
                    break;
                case 0x0A: loadMemoryToRegister8(ref AF.High, BC.Value); // LD to RG 8-bit
                    break;
                case 0x0B: decrementRegister16(BC); // Decrement 16-bit
                    break;
                case 0x0C: incrementRegister8(ref BC.Low); // Increment RG 8-bit low
                    break;
                case 0x0D: decrementRegister8(ref BC.Low); // Decrement RG 8-bit low
                    break;
                case 0x0E: loadToRegister8(ref BC.Low); // LD to RG 8-bit
                    break;
                case 0x0F: rotateRightNoCarry(); // RR No carry
                    break;

            }

        }

        private byte ReadNextValue()
        {
            IncrementCycles(4);
            byte value = Memory[ProgramCounter++];
            return value;
        }

        private ushort ReadNextTwoValues()
        {
            byte low = ReadNextValue();
            ushort values = low;
            byte high = ReadNextValue();
            values |= (ushort)(high << 8);
            return values;
        }

        private void IncrementCycles(int amount)
        {
            CyclesExecuted += amount;
            //update graphics and timers
        }

        private byte ReadMemory(ushort address)
        {
            IncrementCycles(4);
            return Memory[address];
        }

        private void WriteMemory(int address, byte value)
        {
            IncrementCycles(4);
            Memory[address] = value;
        }
    }
}   
