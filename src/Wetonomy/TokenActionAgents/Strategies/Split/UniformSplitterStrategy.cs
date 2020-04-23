﻿using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using Wetonomy.TokenActionAgents.State;
using Wetonomy.TokenManager;
using Wetonomy.TokenManager.Messages;

namespace Wetonomy.TokenActionAgents.Strategies.Split
{
	public class UniformSplitterStrategy: ITriggeredAction
	{
		public IList<object> Execute(RecipientState state, AbstractTrigger message)
		{
            var result = new List<object>();
            BigInteger amount = message.Amount;
            int count = state.Recipients.Count;
            if (count == 0) throw new Exception();
            BigInteger portion = amount / count;
            // We are going to lose tokens because we are using integer
            foreach( IAgentTokenKey recipient in state.Recipients)
            {
                var command = new TransferTokenMessage(portion, default, recipient);
                amount -= portion;
                result.Add(command);
            }
            return result;
        }
	}
}
