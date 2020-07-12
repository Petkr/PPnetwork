﻿using System.Net;
using System;

namespace PPchatLibrary
{
	class PortOutOfRangeParseException : ParseException
	{
		public PortOutOfRangeParseException(int port)
			: base($"Port {port} is out of range, should be <= {IPEndPoint.MaxPort} and >= {IPEndPoint.MinPort}.")
		{}
	}

	class PortIntParseException : ParseException
	{
		public PortIntParseException(ReadOnlyMemory<char> portString)
			: base($"Port {portString} is not a valid format for a port. Should be a number, <= {IPEndPoint.MaxPort} and >= {IPEndPoint.MinPort}.")
		{}
	}

	class IPAddressParseException : ParseException
	{
		public IPAddressParseException(ReadOnlyMemory<char> ipAddressString)
			: base($"Address {ipAddressString} is not a valid format for an IP address. Should be in format x.y.z.w, where x, y, z, w are numbers < 256 and >= 0.")
		{}
	}

	public static class Parsers
	{
		public static int ParsePort(ReadOnlyMemory<char> input)
		{
			if (int.TryParse(input.Span, out var port))
			{
				if (port < 65536 && port >= 0)
					return port;
				else
					throw new PortOutOfRangeParseException(port);
			}
			else
				throw new PortIntParseException(input);
		}

		public static IPAddress ParseIPAddress(ReadOnlyMemory<char> input)
		{
			if (IPAddress.TryParse(input.Span, out var address))
				return address;
			else
				throw new IPAddressParseException(input);
		}
	}
}
