using System;
using System.Threading.Tasks;

namespace StyleCop
{
    public enum State
    {
        Ok,
        Cancel
    }

    public class Program
    {
        private static void Main()
        {
            var message = new MessageBox();
            var tcs = new TaskCompletionSource<State>();

            message.ActionClose = message.Open;
            if (message.St == State.Ok)
            {
                Console.Write("операция была подтверждена");
                tcs.SetResult(State.Ok);
            }
            else if (message.St == State.Cancel)
            {
                Console.Write("операция была отклонена");
                tcs.SetResult(State.Cancel);
            }

            tcs.Task.GetAwaiter().GetResult();
        }
    }
}
