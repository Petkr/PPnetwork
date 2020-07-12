﻿namespace PPnetwork
{
	public interface IPacketHandler<Packet>
		where Packet : IPacket
	{
		void Handle(Packet packet);
	}
}
