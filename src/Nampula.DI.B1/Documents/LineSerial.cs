namespace Nampula.DI.B1.Documents
{
    public class LineSerialNumber
    {
        public LineSerialNumber()
        {
        }

        public LineSerialNumber(LineSerialNumber b)
        {
            SystemSerialNumber = b.SystemSerialNumber;
            InternalSerialNumber = b.InternalSerialNumber;
        }

        public int SystemSerialNumber { get; set; }
        public string InternalSerialNumber { get; set; }
    }
}
