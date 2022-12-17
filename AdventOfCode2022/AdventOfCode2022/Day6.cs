namespace AdventOfCode2022
{
    public class Day6 : BaseDay
    {
        private int _packetLocation = 0;
        private int _messageLocation = 0;
        public int PacketLocation { get { return _packetLocation; } }
        public int MessageLocation { get { return _messageLocation; } }

        public override void Run()
        {
            base.Run();

            Console.WriteLine($"Packet Location: {PacketLocation}");
            Console.WriteLine($"Message Location: {MessageLocation}");
        }

        public override void ProcessData()
        {
            var datastream = _inputData.First();
            IList<char> packet = new List<char>();
            IList<char> messagePacket = new List<char>();

            for (var index = 0; index < datastream.Length; index++)
            {
                packet.Add(datastream[index]);
                messagePacket.Add(datastream[index]);

                if (packet.Count > 4) packet.RemoveAt(0);

                if (messagePacket.Count > 14) messagePacket.RemoveAt(0);

                if (packet.Count == 4 && _packetLocation <= 0 && IsUniquePacket(packet))
                {
                    _packetLocation = index + 1;
                }

                if (messagePacket.Count == 14 && _messageLocation <= 0 && IsUniquePacket(messagePacket))
                {
                    _messageLocation = index + 1;
                }
            }
        }

        private bool IsUniquePacket(IEnumerable<char> pkt)
        {
            var query = pkt.GroupBy(x => x)
                        .Where(g => g.Count() > 1)
                        .Select(y => y.Key)
                        .ToList();

            return !query.Any();
        }
    }
}
