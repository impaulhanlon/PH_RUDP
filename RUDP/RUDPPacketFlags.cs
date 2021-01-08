using System;

namespace RUDP
{
    [Flags]
    public enum RUDPPacketFlags
    {
        NUL = 0,
        ACK, //acknowledgment 
        RST  //reset 
    }
}