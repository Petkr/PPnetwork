﻿namespace PPnetwork
{
	public interface ICommandHandler<CommandArgument>
		where CommandArgument : ICommandArgument
	{
		void Handle(CommandArgument argument);
	}
}
